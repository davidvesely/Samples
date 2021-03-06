﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace System.Net.Http
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Json;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;

    /// <summary>
    /// Provides various internal utility functions
    /// </summary>
    internal static class FormattingUtilities
    {
        /// <summary>
        /// A <see cref="Type"/> representing <see cref="UTF8Encoding"/>.
        /// </summary>
        public static readonly Type Utf8EncodingType = typeof(UTF8Encoding);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="UnicodeEncoding"/>.
        /// </summary>
        public static readonly Type Utf16EncodingType = typeof(UnicodeEncoding);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="HttpRequestMessage"/>.
        /// </summary>
        public static readonly Type HttpRequestMessageType = typeof(HttpRequestMessage);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="HttpResponseMessage"/>.
        /// </summary>
        public static readonly Type HttpResponseMessageType = typeof(HttpResponseMessage);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="HttpContent"/>.
        /// </summary>
        public static readonly Type HttpContentType = typeof(HttpContent);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="DelegatingEnumerable{T}"/>.
        /// </summary>
        public static readonly Type DelegatingEnumerableGenericType = typeof(DelegatingEnumerable<>);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="IEnumerable{T}"/>.
        /// </summary>
        public static readonly Type EnumerableInterfaceGenericType = typeof(IEnumerable<>);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="IQueryable{T}"/>.
        /// </summary>
        public static readonly Type QueryableInterfaceGenericType = typeof(IQueryable<>);

        /// <summary>
        /// A <see cref="Type"/> representing <see cref="JsonValue"/>.
        /// </summary>
        public static readonly Type JsonValueType = typeof(JsonValue);

        /// <summary>
        /// HTTP X-Requested-With header field name
        /// </summary>
        public const string HttpRequestedWithHeader = @"x-requested-with";

        /// <summary>
        /// HTTP X-Requested-With header field value
        /// </summary>
        public const string HttpRequestedWithHeaderValue = @"xmlhttprequest";

        /// <summary>
        /// JSON literal for 'null'
        /// </summary>
        public const string JsonNullLiteral = "null";

        /// <summary>
        /// HTTP Host header field name
        /// </summary>
        public const string HttpHostHeader = "Host";

        /// <summary>
        /// HTTP Version token
        /// </summary>
        public const string HttpVersionToken = "HTTP";

        // This list should be kept in sync with the list of headers supported by HttpContentHeaders
        // TODO: CSDMAIN 231195 -- Change hard-coded list of HttpContentHeaders to dynamic list provided by DCR #225156
        private static readonly HashSet<string> httpContentHeaders = new HashSet<string>()
        {
            "Allow", 
            "Content-Disposition", 
            "Content-Encoding", 
            "Content-Language", 
            "Content-Length",
            "Content-Location", 
            "Content-MD5",
            "Content-Range", 
            "Content-Type", 
            "Expires", 
            "Last-Modified", 
        };

        /// <summary>
        /// Gets the HTTP headers that are associated with <see cref="HttpContentHeaders"/>.
        /// </summary>
        public static HashSet<string> HttpContentHeaders
        {
            get
            {
                return FormattingUtilities.httpContentHeaders;
            }
        }

        /// <summary>
        /// Determines whether <paramref name="type"/> is a <see cref="JsonValue"/> type.
        /// </summary>
        /// <param name="type">The type to test.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="type"/> is a <see cref="JsonValue"/> type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsJsonValueType(Type type)
        {
            return JsonValueType.IsAssignableFrom(type);
        }

        /// <summary>
        /// Creates an empty <see cref="HttpContentHeaders"/> instance. The only way is to get it from a dummy 
        /// <see cref="HttpContent"/> instance.
        /// </summary>
        /// <returns>The created instance.</returns>
        public static HttpContentHeaders CreateEmptyContentHeaders()
        {
            HttpContent tempContent = null;
            HttpContentHeaders contentHeaders = null;
            try
            {
                tempContent = new StringContent(string.Empty);
                contentHeaders = tempContent.Headers;
                contentHeaders.Clear();
            }
            finally
            {
                // We can dispose the content without touching the headers
                if (tempContent != null)
                {
                    tempContent.Dispose();
                }
            }

            return contentHeaders;
        }

        /// <summary>
        /// Ensure the actual collection is identical to the expected one
        /// </summary>
        /// <param name="actual">The actual collection of the instance</param>
        /// <param name="expected">The expected collection of the instance</param>
        /// <returns>Returns true if they are identical</returns>
        public static bool ValidateCollection(Collection<MediaTypeHeaderValue> actual, MediaTypeHeaderValue[] expected)
        {
            if (actual.Count != expected.Length)
            {
                return false;
            }

            foreach (MediaTypeHeaderValue value in expected)
            {
                if (!actual.Contains(value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Remove bounding quotes on a token if present
        /// </summary>
        /// <param name="token">Token to unquote.</param>
        /// <returns>Unquoted token.</returns>
        public static string UnquoteToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return token;
            }

            if (token.StartsWith("\"", StringComparison.Ordinal) && token.EndsWith("\"", StringComparison.Ordinal) && token.Length > 1)
            {
                return token.Substring(1, token.Length - 2);
            }

            return token;
        }
    }
}
