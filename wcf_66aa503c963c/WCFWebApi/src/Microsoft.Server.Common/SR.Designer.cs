//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Server.Common {
    
    
    internal partial class SR {
        
        static System.Resources.ResourceManager resourceManager;
        
        static System.Globalization.CultureInfo resourceCulture;
        
        private SR() {
        }
        
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceManager, null)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Microsoft.Server.Common.SR", typeof(SR).Assembly);
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
        
        /// <summary>Gets localized string like: The ActionItem was already scheduled for execution that hasn't been completed yet.</summary>
        internal static string ActionItemIsAlreadyScheduled {
            get {
                return ResourceManager.GetString("ActionItemIsAlreadyScheduled", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Async Callback threw an exception.</summary>
        internal static string AsyncCallbackThrewException {
            get {
                return ResourceManager.GetString("AsyncCallbackThrewException", Culture);
            }
        }
        
        /// <summary>Gets localized string like: End cannot be called twice on an AsyncResult.</summary>
        internal static string AsyncResultAlreadyEnded {
            get {
                return ResourceManager.GetString("AsyncResultAlreadyEnded", Culture);
            }
        }
        
        /// <summary>Gets localized string like: This buffer cannot be returned to the buffer manager because it is the wrong size.</summary>
        internal static string BufferIsNotRightSizeForBufferManager {
            get {
                return ResourceManager.GetString("BufferIsNotRightSizeForBufferManager", Culture);
            }
        }
        
        /// <summary>Gets localized string like: An incorrect IAsyncResult was provided to an 'End' method. The IAsyncResult object passed to 'End' must be the one returned from the matching 'Begin' or passed to the callback provided to 'Begin'.</summary>
        internal static string InvalidAsyncResult {
            get {
                return ResourceManager.GetString("InvalidAsyncResult", Culture);
            }
        }
        
        /// <summary>Gets localized string like: An incorrect implementation of the IAsyncResult interface may be returning incorrect values from the CompletedSynchronously property or calling the AsyncCallback more than once.</summary>
        internal static string InvalidAsyncResultImplementationGeneric {
            get {
                return ResourceManager.GetString("InvalidAsyncResultImplementationGeneric", Culture);
            }
        }
        
        /// <summary>Gets localized string like: A null value was returned from an async 'Begin' method or passed to an AsyncCallback. Async 'Begin' implementations must return a non-null IAsyncResult and pass the same IAsyncResult object as the parameter to the AsyncCallback.</summary>
        internal static string InvalidNullAsyncResult {
            get {
                return ResourceManager.GetString("InvalidNullAsyncResult", Culture);
            }
        }
        
        /// <summary>Gets localized string like: You must cancel the previous timer before setting a new one.</summary>
        internal static string MustCancelOldTimer {
            get {
                return ResourceManager.GetString("MustCancelOldTimer", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Read not supported on this stream.</summary>
        internal static string ReadNotSupported {
            get {
                return ResourceManager.GetString("ReadNotSupported", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Seek not supported on this stream.</summary>
        internal static string SeekNotSupported {
            get {
                return ResourceManager.GetString("SeekNotSupported", Culture);
            }
        }
        
        /// <summary>Gets localized string like: Value must be non-negative.</summary>
        internal static string ValueMustBeNonNegative {
            get {
                return ResourceManager.GetString("ValueMustBeNonNegative", Culture);
            }
        }
        
        /// <summary>Gets localized string like: The argument {0} is null or empty.</summary>
        /// <param name="param0">Parameter 0 for string: The argument {0} is null or empty.</param>
        internal static string ArgumentNullOrEmpty(object param0) {
            return string.Format(Culture, ResourceManager.GetString("ArgumentNullOrEmpty", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The IAsyncResult implementation '{0}' tried to complete a single operation multiple times. This could be caused by an incorrect application IAsyncResult implementation or other extensibility code, such as an IAsyncResult that returns incorrect CompletedSynchronously values or invokes the AsyncCallback multiple times.</summary>
        /// <param name="param0">Parameter 0 for string: The IAsyncResult implementation '{0}' tried to complete a single operation multiple times. This could be caused by an incorrect application IAsyncResult implementation or other extensibility code, such as an IAsyncResult that returns incorrect CompletedSynchronously values or invokes the AsyncCallback multiple times.</param>
        internal static string AsyncResultCompletedTwice(object param0) {
            return string.Format(Culture, ResourceManager.GetString("AsyncResultCompletedTwice", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Failed to allocate a managed memory buffer of {0} bytes. The amount of available memory may be low.</summary>
        /// <param name="param0">Parameter 0 for string: Failed to allocate a managed memory buffer of {0} bytes. The amount of available memory may be low.</param>
        internal static string BufferAllocationFailed(object param0) {
            return string.Format(Culture, ResourceManager.GetString("BufferAllocationFailed", Culture), param0);
        }
        
        /// <summary>Gets localized string like: The size quota for this stream ({0}) has been exceeded.</summary>
        /// <param name="param0">Parameter 0 for string: The size quota for this stream ({0}) has been exceeded.</param>
        internal static string BufferedOutputStreamQuotaExceeded(object param0) {
            return string.Format(Culture, ResourceManager.GetString("BufferedOutputStreamQuotaExceeded", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Cannot convert object '{0}' to type '{1}'.</summary>
        /// <param name="param0">Parameter 0 for string: Cannot convert object '{0}' to type '{1}'.</param>
        /// <param name="param1">Parameter 1 for string: Cannot convert object '{0}' to type '{1}'.</param>
        internal static string CannotConvertObject(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("CannotConvertObject", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Number of string arguments passed to Etw WriteEvent has exceeded the max allowed limit of {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Number of string arguments passed to Etw WriteEvent has exceeded the max allowed limit of {0}.</param>
        internal static string EtwAPIMaxStringCountExceeded(object param0) {
            return string.Format(Culture, ResourceManager.GetString("EtwAPIMaxStringCountExceeded", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Number of arguments passed to Etw WriteEvent has exceeded the max allowed limit of {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Number of arguments passed to Etw WriteEvent has exceeded the max allowed limit of {0}.</param>
        internal static string EtwMaxNumberArgumentsExceeded(object param0) {
            return string.Format(Culture, ResourceManager.GetString("EtwMaxNumberArgumentsExceeded", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Etw registration failed with error code {0}.</summary>
        /// <param name="param0">Parameter 0 for string: Etw registration failed with error code {0}.</param>
        internal static string EtwRegistrationFailed(object param0) {
            return string.Format(Culture, ResourceManager.GetString("EtwRegistrationFailed", Culture), param0);
        }
        
        /// <summary>Gets localized string like: An unrecoverable error occurred. For diagnostic purposes, this English message is associated with the failure: '{0}'.</summary>
        /// <param name="param0">Parameter 0 for string: An unrecoverable error occurred. For diagnostic purposes, this English message is associated with the failure: '{0}'.</param>
        internal static string FailFastMessage(object param0) {
            return string.Format(Culture, ResourceManager.GetString("FailFastMessage", Culture), param0);
        }
        
        /// <summary>Gets localized string like: An incorrect implementation of the IAsyncResult interface may be returning incorrect values from the CompletedSynchronously property or calling the AsyncCallback more than once. The type {0} could be the incorrect implementation.</summary>
        /// <param name="param0">Parameter 0 for string: An incorrect implementation of the IAsyncResult interface may be returning incorrect values from the CompletedSynchronously property or calling the AsyncCallback more than once. The type {0} could be the incorrect implementation.</param>
        internal static string InvalidAsyncResultImplementation(object param0) {
            return string.Format(Culture, ResourceManager.GetString("InvalidAsyncResultImplementation", Culture), param0);
        }
        
        /// <summary>Gets localized string like: An unexpected failure occurred. Applications should not attempt to handle this error. For diagnostic purposes, this English message is associated with the failure: '{0}'.</summary>
        /// <param name="param0">Parameter 0 for string: An unexpected failure occurred. Applications should not attempt to handle this error. For diagnostic purposes, this English message is associated with the failure: '{0}'.</param>
        internal static string ShipAssertExceptionMessage(object param0) {
            return string.Format(Culture, ResourceManager.GetString("ShipAssertExceptionMessage", Culture), param0);
        }
        
        /// <summary>Gets localized string like: A Dequeue operation timed out after {0}. The time allotted to this operation may have been a portion of a longer timeout.</summary>
        /// <param name="param0">Parameter 0 for string: A Dequeue operation timed out after {0}. The time allotted to this operation may have been a portion of a longer timeout.</param>
        internal static string TimeoutInputQueueDequeue(object param0) {
            return string.Format(Culture, ResourceManager.GetString("TimeoutInputQueueDequeue", Culture), param0);
        }
        
        /// <summary>Gets localized string like: Argument {0} must be a non-negative timeout value. Provided value was {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Argument {0} must be a non-negative timeout value. Provided value was {1}.</param>
        /// <param name="param1">Parameter 1 for string: Argument {0} must be a non-negative timeout value. Provided value was {1}.</param>
        internal static string TimeoutMustBeNonNegative(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("TimeoutMustBeNonNegative", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: Argument {0} must be a positive timeout value. Provided value was {1}.</summary>
        /// <param name="param0">Parameter 0 for string: Argument {0} must be a positive timeout value. Provided value was {1}.</param>
        /// <param name="param1">Parameter 1 for string: Argument {0} must be a positive timeout value. Provided value was {1}.</param>
        internal static string TimeoutMustBePositive(object param0, object param1) {
            return string.Format(Culture, ResourceManager.GetString("TimeoutMustBePositive", Culture), param0, param1);
        }
        
        /// <summary>Gets localized string like: The operation did not complete within the allotted timeout of {0}. The time allotted to this operation may have been a portion of a longer timeout.</summary>
        /// <param name="param0">Parameter 0 for string: The operation did not complete within the allotted timeout of {0}. The time allotted to this operation may have been a portion of a longer timeout.</param>
        internal static string TimeoutOnOperation(object param0) {
            return string.Format(Culture, ResourceManager.GetString("TimeoutOnOperation", Culture), param0);
        }
    }
}

