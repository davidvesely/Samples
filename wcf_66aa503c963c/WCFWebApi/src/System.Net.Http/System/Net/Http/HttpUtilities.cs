﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http.Headers;

namespace System.Net.Http
{
    internal static class HttpUtilities
    {
        internal static readonly Version DefaultVersion = HttpVersion.Version11;
        internal static readonly byte[] EmptyByteArray = new byte[0];

        internal static bool IsHttpUri(Uri uri)
        {
            Contract.Assert(uri != null);

            string scheme = uri.Scheme;
            return ((string.Compare("http", scheme, StringComparison.OrdinalIgnoreCase) == 0) ||
                (string.Compare("https", scheme, StringComparison.OrdinalIgnoreCase) == 0));
        }

        // Returns true if the task was faulted or canceled and sets tcs accordingly.
        internal static bool HandleFaultsAndCancelation<T>(Task task, TaskCompletionSource<T> tcs)
        {
            Contract.Assert(task.IsCompleted); // Success, faulted, or cancelled
            if (task.IsFaulted)
            {
                tcs.TrySetException(task.Exception.GetBaseException());
                return true;
            }
            else if (task.IsCanceled)
            {
                tcs.TrySetCanceled();
                return true;
            }
            return false;
        }
    }
}
