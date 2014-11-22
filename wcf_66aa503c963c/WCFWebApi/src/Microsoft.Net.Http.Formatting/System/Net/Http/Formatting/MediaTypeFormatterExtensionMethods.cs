﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace System.Net.Http.Formatting
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http.Headers;

    /// <summary>
    /// Extension methods to provide convenience in adding <see cref="MediaTypeMapping"/>
    /// items to a <see cref="MediaTypeFormatter"/>.
    /// </summary>
    public static class MediaTypeFormatterExtensionMethods
    {
        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with <see cref="Uri"/>s containing
        /// a specific query parameter and value.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="QueryStringMapping"/> item.</param>
        /// <param name="queryStringParameterName">The name of the query parameter.</param>
        /// <param name="queryStringParameterValue">The value assigned to that query parameter.</param>
        /// <param name="mediaType">The <see cref="MediaTypeHeaderValue"/> to associate 
        /// with a <see cref="Uri"/> containing a query string matching <paramref name="queryStringParameterName"/> 
        /// and <paramref name="queryStringParameterValue"/>.</param>
        public static void AddQueryStringMapping(
                                this MediaTypeFormatter formatter,
                                string queryStringParameterName,
                                string queryStringParameterValue,
                                MediaTypeHeaderValue mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            QueryStringMapping mapping = new QueryStringMapping(queryStringParameterName, queryStringParameterValue, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with <see cref="Uri"/>s containing
        /// a specific query parameter and value.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="QueryStringMapping"/> item.</param>
        /// <param name="queryStringParameterName">The name of the query parameter.</param>
        /// <param name="queryStringParameterValue">The value assigned to that query parameter.</param>
        /// <param name="mediaType">The media type to associate 
        /// with a <see cref="Uri"/> containing a query string matching <paramref name="queryStringParameterName"/>
        /// and <paramref name="queryStringParameterValue"/>.</param>
        public static void AddQueryStringMapping(
                                this MediaTypeFormatter formatter,
                                string queryStringParameterName,
                                string queryStringParameterValue,
                                string mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            QueryStringMapping mapping = new QueryStringMapping(queryStringParameterName, queryStringParameterValue, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with <see cref="Uri"/>s ending with
        /// the given <paramref name="uriPathExtension"/>.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="UriPathExtensionMapping"/> item.</param>
        /// <param name="uriPathExtension">The string of the <see cref="Uri"/> path extension.</param>
        /// <param name="mediaType">The <see cref="MediaTypeHeaderValue"/> to associate with <see cref="Uri"/>s
        /// ending with <paramref name="uriPathExtension"/>.</param>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", Justification = "There is no meaningful System.Uri representation for a path suffix such as '.xml'")]
        public static void AddUriPathExtensionMapping(
                                this MediaTypeFormatter formatter,
                                string uriPathExtension,
                                MediaTypeHeaderValue mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            UriPathExtensionMapping mapping = new UriPathExtensionMapping(uriPathExtension, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with <see cref="Uri"/>s ending with
        /// the given <paramref name="uriPathExtension"/>.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="UriPathExtensionMapping"/> item.</param>
        /// <param name="uriPathExtension">The string of the <see cref="Uri"/> path extension.</param>
        /// <param name="mediaType">The string media type to associate with <see cref="Uri"/>s
        /// ending with <paramref name="uriPathExtension"/>.</param>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", Justification = "There is no meaningful System.Uri representation for a path suffix such as '.xml'")]
        public static void AddUriPathExtensionMapping(this MediaTypeFormatter formatter, string uriPathExtension, string mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            UriPathExtensionMapping mapping = new UriPathExtensionMapping(uriPathExtension, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with requests or responses containing
        /// <paramref name="mediaRange"/> in the content headers.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="MediaRangeMapping"/> item.</param>
        /// <param name="mediaRange">The media range that will appear in the content headers.</param>
        /// <param name="mediaType">The media type to associate with that <paramref name="mediaRange"/>.</param>
        public static void AddMediaRangeMapping(this MediaTypeFormatter formatter, string mediaRange, string mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            MediaRangeMapping mapping = new MediaRangeMapping(mediaRange, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with requests or responses containing
        /// <paramref name="mediaRange"/> in the content headers.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="MediaRangeMapping"/> item.</param>
        /// <param name="mediaRange">The media range that will appear in the content headers.</param>
        /// <param name="mediaType">The media type to associate with that <paramref name="mediaRange"/>.</param>
        public static void AddMediaRangeMapping(
                                this MediaTypeFormatter formatter,
                                MediaTypeHeaderValue mediaRange,
                                MediaTypeHeaderValue mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            MediaRangeMapping mapping = new MediaRangeMapping(mediaRange, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with a specific HTTP request header field
        /// with a specific value.
        /// </summary>
        /// <remarks><see cref="RequestHeaderMapping"/> checks header fields associated with <see cref="M:HttpRequestMessage.Headers"/> for a match. It does
        /// not check header fields associated with <see cref="M:HttpResponseMessage.Headers"/> or <see cref="M:HttpContent.Headers"/> instances.</remarks>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="MediaRangeMapping"/> item.</param>
        /// <param name="headerName">Name of the header to match.</param>
        /// <param name="headerValue">The header value to match.</param>
        /// <param name="valueComparison">The <see cref="StringComparison"/> to use when matching <paramref name="headerValue"/>.</param>
        /// <param name="isValueSubstring">if set to <c>true</c> then <paramref name="headerValue"/> is 
        /// considered a match if it matches a substring of the actual header value.</param>
        /// <param name="mediaType">The <see cref="MediaTypeHeaderValue"/> to associate 
        /// with a <see cref="M:HttpRequestMessage.Header"/> entry with a name matching <paramref name="headerName"/>
        /// and a value matching <paramref name="headerValue"/>.</param>
        public static void AddRequestHeaderMapping(
            this MediaTypeFormatter formatter,
            string headerName,
            string headerValue,
            StringComparison valueComparison, 
            bool isValueSubstring, 
            MediaTypeHeaderValue mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            RequestHeaderMapping mapping = new RequestHeaderMapping(headerName, headerValue, valueComparison, isValueSubstring, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with a specific HTTP request header field
        /// with a specific value.
        /// </summary>
        /// <remarks><see cref="RequestHeaderMapping"/> checks header fields associated with <see cref="M:HttpRequestMessage.Headers"/> for a match. It does
        /// not check header fields associated with <see cref="M:HttpResponseMessage.Headers"/> or <see cref="M:HttpContent.Headers"/> instances.</remarks>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="MediaRangeMapping"/> item.</param>
        /// <param name="headerName">Name of the header to match.</param>
        /// <param name="headerValue">The header value to match.</param>
        /// <param name="valueComparison">The <see cref="StringComparison"/> to use when matching <paramref name="headerValue"/>.</param>
        /// <param name="isValueSubstring">if set to <c>true</c> then <paramref name="headerValue"/> is 
        /// considered a match if it matches a substring of the actual header value.</param>
        /// <param name="mediaType">The media type to associate 
        /// with a <see cref="M:HttpRequestMessage.Header"/> entry with a name matching <paramref name="headerName"/>
        /// and a value matching <paramref name="headerValue"/>.</param>
        public static void AddRequestHeaderMapping(
            this MediaTypeFormatter formatter,
            string headerName,
            string headerValue,
            StringComparison valueComparison,
            bool isValueSubstring,
            string mediaType)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            RequestHeaderMapping mapping = new RequestHeaderMapping(headerName, headerValue, valueComparison, isValueSubstring, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }
    }
}