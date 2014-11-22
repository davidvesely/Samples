//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Net.Http {
    
    
    internal partial class SR {
        
        static System.Resources.ResourceManager resourceManager;
        
        static System.Globalization.CultureInfo resourceCulture;
        
        private SR() {
        }
        
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceManager, null)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("System.Net.Http.SR", typeof(SR).Assembly);
                    resourceManager = temp;
                }
                return resourceManager;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("StrictResXFileCodeGenerator", "4.0.0.0")]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>Gets localized string like: Error reading HTML form URL-encoded data stream.</summary>
        internal static string ErrorReadingFormUrlEncodedStream {
            get {
                return ResourceManager.GetString("ErrorReadingFormUrlEncodedStream", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Error reading HTTP message.</summary>
        internal static string HttpMessageErrorReading {
            get {
                return ResourceManager.GetString("HttpMessageErrorReading", Culture);
            }
        }
        
        /// <summary>Gets localized string like: HTTP Request URI cannot be an empty string.</summary>
        internal static string HttpMessageParserEmptyUri {
            get {
                return ResourceManager.GetString("HttpMessageParserEmptyUri", Culture);
            }
        }
        
        /// <summary>Gets localized string like: MIME multipart boundary cannot end with an empty space.</summary>
        internal static string MimeMultipartParserBadBoundary {
            get {
                return ResourceManager.GetString("MimeMultipartParserBadBoundary", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Could not determine a valid local file name for the multipart body part.</summary>
        internal static string MultipartStreamProviderInvalidLocalFileName {
            get {
                return ResourceManager.GetString("MultipartStreamProviderInvalidLocalFileName", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The parameter must be a non-zero positive integer.</summary>
        internal static string NonZeroParameterSize {
            get {
                return ResourceManager.GetString("NonZeroParameterSize", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Error reading MIME multipart body part.</summary>
        internal static string ReadAsMimeMultipartErrorReading {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartErrorReading", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Error writing MIME multipart body part to output stream.</summary>
        internal static string ReadAsMimeMultipartErrorWriting {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartErrorWriting", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Unexpected end of MIME multipart stream. MIME multipart message is not complete.</summary>
        internal static string ReadAsMimeMultipartUnexpectedTermination {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartUnexpectedTermination", Culture);
            }
        }
        
        /// <summary>Gets localized string like: 'undefined'</summary>
        internal static string UndefinedMediaType {
            get {
                return ResourceManager.GetString("UndefinedMediaType", Culture);
            }
        }
        
        /// <summary>Gets localized string like: A null '{0}' is not valid.</summary>
        /// <param name="param0">Parameter 0 for string: A null '{0}' is not valid.</param>
        internal static string CannotHaveNullInList(object param0) {
            return string.Format(Culture, ResourceManager.GetString("CannotHaveNullInList", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The '{0}' of '{1}' cannot be used as a supported media type because it is a media range.</summary>
        /// <param name="param0">Parameter 0 for string: The '{0}' of '{1}' cannot be used as a supported media type because it is a media range.</param>
        /// <param name="param1">Parameter 1 for string: The '{0}' of '{1}' cannot be used as a supported media type because it is a media range.</param>
        internal static string CannotUseMediaRangeForSupportedMediaType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("CannotUseMediaRangeForSupportedMediaType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The '{0}' type cannot accept a null value for the value type '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: The '{0}' type cannot accept a null value for the value type '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: The '{0}' type cannot accept a null value for the value type '{1}'.</param>
        internal static string CannotUseNullValueType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("CannotUseNullValueType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The type '{0}' cannot be used as the type parameter for '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: The type '{0}' cannot be used as the type parameter for '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: The type '{0}' cannot be used as the type parameter for '{1}'.</param>
        internal static string CannotUseThisParameterType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("CannotUseThisParameterType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: '{0}' did not contain a valid file name property: '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: '{0}' did not contain a valid file name property: '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: '{0}' did not contain a valid file name property: '{1}'.</param>
        internal static string ContentDispositionInvalidFileName(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ContentDispositionInvalidFileName", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Error parsing HTML form URL-encoded data, byte {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Error parsing HTML form URL-encoded data, byte {0}.</param>
        internal static string FormUrlEncodedParseError(object param0) {
            return string.Format(Culture, ResourceManager.GetString("FormUrlEncodedParseError", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Invalid HTTP status code: '{0}'. The status code must be between {1} and {2}.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid HTTP status code: '{0}'. The status code must be between {1} and {2}.</param>
        /// <param name="param1">Parameter 1 for string: Invalid HTTP status code: '{0}'. The status code must be between {1} and {2}.</param>
        /// <param name="param2">Parameter 2 for string: Invalid HTTP status code: '{0}'. The status code must be between {1} and {2}.</param>
        internal static string HttpInvalidStatusCode(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("HttpInvalidStatusCode", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: Invalid HTTP version: '{0}'. The version must start with the characters '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid HTTP version: '{0}'. The version must start with the characters '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Invalid HTTP version: '{0}'. The version must start with the characters '{1}'.</param>
        internal static string HttpInvalidVersion(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("HttpInvalidVersion", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The '{0}' of the '{1}' has already been read.</summary>
        /// <param name="param0">Parameter 0 for string: The '{0}' of the '{1}' has already been read.</param>
        /// <param name="param1">Parameter 1 for string: The '{0}' of the '{1}' has already been read.</param>
        internal static string HttpMessageContentAlreadyRead(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("HttpMessageContentAlreadyRead", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The '{0}' must be seekable in order to create an '{1}' instance containing an entity body.  </summary>
        /// <param name="param0">Parameter 0 for string: The '{0}' must be seekable in order to create an '{1}' instance containing an entity body.  </param>
        /// <param name="param1">Parameter 1 for string: The '{0}' must be seekable in order to create an '{1}' instance containing an entity body.  </param>
        internal static string HttpMessageContentStreamMustBeSeekable(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("HttpMessageContentStreamMustBeSeekable", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid '{0}' instance provided. It does not have a content type header with a value of '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid '{0}' instance provided. It does not have a content type header with a value of '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Invalid '{0}' instance provided. It does not have a content type header with a value of '{1}'.</param>
        internal static string HttpMessageInvalidMediaType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("HttpMessageInvalidMediaType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Error parsing HTTP message header byte {0} of message {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Error parsing HTTP message header byte {0} of message {1}.</param>
        /// <param name="param1">Parameter 1 for string: Error parsing HTTP message header byte {0} of message {1}.</param>
        internal static string HttpMessageParserError(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("HttpMessageParserError", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: An invalid number of '{0}' header fields were present in the HTTP Request. It must contain exactly one '{0}' header field but found {1}.</summary>
        /// <param name="param0">Parameter 0 for string: An invalid number of '{0}' header fields were present in the HTTP Request. It must contain exactly one '{0}' header field but found {1}.</param>
        /// <param name="param1">Parameter 1 for string: An invalid number of '{0}' header fields were present in the HTTP Request. It must contain exactly one '{0}' header field but found {1}.</param>
        internal static string HttpMessageParserInvalidHostCount(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("HttpMessageParserInvalidHostCount", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid URI scheme: '{0}'. The URI scheme must be a valid '{1}' scheme.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid URI scheme: '{0}'. The URI scheme must be a valid '{1}' scheme.</param>
        /// <param name="param1">Parameter 1 for string: Invalid URI scheme: '{0}'. The URI scheme must be a valid '{1}' scheme.</param>
        internal static string HttpMessageParserInvalidUriScheme(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("HttpMessageParserInvalidUriScheme", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: HTTP messages containing an entity body must include a valid '{0}' header field.</summary>
        /// <param name="param0">Parameter 0 for string: HTTP messages containing an entity body must include a valid '{0}' header field.</param>
        internal static string HttpMessageParserMissingContentLength(object param0) {
            return string.Format(Culture, ResourceManager.GetString("HttpMessageParserMissingContentLength", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The value '{0}' is not a valid media range.</summary>
        /// <param name="param0">Parameter 0 for string: The value '{0}' is not a valid media range.</param>
        internal static string InvalidMediaRange(object param0) {
            return string.Format(Culture, ResourceManager.GetString("InvalidMediaRange", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The media type string '{0}' is not a legal '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: The media type string '{0}' is not a legal '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: The media type string '{0}' is not a legal '{1}'.</param>
        internal static string InvalidMediaType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("InvalidMediaType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The media range '{0}' cannot be a supported media type.</summary>
        /// <param name="param0">Parameter 0 for string: The media range '{0}' cannot be a supported media type.</param>
        internal static string MediaTypeCanNotBeMediaRange(object param0) {
            return string.Format(Culture, ResourceManager.GetString("MediaTypeCanNotBeMediaRange", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The '{0}' media type formatter does not support writing content.</summary>
        /// <param name="param0">Parameter 0 for string: The '{0}' media type formatter does not support writing content.</param>
        internal static string MediaTypeFormatterWriteUnsupported(object param0) {
            return string.Format(Culture, ResourceManager.GetString("MediaTypeFormatterWriteUnsupported", Culture), param0);
        }
        
        /// <summary>Gets localized string like: '{0}' must be set before '{1}' can serialize its content.</summary>
        /// <param name="param0">Parameter 0 for string: '{0}' must be set before '{1}' can serialize its content.</param>
        /// <param name="param1">Parameter 1 for string: '{0}' must be set before '{1}' can serialize its content.</param>
        internal static string MediaTypeMustBeSetBeforeWrite(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("MediaTypeMustBeSetBeforeWrite", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The parameter must be greater than {0}.</summary>
        /// <param name="param0">Parameter 0 for string: The parameter must be greater than {0}.</param>
        internal static string MinParameterSize(object param0) {
            return string.Format(Culture, ResourceManager.GetString("MinParameterSize", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Did not find required '{0}' header field in MIME multipart body part.</summary>
        /// <param name="param0">Parameter 0 for string: Did not find required '{0}' header field in MIME multipart body part.</param>
        internal static string MultipartFormDataStreamProviderNoContentDisposition(object param0) {
            return string.Format(Culture, ResourceManager.GetString("MultipartFormDataStreamProviderNoContentDisposition", Culture), param0);
        }
        
        /// <summary>Gets localized string like: A non-null request URI must be provided to determine if a '{0}' matches a given request or response message.</summary>
        /// <param name="param0">Parameter 0 for string: A non-null request URI must be provided to determine if a '{0}' matches a given request or response message.</param>
        internal static string NonNullUriRequiredForMediaTypeMapping(object param0) {
            return string.Format(Culture, ResourceManager.GetString("NonNullUriRequiredForMediaTypeMapping", Culture), param0);
        }
        
        /// <summary>Gets localized string like: No '{0}' is available to read an object of type '{1}' with the media type '{2}'.</summary>
        /// <param name="param0">Parameter 0 for string: No '{0}' is available to read an object of type '{1}' with the media type '{2}'.</param>
        /// <param name="param1">Parameter 1 for string: No '{0}' is available to read an object of type '{1}' with the media type '{2}'.</param>
        /// <param name="param2">Parameter 2 for string: No '{0}' is available to read an object of type '{1}' with the media type '{2}'.</param>
        internal static string NoReadSerializerAvailable(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("NoReadSerializerAvailable", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: No '{0}' is available to write an object of type '{1}' with the media type '{2}'.</summary>
        /// <param name="param0">Parameter 0 for string: No '{0}' is available to write an object of type '{1}' with the media type '{2}'.</param>
        /// <param name="param1">Parameter 1 for string: No '{0}' is available to write an object of type '{1}' with the media type '{2}'.</param>
        /// <param name="param2">Parameter 2 for string: No '{0}' is available to write an object of type '{1}' with the media type '{2}'.</param>
        internal static string NoWriteSerializerAvailable(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("NoWriteSerializerAvailable", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: An object of type '{0}' cannot be used with a type parameter of '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: An object of type '{0}' cannot be used with a type parameter of '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: An object of type '{0}' cannot be used with a type parameter of '{1}'.</param>
        internal static string ObjectAndTypeDisagree(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ObjectAndTypeDisagree", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid '{0}' instance provided. It does not have a '{1}' content-type header with a '{2}' parameter.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid '{0}' instance provided. It does not have a '{1}' content-type header with a '{2}' parameter.</param>
        /// <param name="param1">Parameter 1 for string: Invalid '{0}' instance provided. It does not have a '{1}' content-type header with a '{2}' parameter.</param>
        /// <param name="param2">Parameter 2 for string: Invalid '{0}' instance provided. It does not have a '{1}' content-type header with a '{2}' parameter.</param>
        internal static string ReadAsMimeMultipartArgumentNoBoundary(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartArgumentNoBoundary", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: Invalid '{0}' instance provided. It does not have a content-type header value. '{0}' instances must have a content-type header starting with '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid '{0}' instance provided. It does not have a content-type header value. '{0}' instances must have a content-type header starting with '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Invalid '{0}' instance provided. It does not have a content-type header value. '{0}' instances must have a content-type header starting with '{1}'.</param>
        internal static string ReadAsMimeMultipartArgumentNoContentType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartArgumentNoContentType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid '{0}' instance provided. It does not have a content type header starting with '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid '{0}' instance provided. It does not have a content type header starting with '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Invalid '{0}' instance provided. It does not have a content type header starting with '{1}'.</param>
        internal static string ReadAsMimeMultipartArgumentNoMultipart(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartArgumentNoMultipart", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Error parsing MIME multipart body part header byte {0} of data segment {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Error parsing MIME multipart body part header byte {0} of data segment {1}.</param>
        /// <param name="param1">Parameter 1 for string: Error parsing MIME multipart body part header byte {0} of data segment {1}.</param>
        internal static string ReadAsMimeMultipartHeaderParseError(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartHeaderParseError", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Error parsing MIME multipart message byte {0} of data segment {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Error parsing MIME multipart message byte {0} of data segment {1}.</param>
        /// <param name="param1">Parameter 1 for string: Error parsing MIME multipart message byte {0} of data segment {1}.</param>
        internal static string ReadAsMimeMultipartParseError(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartParseError", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The stream provider of type '{0}' threw an exception.</summary>
        /// <param name="param0">Parameter 0 for string: The stream provider of type '{0}' threw an exception.</param>
        internal static string ReadAsMimeMultipartStreamProviderException(object param0) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartStreamProviderException", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The stream provider of type '{0}' returned null. It must return a writable '{1}' instance.</summary>
        /// <param name="param0">Parameter 0 for string: The stream provider of type '{0}' returned null. It must return a writable '{1}' instance.</param>
        /// <param name="param1">Parameter 1 for string: The stream provider of type '{0}' returned null. It must return a writable '{1}' instance.</param>
        internal static string ReadAsMimeMultipartStreamProviderNull(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartStreamProviderNull", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The stream provider of type '{0}' returned a read-only stream. It must return a writable '{1}' instance.</summary>
        /// <param name="param0">Parameter 0 for string: The stream provider of type '{0}' returned a read-only stream. It must return a writable '{1}' instance.</param>
        /// <param name="param1">Parameter 1 for string: The stream provider of type '{0}' returned a read-only stream. It must return a writable '{1}' instance.</param>
        internal static string ReadAsMimeMultipartStreamProviderReadOnly(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("ReadAsMimeMultipartStreamProviderReadOnly", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The '{0}' '{1}' parameter must have a reference to a '{2}' via the '{3}' property.</summary>
        /// <param name="param0">Parameter 0 for string: The '{0}' '{1}' parameter must have a reference to a '{2}' via the '{3}' property.</param>
        /// <param name="param1">Parameter 1 for string: The '{0}' '{1}' parameter must have a reference to a '{2}' via the '{3}' property.</param>
        /// <param name="param2">Parameter 2 for string: The '{0}' '{1}' parameter must have a reference to a '{2}' via the '{3}' property.</param>
        /// <param name="param3">Parameter 3 for string: The '{0}' '{1}' parameter must have a reference to a '{2}' via the '{3}' property.</param>
        internal static string ResponseMustReferenceRequest(object param0, object param1, object param2, object param3) {
            return string.Format(Culture, ResourceManager.GetString("ResponseMustReferenceRequest", Culture), param0, param1, param2, param3);
        }
        
        /// <summary>Gets localized string like: The '{0}' serializer cannot serialize the type '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: The '{0}' serializer cannot serialize the type '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: The '{0}' serializer cannot serialize the type '{1}'.</param>
        internal static string SerializerCannotSerializeType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SerializerCannotSerializeType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The character encoding used by '{0}' for writing data must be either '{1}' or '{2}'.'</summary>
        /// <param name="param0">Parameter 0 for string: The character encoding used by '{0}' for writing data must be either '{1}' or '{2}'.'</param>
        /// <param name="param1">Parameter 1 for string: The character encoding used by '{0}' for writing data must be either '{1}' or '{2}'.'</param>
        /// <param name="param2">Parameter 2 for string: The character encoding used by '{0}' for writing data must be either '{1}' or '{2}'.'</param>
        internal static string UnsupportedEncoding(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("UnsupportedEncoding", Culture), param0, param1, param2);
        }
    }
}
