// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace System.Net.Http
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Text;

    /// <summary>
    /// HTTP Request Line parser for parsing the first line (the request line) in an HTTP request.
    /// </summary>
    internal class HttpRequestLineParser
    {
        internal const int MinRequestLineSize = 14;
        private const int DefaultTokenAllocation = 2 * 1024;

        private int totalBytesConsumed;
        private int maximumHeaderLength;

        private HttpRequestLineState requestLineState;
        private HttpUnsortedRequest httpRequest;
        private StringBuilder currentToken = new StringBuilder(DefaultTokenAllocation);

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestLineParser"/> class.
        /// </summary>
        /// <param name="httpRequest"><see cref="HttpUnsortedRequest"/> instance where the request line properties will be set as they are parsed.</param>
        /// <param name="maxRequestLineSize">Maximum length of HTTP header.</param>
        public HttpRequestLineParser(HttpUnsortedRequest httpRequest, int maxRequestLineSize)
        {
            // The minimum length which would be an empty header terminated by CRLF
            if (maxRequestLineSize < MinRequestLineSize)
            {
                throw new ArgumentException(SR.MinParameterSize(MinRequestLineSize), "maxRequestLineSize");
            }

            if (httpRequest == null)
            {
                throw new ArgumentNullException("httpRequest");
            }

            this.httpRequest = httpRequest;
            this.maximumHeaderLength = maxRequestLineSize;
        }

        private enum HttpRequestLineState
        {
            RequestMethod = 0,
            RequestUri,
            BeforeVersionNumbers,
            MajorVersionNumber,
            MinorVersionNumber,
            AfterCarriageReturn
        }

        /// <summary>
        /// Parse an HTTP request line. 
        /// Bytes are parsed in a consuming manner from the beginning of the request buffer meaning that the same bytes can not be 
        /// present in the request buffer.
        /// </summary>
        /// <param name="buffer">Request buffer from where request is read</param>
        /// <param name="bytesReady">Size of request buffer</param>
        /// <param name="bytesConsumed">Offset into request buffer</param>
        /// <returns>State of the parser.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is translated to parse state.")]
        public ParserState ParseBuffer(
            byte[] buffer,
            int bytesReady,
            ref int bytesConsumed)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            ParserState parseStatus = ParserState.NeedMoreData;

            if (bytesConsumed >= bytesReady)
            {
                // We already can tell we need more data
                return parseStatus;
            }

            try
            {
                parseStatus = ParseRequestLine(
                    buffer,
                    bytesReady,
                    ref bytesConsumed,
                    ref this.requestLineState,
                    this.maximumHeaderLength,
                    ref this.totalBytesConsumed,
                    this.currentToken,
                    this.httpRequest);
            }
            catch (Exception)
            {
                parseStatus = ParserState.Invalid;
            }

            return parseStatus;
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "This is a parser which cannot be split up for performance reasons.")]
        private static unsafe ParserState ParseRequestLine(
                byte[] buffer,
                int bytesReady,
                ref int bytesConsumed,
                ref HttpRequestLineState requestLineState,
                int maximumHeaderLength,
                ref int totalBytesConsumed,
                StringBuilder currentToken,
                HttpUnsortedRequest httpRequest)
        {
            Contract.Assert((bytesReady - bytesConsumed) >= 0, "ParseRequestLine()|(bytesReady - bytesConsumed) < 0");
            Contract.Assert(maximumHeaderLength <= 0 || totalBytesConsumed <= maximumHeaderLength, "ParseRequestLine()|Headers already read exceeds limit.");

            // Remember where we started.
            int initialBytesParsed = bytesConsumed;
            int segmentStart;

            // Set up parsing status with what will happen if we exceed the buffer.
            ParserState parseStatus = ParserState.DataTooBig;
            int effectiveMax = maximumHeaderLength <= 0 ? int.MaxValue : (maximumHeaderLength - totalBytesConsumed + bytesConsumed);
            if (bytesReady < effectiveMax)
            {
                parseStatus = ParserState.NeedMoreData;
                effectiveMax = bytesReady;
            }

            Contract.Assert(bytesConsumed < effectiveMax, "We have already consumed more than the max header length.");

            fixed (byte* inputPtr = buffer)
            {
                switch (requestLineState)
                {
                    case HttpRequestLineState.RequestMethod:
                        segmentStart = bytesConsumed;
                        while (inputPtr[bytesConsumed] != ' ')
                        {
                            if (inputPtr[bytesConsumed] < 0x21 || inputPtr[bytesConsumed] > 0x7a)
                            {
                                parseStatus = ParserState.Invalid;
                                goto quit;
                            }

                            if (++bytesConsumed == effectiveMax)
                            {
                                string method = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                                currentToken.Append(method);
                                goto quit;
                            }
                        }

                        if (bytesConsumed > segmentStart)
                        {
                            string method = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(method);
                        }

                        // Copy value out
                        httpRequest.Method = new HttpMethod(currentToken.ToString());
                        currentToken.Clear();

                        // Move past the SP
                        requestLineState = HttpRequestLineState.RequestUri;
                        if (++bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case HttpRequestLineState.RequestUri;

                    case HttpRequestLineState.RequestUri:
                        segmentStart = bytesConsumed;
                        while (inputPtr[bytesConsumed] != ' ')
                        {
                            if (inputPtr[bytesConsumed] == '\r')
                            {
                                parseStatus = ParserState.Invalid;
                                goto quit;
                            }
                                
                            if (++bytesConsumed == effectiveMax)
                            {
                                string addr = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                                currentToken.Append(addr);
                                goto quit;
                            }
                        }

                        if (bytesConsumed > segmentStart)
                        {
                            string addr = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(addr);
                        }

                        // URI validation happens when we create the URI later.
                        if (currentToken.Length == 0)
                        {
                            throw new FormatException(SR.HttpMessageParserEmptyUri);
                        }

                        // Copy value out
                        httpRequest.RequestUri = currentToken.ToString();
                        currentToken.Clear();

                        // Move past the SP
                        requestLineState = HttpRequestLineState.BeforeVersionNumbers;
                        if (++bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case HttpRequestLineState.BeforeVersionNumbers;

                    case HttpRequestLineState.BeforeVersionNumbers:
                        segmentStart = bytesConsumed;
                        while (inputPtr[bytesConsumed] != '/')
                        {
                            if (inputPtr[bytesConsumed] < 0x21 || inputPtr[bytesConsumed] > 0x7a)
                            {
                                parseStatus = ParserState.Invalid;
                                goto quit;
                            }

                            if (++bytesConsumed == effectiveMax)
                            {
                                string token = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                                currentToken.Append(token);
                                goto quit;
                            }
                        }

                        if (bytesConsumed > segmentStart)
                        {
                            string token = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(token);
                        }

                        // Validate value
                        string version = currentToken.ToString();
                        if (string.CompareOrdinal(FormattingUtilities.HttpVersionToken, version) != 0)
                        {
                            throw new FormatException(SR.HttpInvalidVersion(version, FormattingUtilities.HttpVersionToken));
                        }

                        currentToken.Clear();

                        // Move past the '/'
                        requestLineState = HttpRequestLineState.MajorVersionNumber;
                        if (++bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case HttpRequestLineState.MajorVersionNumber;

                    case HttpRequestLineState.MajorVersionNumber:
                        segmentStart = bytesConsumed;
                        while (inputPtr[bytesConsumed] != '.')
                        {
                            if (inputPtr[bytesConsumed] < '0' || inputPtr[bytesConsumed] > '9')
                            {
                                parseStatus = ParserState.Invalid;
                                goto quit;
                            }

                            if (++bytesConsumed == effectiveMax)
                            {
                                string major = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                                currentToken.Append(major);
                                goto quit;
                            }
                        }

                        if (bytesConsumed > segmentStart)
                        {
                            string major = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(major);
                        }

                        // Move past the "."
                        currentToken.Append('.');
                        requestLineState = HttpRequestLineState.MinorVersionNumber;
                        if (++bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case HttpRequestLineState.MinorVersionNumber;

                    case HttpRequestLineState.MinorVersionNumber:
                        segmentStart = bytesConsumed;
                        while (inputPtr[bytesConsumed] != '\r')
                        {
                            if (inputPtr[bytesConsumed] < '0' || inputPtr[bytesConsumed] > '9')
                            {
                                parseStatus = ParserState.Invalid;
                                goto quit;
                            }

                            if (++bytesConsumed == effectiveMax)
                            {
                                string minor = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                                currentToken.Append(minor);
                                goto quit;
                            }
                        }

                        if (bytesConsumed > segmentStart)
                        {
                            string minor = Encoding.UTF8.GetString(buffer, segmentStart, bytesConsumed - segmentStart);
                            currentToken.Append(minor);
                        }

                        // Copy out value
                        httpRequest.Version = Version.Parse(currentToken.ToString());
                        currentToken.Clear();

                        // Move past the CR
                        requestLineState = HttpRequestLineState.AfterCarriageReturn;
                        if (++bytesConsumed == effectiveMax)
                        {
                            goto quit;
                        }

                        goto case HttpRequestLineState.AfterCarriageReturn;

                    case HttpRequestLineState.AfterCarriageReturn:
                        if (inputPtr[bytesConsumed] != '\n')
                        {
                            parseStatus = ParserState.Invalid;
                            goto quit;
                        }

                        parseStatus = ParserState.Done;
                        bytesConsumed++;
                        break;
                }
            }

        quit:
            totalBytesConsumed += bytesConsumed - initialBytesParsed;
            return parseStatus;
        }
    }
}