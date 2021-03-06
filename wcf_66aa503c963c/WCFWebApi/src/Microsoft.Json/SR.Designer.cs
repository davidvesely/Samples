//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Json {
    
    
    internal partial class SR {
        
        static System.Resources.ResourceManager resourceManager;
        
        static System.Globalization.CultureInfo resourceCulture;
        
        private SR() {
        }
        
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceManager, null)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("System.Json.SR", typeof(SR).Assembly);
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
        
        /// <summary>Gets localized string like: The input source is not correctly formatted.</summary>
        internal static string IncorrectJsonFormat {
            get {
                return ResourceManager.GetString("IncorrectJsonFormat", Culture);
            }
        }
        
        /// <summary>Gets localized string like: An empty string cannot be parsed as JSON.</summary>
        internal static string JsonStringCannotBeEmpty {
            get {
                return ResourceManager.GetString("JsonStringCannotBeEmpty", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The algorithm header (alg) is required. If the JSON web token is not signed, the algorithm header should be set to "none".</summary>
        internal static string JsonWebToken_AlgorithmHeaderIsRequired {
            get {
                return ResourceManager.GetString("JsonWebToken_AlgorithmHeaderIsRequired", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The cryptographic algorithm is not defined or is invalid. Use the value "none" to leave the JSON web token unsigned.</summary>
        internal static string JsonWebToken_InvalidAlgorithm {
            get {
                return ResourceManager.GetString("JsonWebToken_InvalidAlgorithm", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The provided key or certificate cannot be used to verify the signature of the JSON web token.</summary>
        internal static string JsonWebToken_InvalidKeyOrCertificateForAuthentication {
            get {
                return ResourceManager.GetString("JsonWebToken_InvalidKeyOrCertificateForAuthentication", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The provided key or certificate cannot be used to sign the JSON web token.</summary>
        internal static string JsonWebToken_InvalidKeyOrCertificateForSigning {
            get {
                return ResourceManager.GetString("JsonWebToken_InvalidKeyOrCertificateForSigning", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The JSON Web Token failed authentication. The signature in the token has a different value than the signature computed with the authenticating key.</summary>
        internal static string JsonWebToken_InvalidSignature {
            get {
                return ResourceManager.GetString("JsonWebToken_InvalidSignature", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Cannot parse the JSON Web Token. The format is invalid.</summary>
        internal static string JsonWebToken_InvalidTokenFormat {
            get {
                return ResourceManager.GetString("JsonWebToken_InvalidTokenFormat", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The JSON web token needs to be signed. To leave the token unsigned, set the Algorithm property to "none". Otherwise, call the Sign method to sign the token.</summary>
        internal static string JsonWebToken_SignatureRequired {
            get {
                return ResourceManager.GetString("JsonWebToken_SignatureRequired", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Null index or multidimensional indexing is not supported by this indexer; use 'System.Int32' or 'System.String' for array and object indexing respectively.</summary>
        internal static string NonSingleNonNullIndexNotSupported {
            get {
                return ResourceManager.GetString("NonSingleNonNullIndexNotSupported", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Query string name cannot be null.</summary>
        internal static string QueryStringNameShouldNotNull {
            get {
                return ResourceManager.GetString("QueryStringNameShouldNotNull", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Object type not supported.</summary>
        internal static string TypeNotSupported {
            get {
                return ResourceManager.GetString("TypeNotSupported", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Operation not supported on JsonValue instances of 'JsonType.Default' type.</summary>
        internal static string UseOfDefaultNotAllowed {
            get {
                return ResourceManager.GetString("UseOfDefaultNotAllowed", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Unable to cast object of type '{0}' to type '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Unable to cast object of type '{0}' to type '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Unable to cast object of type '{0}' to type '{1}'.</param>
        internal static string CannotCastJsonValue(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("CannotCastJsonValue", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: CannotReadAsType=Cannot read '{0}' as '{1}' type.</summary>
        /// <param name="param0">Parameter 0 for string: CannotReadAsType=Cannot read '{0}' as '{1}' type.</param>
        /// <param name="param1">Parameter 1 for string: CannotReadAsType=Cannot read '{0}' as '{1}' type.</param>
        internal static string CannotReadAsType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("CannotReadAsType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Cannot read JsonPrimitive value '{0}' as '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Cannot read JsonPrimitive value '{0}' as '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Cannot read JsonPrimitive value '{0}' as '{1}'.</param>
        internal static string CannotReadPrimitiveAsType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("CannotReadPrimitiveAsType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: '{0}' does not contain a definition for property '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: '{0}' does not contain a definition for property '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: '{0}' does not contain a definition for property '{1}'.</param>
        internal static string DynamicPropertyNotDefined(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("DynamicPropertyNotDefined", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Mismatched types at node '{0}'.</summary>
        /// <param name="param0">Parameter 0 for string: Mismatched types at node '{0}'.</param>
        internal static string FormUrlEncodedMismatchingTypes(object param0) {
            return string.Format(Culture, ResourceManager.GetString("FormUrlEncodedMismatchingTypes", Culture), param0);
        }
        
        /// <summary>Gets localized string like: '{0}' type indexer is not supported on JsonValue of 'JsonType.{1}' type.</summary>
        /// <param name="param0">Parameter 0 for string: '{0}' type indexer is not supported on JsonValue of 'JsonType.{1}' type.</param>
        /// <param name="param1">Parameter 1 for string: '{0}' type indexer is not supported on JsonValue of 'JsonType.{1}' type.</param>
        internal static string IndexerNotSupportedOnJsonType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("IndexerNotSupportedOnJsonType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid array at node '{0}'.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid array at node '{0}'.</param>
        internal static string InvalidArrayInsert(object param0) {
            return string.Format(Culture, ResourceManager.GetString("InvalidArrayInsert", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Cannot convert null to '{0}' because it is a non-nullable value type.</summary>
        /// <param name="param0">Parameter 0 for string: Cannot convert null to '{0}' because it is a non-nullable value type.</param>
        internal static string InvalidCastNonNullable(object param0) {
            return string.Format(Culture, ResourceManager.GetString("InvalidCastNonNullable", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Cannot cast JsonPrimitive value '{0}' as '{1}'. It is not in a valid date format.</summary>
        /// <param name="param0">Parameter 0 for string: Cannot cast JsonPrimitive value '{0}' as '{1}'. It is not in a valid date format.</param>
        /// <param name="param1">Parameter 1 for string: Cannot cast JsonPrimitive value '{0}' as '{1}'. It is not in a valid date format.</param>
        internal static string InvalidDateFormat(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("InvalidDateFormat", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid '{0}' index type; only 'System.String' and non-negative 'System.Int32' types are supported.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid '{0}' index type; only 'System.String' and non-negative 'System.Int32' types are supported.</param>
        internal static string InvalidIndexType(object param0) {
            return string.Format(Culture, ResourceManager.GetString("InvalidIndexType", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Invalid JSON primitive: {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid JSON primitive: {0}.</param>
        internal static string InvalidJsonPrimitive(object param0) {
            return string.Format(Culture, ResourceManager.GetString("InvalidJsonPrimitive", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Cannot cast '{0}' value '{1}.{2}' as a type of '{3}'. The provided string is not a valid relative or absolute '{3}'.</summary>
        /// <param name="param0">Parameter 0 for string: Cannot cast '{0}' value '{1}.{2}' as a type of '{3}'. The provided string is not a valid relative or absolute '{3}'.</param>
        /// <param name="param1">Parameter 1 for string: Cannot cast '{0}' value '{1}.{2}' as a type of '{3}'. The provided string is not a valid relative or absolute '{3}'.</param>
        /// <param name="param2">Parameter 2 for string: Cannot cast '{0}' value '{1}.{2}' as a type of '{3}'. The provided string is not a valid relative or absolute '{3}'.</param>
        /// <param name="param3">Parameter 3 for string: Cannot cast '{0}' value '{1}.{2}' as a type of '{3}'. The provided string is not a valid relative or absolute '{3}'.</param>
        internal static string InvalidUriFormat(object param0, object param1, object param2, object param3) {
            return string.Format(Culture, ResourceManager.GetString("InvalidUriFormat", Culture), param0, param1, param2, param3);
        }
        
        /// <summary>Gets localized string like: Traditional style array without '[]' is not supported with nested object at location {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Traditional style array without '[]' is not supported with nested object at location {0}.</param>
        internal static string JQuery13CompatModeNotSupportNestedJson(object param0) {
            return string.Format(Culture, ResourceManager.GetString("JQuery13CompatModeNotSupportNestedJson", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The maximum read depth ({0}) has been exceeded because the form url-encoded data being read has more levels of nesting than is allowed.</summary>
        /// <param name="param0">Parameter 0 for string: The maximum read depth ({0}) has been exceeded because the form url-encoded data being read has more levels of nesting than is allowed.</param>
        internal static string MaxDepthExceeded(object param0) {
            return string.Format(Culture, ResourceManager.GetString("MaxDepthExceeded", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The parameter must be greater than {0}.</summary>
        /// <param name="param0">Parameter 0 for string: The parameter must be greater than {0}.</param>
        internal static string MinParameterSize(object param0) {
            return string.Format(Culture, ResourceManager.GetString("MinParameterSize", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Nested bracket is not valid for '{0}' data at position {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Nested bracket is not valid for '{0}' data at position {1}.</param>
        /// <param name="param1">Parameter 1 for string: Nested bracket is not valid for '{0}' data at position {1}.</param>
        internal static string NestedBracketNotValid(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("NestedBracketNotValid", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Operation not supported on JsonValue instance of 'JsonType.{0}' type.</summary>
        /// <param name="param0">Parameter 0 for string: Operation not supported on JsonValue instance of 'JsonType.{0}' type.</param>
        internal static string OperationNotSupportedOnJsonType(object param0) {
            return string.Format(Culture, ResourceManager.GetString("OperationNotSupportedOnJsonType", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Operation '{0}' cannot be applied on operands of type '{1}' and '{2}'.</summary>
        /// <param name="param0">Parameter 0 for string: Operation '{0}' cannot be applied on operands of type '{1}' and '{2}'.</param>
        /// <param name="param1">Parameter 1 for string: Operation '{0}' cannot be applied on operands of type '{1}' and '{2}'.</param>
        /// <param name="param2">Parameter 2 for string: Operation '{0}' cannot be applied on operands of type '{1}' and '{2}'.</param>
        internal static string OperatorNotAllowedOnOperands(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("OperatorNotAllowedOnOperands", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: Operation '{0}' is not defined for JsonValue instances of JsonType '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Operation '{0}' is not defined for JsonValue instances of JsonType '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Operation '{0}' is not defined for JsonValue instances of JsonType '{1}'.</param>
        internal static string OperatorNotDefinedForJsonType(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("OperatorNotDefinedForJsonType", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Cannot cast JsonPrimitive value '{0}' as '{1}'. The value is either too large or too small for the specified CLR type.</summary>
        /// <param name="param0">Parameter 0 for string: Cannot cast JsonPrimitive value '{0}' as '{1}'. The value is either too large or too small for the specified CLR type.</param>
        /// <param name="param1">Parameter 1 for string: Cannot cast JsonPrimitive value '{0}' as '{1}'. The value is either too large or too small for the specified CLR type.</param>
        internal static string OverflowReadAs(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("OverflowReadAs", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: There is an unmatched opened bracket for the '{0}' at position {1}.</summary>
        /// <param name="param0">Parameter 0 for string: There is an unmatched opened bracket for the '{0}' at position {1}.</param>
        /// <param name="param1">Parameter 1 for string: There is an unmatched opened bracket for the '{0}' at position {1}.</param>
        internal static string UnMatchedBracketNotValid(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("UnMatchedBracketNotValid", Culture), param0, param1);
        }
    }
}

