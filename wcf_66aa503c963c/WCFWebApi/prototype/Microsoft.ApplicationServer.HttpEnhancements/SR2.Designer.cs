//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.ApplicationServer.HttpEnhancements {
    
    
    internal partial class SR2 {
        
        static System.Resources.ResourceManager resourceManager;
        
        static System.Globalization.CultureInfo resourceCulture;
        
        private SR2() {
        }
        
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceManager, null)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Microsoft.ApplicationServer.HttpEnhancements.SR2", typeof(SR2).Assembly);
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
        
        /// <summary>Gets localized string like: Access is denied.</summary>
        internal static string AccessDenied {
            get {
                return ResourceManager.GetString("AccessDenied", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The service implementation object was not initialized or is not available.</summary>
        internal static string SFxNoServiceObject {
            get {
                return ResourceManager.GetString("SFxNoServiceObject", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The given Task instance has not yet been started. Task instances must be started before they are returned from operations.</summary>
        internal static string SFxTaskNotStarted {
            get {
                return ResourceManager.GetString("SFxTaskNotStarted", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Attempted to get contract type for {0}, but that type is not a ServiceContract, nor does it inherit a ServiceContract.</summary>
        /// <param name="param0">Parameter 0 for string: Attempted to get contract type for {0}, but that type is not a ServiceContract, nor does it inherit a ServiceContract.</param>
        internal static string AttemptedToGetContractTypeForButThatTypeIs1(object param0) {
            return string.Format(Culture, ResourceManager.GetString("AttemptedToGetContractTypeForButThatTypeIs1", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Couldn't find required attribute of type {0} on {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Couldn't find required attribute of type {0} on {1}.</param>
        /// <param name="param1">Parameter 1 for string: Couldn't find required attribute of type {0} on {1}.</param>
        internal static string couldnTFindRequiredAttributeOfTypeOn2(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("couldnTFindRequiredAttributeOfTypeOn2", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid async Begin method signature for method {0} in ServiceContract type {1}. Your begin method must take an AsyncCallback and an object as the last two arguments and return an IAsyncResult.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid async Begin method signature for method {0} in ServiceContract type {1}. Your begin method must take an AsyncCallback and an object as the last two arguments and return an IAsyncResult.</param>
        /// <param name="param1">Parameter 1 for string: Invalid async Begin method signature for method {0} in ServiceContract type {1}. Your begin method must take an AsyncCallback and an object as the last two arguments and return an IAsyncResult.</param>
        internal static string InvalidAsyncBeginMethodSignatureForMethod2(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("InvalidAsyncBeginMethodSignatureForMethod2", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Invalid async End method signature for method {0} in ServiceContract type {1}. Your end method must take an IAsyncResult as the last argument.</summary>
        /// <param name="param0">Parameter 0 for string: Invalid async End method signature for method {0} in ServiceContract type {1}. Your end method must take an IAsyncResult as the last argument.</param>
        /// <param name="param1">Parameter 1 for string: Invalid async End method signature for method {0} in ServiceContract type {1}. Your end method must take an IAsyncResult as the last argument.</param>
        internal static string InvalidAsyncEndMethodSignatureForMethod2(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("InvalidAsyncEndMethodSignatureForMethod2", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as more than one corresponding method '{2}' was found. When using the async pattern, exactly one end method must be provided. Either remove or rename one or more of the '{2}' methods such that there is just one, or set the AsyncPattern property on method '{0}' to false.</summary>
        /// <param name="param0">Parameter 0 for string: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as more than one corresponding method '{2}' was found. When using the async pattern, exactly one end method must be provided. Either remove or rename one or more of the '{2}' methods such that there is just one, or set the AsyncPattern property on method '{0}' to false.</param>
        /// <param name="param1">Parameter 1 for string: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as more than one corresponding method '{2}' was found. When using the async pattern, exactly one end method must be provided. Either remove or rename one or more of the '{2}' methods such that there is just one, or set the AsyncPattern property on method '{0}' to false.</param>
        /// <param name="param2">Parameter 2 for string: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as more than one corresponding method '{2}' was found. When using the async pattern, exactly one end method must be provided. Either remove or rename one or more of the '{2}' methods such that there is just one, or set the AsyncPattern property on method '{0}' to false.</param>
        internal static string MoreThanOneEndMethodFoundForAsyncBeginMethod3(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("MoreThanOneEndMethodFoundForAsyncBeginMethod3", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as no corresponding method '{2}' could be found. Either provide a method called '{2}' or set the AsyncPattern property on method '{0}' to false.</summary>
        /// <param name="param0">Parameter 0 for string: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as no corresponding method '{2}' could be found. Either provide a method called '{2}' or set the AsyncPattern property on method '{0}' to false.</param>
        /// <param name="param1">Parameter 1 for string: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as no corresponding method '{2}' could be found. Either provide a method called '{2}' or set the AsyncPattern property on method '{0}' to false.</param>
        /// <param name="param2">Parameter 2 for string: OperationContract method '{0}' in type '{1}' does not properly implement the async pattern, as no corresponding method '{2}' could be found. Either provide a method called '{2}' or set the AsyncPattern property on method '{0}' to false.</param>
        internal static string NoEndMethodFoundForAsyncBeginMethod3(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("NoEndMethodFoundForAsyncBeginMethod3", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: The Service with name '{0}' could not be constructed because the application does not have permission to construct the type: both the Type and its default parameter-less constructor must be public.</summary>
        /// <param name="param0">Parameter 0 for string: The Service with name '{0}' could not be constructed because the application does not have permission to construct the type: both the Type and its default parameter-less constructor must be public.</param>
        internal static string PartialTrustServiceCtorNotVisible(object param0) {
            return string.Format(Culture, ResourceManager.GetString("PartialTrustServiceCtorNotVisible", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The Method with name '{1}' in Type '{0}' could not be invoked because the application does not have permission to invoke the method: both the Method and its containing Type must be public.</summary>
        /// <param name="param0">Parameter 0 for string: The Method with name '{1}' in Type '{0}' could not be invoked because the application does not have permission to invoke the method: both the Method and its containing Type must be public.</param>
        /// <param name="param1">Parameter 1 for string: The Method with name '{1}' in Type '{0}' could not be invoked because the application does not have permission to invoke the method: both the Method and its containing Type must be public.</param>
        internal static string PartialTrustServiceMethodNotVisible(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("PartialTrustServiceMethodNotVisible", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The {0} declared on method '{1}' in type '{2}' is invalid. {0}s are only valid on methods that are declared in a type that has ServiceContractAttribute. Either add ServiceContractAttribute to type '{2}' or remove {0} from method '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: The {0} declared on method '{1}' in type '{2}' is invalid. {0}s are only valid on methods that are declared in a type that has ServiceContractAttribute. Either add ServiceContractAttribute to type '{2}' or remove {0} from method '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: The {0} declared on method '{1}' in type '{2}' is invalid. {0}s are only valid on methods that are declared in a type that has ServiceContractAttribute. Either add ServiceContractAttribute to type '{2}' or remove {0} from method '{1}'.</param>
        /// <param name="param2">Parameter 2 for string: The {0} declared on method '{1}' in type '{2}' is invalid. {0}s are only valid on methods that are declared in a type that has ServiceContractAttribute. Either add ServiceContractAttribute to type '{2}' or remove {0} from method '{1}'.</param>
        internal static string ServicesWithoutAServiceContractAttributeCan2(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("ServicesWithoutAServiceContractAttributeCan2", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: Method '{0}' in class '{1}' has bad parameter metadata: a pass-by-reference parameter is marked with the 'in' but not the 'out' parameter mode.</summary>
        /// <param name="param0">Parameter 0 for string: Method '{0}' in class '{1}' has bad parameter metadata: a pass-by-reference parameter is marked with the 'in' but not the 'out' parameter mode.</param>
        /// <param name="param1">Parameter 1 for string: Method '{0}' in class '{1}' has bad parameter metadata: a pass-by-reference parameter is marked with the 'in' but not the 'out' parameter mode.</param>
        internal static string SFxBadByReferenceParameterMetadata(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFxBadByReferenceParameterMetadata", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Method '{0}' in class '{1}' has bad parameter metadata: a pass-by-value parameter is marked with the 'out' parameter mode.</summary>
        /// <param name="param0">Parameter 0 for string: Method '{0}' in class '{1}' has bad parameter metadata: a pass-by-value parameter is marked with the 'out' parameter mode.</param>
        /// <param name="param1">Parameter 1 for string: Method '{0}' in class '{1}' has bad parameter metadata: a pass-by-value parameter is marked with the 'out' parameter mode.</param>
        internal static string SFxBadByValueParameterMetadata(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFxBadByValueParameterMetadata", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Array of type {0} is not supported.</summary>
        /// <param name="param0">Parameter 0 for string: Array of type {0} is not supported.</param>
        internal static string SFxCodeGenArrayTypeIsNotSupported(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxCodeGenArrayTypeIsNotSupported", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Can only store into ArgBuilder or LocalBuilder. Got: {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Can only store into ArgBuilder or LocalBuilder. Got: {0}.</param>
        internal static string SFxCodeGenCanOnlyStoreIntoArgOrLocGot0(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxCodeGenCanOnlyStoreIntoArgOrLocGot0", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Expecting End {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Expecting End {0}.</param>
        internal static string SFxCodeGenExpectingEnd(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxCodeGenExpectingEnd", Culture), param0);
        }
        
        /// <summary>Gets localized string like: {0} is not assignable from {1}.</summary>
        /// <param name="param0">Parameter 0 for string: {0} is not assignable from {1}.</param>
        /// <param name="param1">Parameter 1 for string: {0} is not assignable from {1}.</param>
        internal static string SFxCodeGenIsNotAssignableFrom(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFxCodeGenIsNotAssignableFrom", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: No conversion possible to {0}.</summary>
        /// <param name="param0">Parameter 0 for string: No conversion possible to {0}.</param>
        internal static string SFxCodeGenNoConversionPossibleTo(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxCodeGenNoConversionPossibleTo", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Internal Error: Unrecognized constant type {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Internal Error: Unrecognized constant type {0}.</param>
        internal static string SFxCodeGenUnknownConstantType(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxCodeGenUnknownConstantType", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The service class of type {0} both defines a ServiceContract and inherits a ServiceContract from type {1}. Contract inheritance can only be used among interface types.  If a class is marked with ServiceContractAttribute, it must be the only type in the hierarchy with ServiceContractAttribute.  Consider moving the ServiceContractAttribute on type {1} to a separate interface that type {1} implements.</summary>
        /// <param name="param0">Parameter 0 for string: The service class of type {0} both defines a ServiceContract and inherits a ServiceContract from type {1}. Contract inheritance can only be used among interface types.  If a class is marked with ServiceContractAttribute, it must be the only type in the hierarchy with ServiceContractAttribute.  Consider moving the ServiceContractAttribute on type {1} to a separate interface that type {1} implements.</param>
        /// <param name="param1">Parameter 1 for string: The service class of type {0} both defines a ServiceContract and inherits a ServiceContract from type {1}. Contract inheritance can only be used among interface types.  If a class is marked with ServiceContractAttribute, it must be the only type in the hierarchy with ServiceContractAttribute.  Consider moving the ServiceContractAttribute on type {1} to a separate interface that type {1} implements.</param>
        internal static string SFxContractInheritanceRequiresInterfaces(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFxContractInheritanceRequiresInterfaces", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The service class of type {0} both defines a ServiceContract and inherits a ServiceContract from type {1}. Contract inheritance can only be used among interface types.  If a class is marked with ServiceContractAttribute, then another service class cannot derive from it.</summary>
        /// <param name="param0">Parameter 0 for string: The service class of type {0} both defines a ServiceContract and inherits a ServiceContract from type {1}. Contract inheritance can only be used among interface types.  If a class is marked with ServiceContractAttribute, then another service class cannot derive from it.</param>
        /// <param name="param1">Parameter 1 for string: The service class of type {0} both defines a ServiceContract and inherits a ServiceContract from type {1}. Contract inheritance can only be used among interface types.  If a class is marked with ServiceContractAttribute, then another service class cannot derive from it.</param>
        internal static string SFxContractInheritanceRequiresInterfaces2(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFxContractInheritanceRequiresInterfaces2", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The type or member named '{0}' could not be loaded because it has two incompatible attributes: '{1}' and '{2}'. To fix the problem, remove one of the attributes from the type or member.</summary>
        /// <param name="param0">Parameter 0 for string: The type or member named '{0}' could not be loaded because it has two incompatible attributes: '{1}' and '{2}'. To fix the problem, remove one of the attributes from the type or member.</param>
        /// <param name="param1">Parameter 1 for string: The type or member named '{0}' could not be loaded because it has two incompatible attributes: '{1}' and '{2}'. To fix the problem, remove one of the attributes from the type or member.</param>
        /// <param name="param2">Parameter 2 for string: The type or member named '{0}' could not be loaded because it has two incompatible attributes: '{1}' and '{2}'. To fix the problem, remove one of the attributes from the type or member.</param>
        internal static string SFxDisallowedAttributeCombination(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("SFxDisallowedAttributeCombination", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: An error occurred while loading attribute '{0}' on method '{1}' in type '{2}'.  Please see InnerException for more details.</summary>
        /// <param name="param0">Parameter 0 for string: An error occurred while loading attribute '{0}' on method '{1}' in type '{2}'.  Please see InnerException for more details.</param>
        /// <param name="param1">Parameter 1 for string: An error occurred while loading attribute '{0}' on method '{1}' in type '{2}'.  Please see InnerException for more details.</param>
        /// <param name="param2">Parameter 2 for string: An error occurred while loading attribute '{0}' on method '{1}' in type '{2}'.  Please see InnerException for more details.</param>
        internal static string SFxErrorReflectingOnMethod3(object param0, object param1, object param2) {
            return string.Format(Culture, ResourceManager.GetString("SFxErrorReflectingOnMethod3", Culture), param0, param1, param2);
        }
        
        /// <summary>Gets localized string like: An error occurred while loading attribute '{0}' on parameter {1} of method '{2}' in type '{3}'.  Please see InnerException for more details.</summary>
        /// <param name="param0">Parameter 0 for string: An error occurred while loading attribute '{0}' on parameter {1} of method '{2}' in type '{3}'.  Please see InnerException for more details.</param>
        /// <param name="param1">Parameter 1 for string: An error occurred while loading attribute '{0}' on parameter {1} of method '{2}' in type '{3}'.  Please see InnerException for more details.</param>
        /// <param name="param2">Parameter 2 for string: An error occurred while loading attribute '{0}' on parameter {1} of method '{2}' in type '{3}'.  Please see InnerException for more details.</param>
        /// <param name="param3">Parameter 3 for string: An error occurred while loading attribute '{0}' on parameter {1} of method '{2}' in type '{3}'.  Please see InnerException for more details.</param>
        internal static string SFxErrorReflectingOnParameter4(object param0, object param1, object param2, object param3) {
            return string.Format(Culture, ResourceManager.GetString("SFxErrorReflectingOnParameter4", Culture), param0, param1, param2, param3);
        }
        
        /// <summary>Gets localized string like: An error occurred while loading attribute '{0}' on type '{1}'.  Please see InnerException for more details.</summary>
        /// <param name="param0">Parameter 0 for string: An error occurred while loading attribute '{0}' on type '{1}'.  Please see InnerException for more details.</param>
        /// <param name="param1">Parameter 1 for string: An error occurred while loading attribute '{0}' on type '{1}'.  Please see InnerException for more details.</param>
        internal static string SFxErrorReflectingOnType2(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFxErrorReflectingOnType2", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: An error occurred while loading attribute '{0}'.  Please see InnerException for more details.</summary>
        /// <param name="param0">Parameter 0 for string: An error occurred while loading attribute '{0}'.  Please see InnerException for more details.</param>
        internal static string SFxErrorReflectionOnUnknown1(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxErrorReflectionOnUnknown1", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Service implementation object invoked with wrong number of input parameters, operation expects {0} parameters but was called with {1} parameters.</summary>
        /// <param name="param0">Parameter 0 for string: Service implementation object invoked with wrong number of input parameters, operation expects {0} parameters but was called with {1} parameters.</param>
        /// <param name="param1">Parameter 1 for string: Service implementation object invoked with wrong number of input parameters, operation expects {0} parameters but was called with {1} parameters.</param>
        internal static string SFxInputParametersToServiceInvalid(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFxInputParametersToServiceInvalid", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Service implementation object invoked with null input parameters, but operation expects {0} parameters.</summary>
        /// <param name="param0">Parameter 0 for string: Service implementation object invoked with null input parameters, but operation expects {0} parameters.</param>
        internal static string SFxInputParametersToServiceNull(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxInputParametersToServiceNull", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The contract specified by type '{0}' is ambiguous.  The type derives from at least two different types that each define its own service contract.  For this type to be used as a contract type, exactly one of its inherited contracts must be more derived than any of the others.</summary>
        /// <param name="param0">Parameter 0 for string: The contract specified by type '{0}' is ambiguous.  The type derives from at least two different types that each define its own service contract.  For this type to be used as a contract type, exactly one of its inherited contracts must be more derived than any of the others.</param>
        internal static string SFxNoMostDerivedContract(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFxNoMostDerivedContract", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Cannot generate unique name for name {0}</summary>
        /// <param name="param0">Parameter 0 for string: Cannot generate unique name for name {0}</param>
        internal static string SFXTooManyNames(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFXTooManyNames", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Parameter value '{0}' is an invalid URI.</summary>
        /// <param name="param0">Parameter 0 for string: Parameter value '{0}' is an invalid URI.</param>
        internal static string SFXUnvalidNamespaceParam(object param0) {
            return string.Format(Culture, ResourceManager.GetString("SFXUnvalidNamespaceParam", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Value '{0}' provided for {1} property is an invalid URI.</summary>
        /// <param name="param0">Parameter 0 for string: Value '{0}' provided for {1} property is an invalid URI.</param>
        /// <param name="param1">Parameter 1 for string: Value '{0}' provided for {1} property is an invalid URI.</param>
        internal static string SFXUnvalidNamespaceValue(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("SFXUnvalidNamespaceValue", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Too many attributes of type {0} on {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Too many attributes of type {0} on {1}.</param>
        /// <param name="param1">Parameter 1 for string: Too many attributes of type {0} on {1}.</param>
        internal static string tooManyAttributesOfTypeOn2(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("tooManyAttributesOfTypeOn2", Culture), param0, param1);
        }
    }
}

