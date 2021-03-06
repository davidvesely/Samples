﻿using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public class HttpClient : IDisposable
    {
        #region Fields

        private static readonly TimeSpan defaultTimeout = TimeSpan.FromSeconds(100);
        private static readonly TimeSpan maxTimeout = TimeSpan.FromMilliseconds(int.MaxValue);
        // Replace this with the new value Threading.Timeout.InfiniteTimeSpan in M3S.
        private static readonly TimeSpan infiniteTimeout = TimeSpan.FromMilliseconds(Threading.Timeout.Infinite);
        private const HttpCompletionOption defaultCompletionOption = HttpCompletionOption.ResponseContentRead;

        private volatile bool operationStarted;
        private volatile bool disposed;

        private CancellationTokenSource pendingRequestsCts;
        private HttpMessageHandler handler;
        private HttpRequestHeaders defaultRequestHeaders;

        private Uri baseAddress;
        private TimeSpan timeout;
        private int maxResponseContentBufferSize;

#if NET_4
        private TimerThread.Queue timerQueue;

        private TimerThread.Queue TimerQueue
        {
            get
            {
                if (this.timerQueue == null)
                {
                    this.timerQueue = TimerThread.GetOrCreateQueue((int)this.timeout.TotalMilliseconds);
                }
                return this.timerQueue;
            }
        }

        private static readonly TimerThread.Callback timeoutCallback = new TimerThread.Callback(TimeoutCallback);

        private static void TimeoutCallback(TimerThread.Timer timer, int timeNoticed, object context)
        {
            try
            {
                ((CancellationTokenSource)context).Cancel();
            }
            catch (ObjectDisposedException)
            {
                // The operation has completed before the timeout.
            }
            catch (AggregateException aggregateException)
            {
                if (Logging.On) Logging.Exception(Logging.Http, context, "TimeoutCallback", aggregateException);
            }
        }
#endif

        #endregion Fields

        #region Properties

        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                if (defaultRequestHeaders == null)
                {
                    defaultRequestHeaders = new HttpRequestHeaders();
                }
                return defaultRequestHeaders;
            }
        }

        public Uri BaseAddress
        {
            get { return baseAddress; }
            set
            {
                CheckBaseAddress(value, "value");
                CheckDisposedOrStarted();

                if (Logging.On) Logging.PrintInfo(Logging.Http, this, "BaseAddress: '" + baseAddress + "'");

                baseAddress = value;
            }
        }

        public TimeSpan Timeout
        {
            get { return timeout; }
            set
            {
                if (value != infiniteTimeout && (value <= TimeSpan.Zero || value > maxTimeout))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                CheckDisposedOrStarted();
                timeout = value;
            }
        }

        public int MaxResponseContentBufferSize
        {
            get { return maxResponseContentBufferSize; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                CheckDisposedOrStarted();
                maxResponseContentBufferSize = value;
            }
        }

        #endregion Properties

        #region Constructors

        public HttpClient()
            : this(null)
        {
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "code is clone of System.Net.Http")]
        public HttpClient(HttpMessageHandler handler)
        {
            if (Logging.On) Logging.Enter(Logging.Http, this, ".ctor", handler);

            if (handler == null)
            {
                // We provide a default
                handler = new HttpClientHandler();
            }
            if (Logging.On) Logging.Associate(Logging.Http, this, handler);

            this.handler = handler;
            this.timeout = defaultTimeout;
            this.maxResponseContentBufferSize = HttpContent.DefaultMaxBufferSize;
            this.pendingRequestsCts = new CancellationTokenSource();

            if (Logging.On) Logging.Exit(Logging.Http, this, ".ctor", null);
        }

        #endregion Constructors

        #region Public Send

        #region Simple Get Overloads

        public Task<string> GetStringAsync(string requestUri)
        {
            return GetStringAsync(CreateUri(requestUri));
        }

        public Task<string> GetStringAsync(Uri requestUri)
        {
            return GetContentAsync(requestUri, HttpCompletionOption.ResponseContentRead, string.Empty, 
                content => content.ReadAsStringAsync());
        }

        public Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            return GetByteArrayAsync(CreateUri(requestUri));
        }

        public Task<byte[]> GetByteArrayAsync(Uri requestUri)
        {
            return GetContentAsync(requestUri, HttpCompletionOption.ResponseContentRead, HttpUtilities.EmptyByteArray, 
                content => content.ReadAsByteArrayAsync());
        }

        // Unbuffered by default
        public Task<Stream> GetStreamAsync(string requestUri)
        {
            return GetStreamAsync(CreateUri(requestUri));
        }

        // Unbuffered by default
        public Task<Stream> GetStreamAsync(Uri requestUri)
        {
            return GetContentAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, Stream.Null, 
                content => content.ReadAsStreamAsync());
        }

        private Task<T> GetContentAsync<T>(Uri requestUri, HttpCompletionOption completionOption, T defaultValue, 
            Func<HttpContent, Task<T>> readAs)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

            GetAsync(requestUri, completionOption).ContinueWith(requestTask =>
            {
                if (HandleRequestFaultsAndCancelation(requestTask, tcs))
                {
                    return;
                }
                HttpResponseMessage response = requestTask.Result;
                if (response.Content == null)
                {
                    tcs.TrySetResult(defaultValue);
                    return;
                }

                try
                {
                    readAs(response.Content).ContinueWith(contentTask =>
                    {
                        if (!HttpUtilities.HandleFaultsAndCancelation(contentTask, tcs))
                        {
                            tcs.TrySetResult(contentTask.Result);
                        }
                    }, TaskContinuationOptions.ExecuteSynchronously);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }, TaskContinuationOptions.ExecuteSynchronously);

            return tcs.Task;
        }
        
        #endregion Simple Send Overloads

        #region REST Send Overloads

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return GetAsync(CreateUri(requestUri));
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return GetAsync(requestUri, defaultCompletionOption);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
        {
            return GetAsync(CreateUri(requestUri), completionOption);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
        {
            return GetAsync(requestUri, completionOption, CancellationToken.None);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return GetAsync(CreateUri(requestUri), cancellationToken);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return GetAsync(requestUri, defaultCompletionOption, cancellationToken);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            return GetAsync(CreateUri(requestUri), completionOption, cancellationToken);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, 
            CancellationToken cancellationToken)
        {
            return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return PostAsync(CreateUri(requestUri), content);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return PostAsync(requestUri, content, CancellationToken.None);
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content,
            CancellationToken cancellationToken)
        {
            return PostAsync(CreateUri(requestUri), content, cancellationToken);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, 
            CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = content;
            return SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return PutAsync(CreateUri(requestUri), content);
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return PutAsync(requestUri, content, CancellationToken.None);
        }

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content,
            CancellationToken cancellationToken)
        {
            return PutAsync(CreateUri(requestUri), content, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, 
            CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, requestUri);
            request.Content = content;
            return SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return DeleteAsync(CreateUri(requestUri));
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            return DeleteAsync(requestUri, CancellationToken.None);
        }

        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            return DeleteAsync(CreateUri(requestUri), cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);
        }

        #endregion REST Send Overloads

        #region Advanced Send

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return SendAsync(request, defaultCompletionOption, CancellationToken.None);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return SendAsync(request, defaultCompletionOption, cancellationToken);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
        {
            return SendAsync(request, completionOption, CancellationToken.None);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            CheckDisposed();
            CheckRequestMessage(request);

            SetOperationStarted();
            PrepareRequestMessage(request);
            // PrepareRequestMessage will resolve the request address against the base address.
            if (Logging.On) Logging.Enter(Logging.Http, this, "SendAsync", Logging.GetObjectLogHash(request) + ": " + request);

            CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken,
                pendingRequestsCts.Token);
#if NET_4
            TimerThread.Timer timeoutTimer = SetTimeout(linkedCts);
#else
            SetTimeout(linkedCts);
#endif

            TaskCompletionSource<HttpResponseMessage> tcs = new TaskCompletionSource<HttpResponseMessage>();
            handler.SendAsync(request, linkedCts.Token).ContinueWith(task =>
            {
                try
                {
                    // The request is completed. Dispose the request content.
                    DisposeRequestContent(request);
#if NET_4
                    // The request is completed. Dispose the timeout timer.
                    if (timeoutTimer != null)
                    {
                        timeoutTimer.Dispose();
                    }
#endif

                    if (task.IsFaulted)
                    {
                        SetTaskFaulted(request, linkedCts, tcs, task.Exception.GetBaseException());
                        return;
                    }

                    if (task.IsCanceled)
                    {
                        SetTaskCanceled(request, linkedCts, tcs);
                        return;
                    }

                    HttpResponseMessage response = task.Result;
                    if (response == null)
                    {
                        SetTaskFaulted(request, linkedCts, tcs,
                            new InvalidOperationException(SR.net_http_handler_noresponse));
                        return;
                    }

                    // If we don't have a response content, just return the response message.
                    if ((response.Content == null) || (completionOption == HttpCompletionOption.ResponseHeadersRead))
                    {
                        SetTaskCompleted(request, linkedCts, tcs, response);
                        return;
                    }
                    Contract.Assert(completionOption == HttpCompletionOption.ResponseContentRead,
                        "Unknown completion option.");

                    // We have an assigned content. Start loading it into a buffer and return response message once
                    // the whole content is buffered.
                    StartContentBuffering(request, linkedCts, tcs, response);
                }
                catch (Exception e)
                {
                    // Make sure we catch any exception, otherwise the task will catch it and throw in the finalizer.
                    if (Logging.On) Logging.Exception(Logging.Http, this, "SendAsync", e);
                    tcs.TrySetException(e);
                }

            }, TaskContinuationOptions.ExecuteSynchronously);

            if (Logging.On) Logging.Exit(Logging.Http, this, "SendAsync", tcs.Task);
            return tcs.Task;
        }

        public void CancelPendingRequests()
        {
            CheckDisposed();

            if (Logging.On) Logging.Enter(Logging.Http, this, "CancelPendingRequests", "");

            // With every request we link this cancellation token source.
            CancellationTokenSource currentCts = Interlocked.Exchange(ref pendingRequestsCts,
                new CancellationTokenSource());

            currentCts.Cancel();
            currentCts.Dispose();

            if (Logging.On) Logging.Exit(Logging.Http, this, "CancelPendingRequests", "");
        }

        #endregion Advanced Send

        #endregion Public Send

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                disposed = true;

                // Cancel all pending requests (if any). Note that we don't call CancelPendingRequests() but cancel
                // the CTS directly. The reason is that CancelPendingRequests() would cancel the current CTS and create
                // a new CTS. We don't want a new CTS in this case.
                pendingRequestsCts.Cancel();
                pendingRequestsCts.Dispose();

                handler.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Private Helpers

        private void DisposeRequestContent(HttpRequestMessage request)
        {
            Contract.Requires(request != null);

            // When a request completes, HttpClient disposes the request content so the user doesn't have to. This also
            // ensures that a HttpContent object is only sent once using HttpClient (similar to HttpRequestMessages
            // that can also be sent only once).
            HttpContent content = request.Content;
            if (content != null)
            {
                content.Dispose();
            }
        }

        private void StartContentBuffering(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource,
            TaskCompletionSource<HttpResponseMessage> tcs, HttpResponseMessage response)
        {
            response.Content.LoadIntoBufferAsync(maxResponseContentBufferSize).ContinueWith(contentTask =>
            {
                try
                {
                    // Make sure to dispose the CTS _before_ setting TaskCompletionSource. Otherwise the task will be
                    // completed and the user may dispose the user CTS on the continuation task leading to a race cond.
                    bool isCancellationRequested = cancellationTokenSource.Token.IsCancellationRequested;

                    // contentTask.Exception is always != null if IsFaulted is true. However, we need to access the
                    // Exception property, otherwise the Task considers the excpetion as "unhandled" and will throw in
                    // its finalizer.
                    if (contentTask.IsFaulted)
                    {
                        response.Dispose();
                        // If the cancellation token was canceled, we consider the exception to be caused by the
                        // cancellation (e.g. WebException when reading from canceled response stream).
                        if (isCancellationRequested && (contentTask.Exception.GetBaseException() is HttpRequestException))
                        {
                            SetTaskCanceled(request, cancellationTokenSource, tcs);
                        }
                        else
                        {
                            SetTaskFaulted(request, cancellationTokenSource, tcs, contentTask.Exception.GetBaseException());
                        }
                        return;
                    }

                    if (contentTask.IsCanceled)
                    {
                        response.Dispose();
                        SetTaskCanceled(request, cancellationTokenSource, tcs);
                        return;
                    }

                    // When buffering content is completed, set the Task as completed.
                    SetTaskCompleted(request, cancellationTokenSource, tcs, response);
                }
                catch (Exception e)
                {
                    // Make sure we catch any exception, otherwise the task will catch it and throw in the finalizer.
                    response.Dispose();
                    tcs.TrySetException(e);
                    if (Logging.On) Logging.Exception(Logging.Http, this, "SendAsync", e);
                }

            }, TaskContinuationOptions.ExecuteSynchronously);
        }

        private void SetOperationStarted()
        {
            // This method flags the HttpClient instances as "active". I.e. we executed at least one request (or are
            // in the process of doing so). This information is used to lock-down all property setters. Once a
            // Send/SendAsync operation started, no property can be changed.
            if (!operationStarted)
            {
                operationStarted = true;
            }
        }

        private void CheckDisposedOrStarted()
        {
            CheckDisposed();
            if (operationStarted)
            {
                throw new InvalidOperationException(SR.net_http_client_operation_started);
            }
        }

        private void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        private static void CheckRequestMessage(HttpRequestMessage request)
        {
            if (!request.MarkAsSent())
            {
                throw new InvalidOperationException(SR.net_http_client_request_already_sent);
            }
        }

        private void PrepareRequestMessage(HttpRequestMessage request)
        {
            Uri requestUri = null;
            if ((request.RequestUri == null) && (baseAddress == null))
            {
                throw new InvalidOperationException(SR.net_http_client_invalid_requesturi);
            }
            if (request.RequestUri == null)
            {
                requestUri = baseAddress;
            }
            else
            {
                // If the request Uri is an absolute Uri, just use it. Otherwise try to combine it with the base Uri.
                if (!request.RequestUri.IsAbsoluteUri)
                {
                    if (baseAddress == null)
                    {
                        throw new InvalidOperationException(SR.net_http_client_invalid_requesturi);
                    }
                    else
                    {
                        requestUri = new Uri(baseAddress, request.RequestUri);
                    }
                }
            }

            // We modified the original request Uri. Assign the new Uri to the request message.
            if (requestUri != null)
            {
                request.RequestUri = requestUri;
            }

            // Add default headers
            if (defaultRequestHeaders != null)
            {
                request.Headers.AddHeaders(defaultRequestHeaders);
            }
        }

        private static void CheckBaseAddress(Uri baseAddress, string parameterName)
        {
            if (baseAddress == null)
            {
                return; // It's OK to not have a base address specified.
            }

            if (!baseAddress.IsAbsoluteUri)
            {
                throw new ArgumentException(SR.net_http_client_absolute_baseaddress_required, parameterName);
            }

            if (!HttpUtilities.IsHttpUri(baseAddress))
            {
                throw new ArgumentException(SR.net_http_client_http_baseaddress_required, parameterName);
            }
        }

        private void SetTaskFaulted(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource,
            TaskCompletionSource<HttpResponseMessage> tcs, Exception e)
        {
            LogSendError(request, cancellationTokenSource, "SendAsync", e);
            tcs.TrySetException(e);
#if NET_4
            try
            {
                cancellationTokenSource.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // We can get this exception in .Net 4.0. In this case, the cancellation did occur and the cts is already disposed
            }
#else
            cancellationTokenSource.Dispose();
#endif
        }

        private void SetTaskCanceled(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource,
            TaskCompletionSource<HttpResponseMessage> tcs)
        {
            LogSendError(request, cancellationTokenSource, "SendAsync", null);
            tcs.TrySetCanceled();
#if NET_4
            try
            {
                cancellationTokenSource.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // We can get this exception in .Net 4.0. In this case, the cancellation did occur and the cts is already disposed
            }
#else
            cancellationTokenSource.Dispose();
#endif
        }

        private void SetTaskCompleted(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource,
            TaskCompletionSource<HttpResponseMessage> tcs, HttpResponseMessage response)
        {
            if (Logging.On) Logging.PrintInfo(Logging.Http, this, string.Format(System.Globalization.CultureInfo.InvariantCulture, SR.net_http_client_send_completed, Logging.GetObjectLogHash(request), Logging.GetObjectLogHash(response), response));
            tcs.TrySetResult(response);
#if NET_4
            try
            {
                cancellationTokenSource.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // We can get this exception in .Net 4.0. In this case, the cancellation did occur and the cts is already disposed
            }
#else
            cancellationTokenSource.Dispose();
#endif
        }

        private void LogSendError(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource,
            string method, Exception e)
        {
            Contract.Requires(request != null);

            if (cancellationTokenSource.IsCancellationRequested)
            {
                if (Logging.On) Logging.PrintError(Logging.Http, this, method, string.Format(System.Globalization.CultureInfo.InvariantCulture, SR.net_http_client_send_canceled, Logging.GetObjectLogHash(request)));
            }
            else
            {
                Contract.Assert(e != null);
                if (Logging.On) Logging.PrintError(Logging.Http, this, method, string.Format(System.Globalization.CultureInfo.InvariantCulture, SR.net_http_client_send_error, Logging.GetObjectLogHash(request), e));
            }
        }

#if NET_4
        private TimerThread.Timer SetTimeout(CancellationTokenSource cancellationTokenSource)
        {
            Contract.Requires(cancellationTokenSource != null);

            TimerThread.Timer timer = null;
            if (timeout != infiniteTimeout)
            {
                timer = TimerQueue.CreateTimer(timeoutCallback, cancellationTokenSource);
            }

            return timer;
        }
#else
        private void SetTimeout(CancellationTokenSource cancellationTokenSource)
        {
            Contract.Requires(cancellationTokenSource != null);

            if (timeout != infiniteTimeout)
            {
                cancellationTokenSource.CancelAfter(timeout);
            }
        }
#endif

        private Uri CreateUri(String uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return null;
            }
            return new Uri(uri, UriKind.RelativeOrAbsolute);
        }

        // Returns true if the task was faulted or canceled and sets tcs accordingly. Non-success status codes count as
        // faults in cases where the HttpResponseMessage object will not be returned to the developer.  
        // See GetStringAsync, GetByteArrayAsync, and GetStreamAsync
        private static bool HandleRequestFaultsAndCancelation<T>(Task<HttpResponseMessage> task, 
            TaskCompletionSource<T> tcs)
        {
            if (HttpUtilities.HandleFaultsAndCancelation(task, tcs))
            {
                return true;
            }

            // Matches HttpResponseMessage.EnsureSuccessStatusCode()
            HttpResponseMessage response = task.Result;
            if (!response.IsSuccessStatusCode)
            {
                if (response.Content != null)
                {
                    response.Content.Dispose();
                }

                tcs.TrySetException(new HttpRequestException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        SR.net_http_message_not_success_statuscode, (int)response.StatusCode,
                        response.ReasonPhrase)));
                return true;
            }
            return false;
        }

        #endregion Private Helpers
    }
}
