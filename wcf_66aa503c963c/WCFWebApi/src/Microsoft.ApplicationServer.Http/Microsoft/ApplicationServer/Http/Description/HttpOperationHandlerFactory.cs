﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace Microsoft.ApplicationServer.Http.Description
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.Text;
    using System.Xml.Serialization;
    using Microsoft.ApplicationServer.Http.Dispatcher;
    using Microsoft.Server.Common;

    internal enum XmlMediaTypeSerializerFormat
    {
        DataContractSerializer,
        XmlSerializer,
        Default
    }

    /// <summary>
    /// Class that provides <see cref="HttpOperationHandler"/> instances to handle Http requests or responses.
    /// </summary>
    public class HttpOperationHandlerFactory
    {
        private static readonly Type httpOperationHandlerFactoryType = typeof(HttpOperationHandlerFactory);
        private static readonly Type[] invalidContentTypes = new Type[] 
        {
            typeof(Message),
            typeof(HttpWebRequest),
            typeof(HttpWebResponse)
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpOperationHandlerFactory"/> class.
        /// </summary>
        /// <remarks>
        /// A default <see cref="MediaTypeFormatterCollection"/> will be used that includes an
        /// <see cref="XmlMediaTypeFormatter"/> and a <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        public HttpOperationHandlerFactory()
        {
            this.Formatters = new MediaTypeFormatterCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpOperationHandlerFactory"/> class.
        /// </summary>
        /// <param name="formatters">The default <see cref="MediaTypeFormatter"/> instances to use for the
        /// <see cref="RequestContentHandler"/> and <see cref="ResponseContentHandler"/> instances.</param>
        public HttpOperationHandlerFactory(IEnumerable<MediaTypeFormatter> formatters)
        {
            if (formatters == null)
            {
                throw Fx.Exception.ArgumentNull("formatters");
            }

            this.Formatters = new MediaTypeFormatterCollection(formatters);
        }

        /// <summary>
        /// Gets the default <see cref="MediaTypeFormatter"/> instances to use for the
        /// <see cref="RequestContentHandler"/> and <see cref="ResponseContentHandler"/> instances.
        /// </summary>
        public MediaTypeFormatterCollection Formatters { get; internal set; }

        /// <summary>
        /// Returns the ordered collection of <see cref="HttpOperationHandler"/> instances to use when handling 
        /// <see cref="HttpRequestMessage"/> instances for the given <paramref name="operation"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint.</param>
        /// <param name="operation">
        /// The <see cref="HttpOperationDescription"/> for the given operation that the <see cref="HttpOperationHandler"/>
        /// instances will be associated with.</param>
        /// <returns>
        /// The ordered collection of <see cref="HttpOperationHandler"/> instances to use when handling 
        /// <see cref="HttpRequestMessage"/> instances for the given operation.
        /// </returns>
        public Collection<HttpOperationHandler> CreateRequestHandlers(ServiceEndpoint endpoint, HttpOperationDescription operation)
        {
            if (endpoint == null)
            {
                throw Fx.Exception.ArgumentNull("endpoint");
            }

            if (operation == null)
            {
                throw Fx.Exception.ArgumentNull("operation");
            }

            Collection<HttpOperationHandler> handlers = this.OnCreateRequestHandlers(endpoint, operation);
            return handlers ?? new Collection<HttpOperationHandler>();
        }

        /// <summary>
        /// Returns the ordered collection of <see cref="HttpOperationHandler"/> instances to use when handling 
        /// <see cref="HttpResponseMessage"/> instances for the given <paramref name="operation"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint.</param>
        /// <param name="operation">The description of the service operation.</param>
        /// <returns>
        /// The ordered collection of <see cref="HttpOperationHandler"/> instances to use when handling 
        /// <see cref="HttpResponseMessage"/> instances for the given operation.
        /// </returns>
        public Collection<HttpOperationHandler> CreateResponseHandlers(ServiceEndpoint endpoint, HttpOperationDescription operation)
        {
            if (endpoint == null)
            {
                throw Fx.Exception.ArgumentNull("endpoint");
            }

            if (operation == null)
            {
                throw Fx.Exception.ArgumentNull("operation");
            }

            Collection<HttpOperationHandler> handlers = this.OnCreateResponseHandlers(endpoint, operation);
            return handlers ?? new Collection<HttpOperationHandler>();
        }

        internal static XmlMediaTypeSerializerFormat DetermineSerializerFormat(HttpOperationDescription operation)
        {
            Fx.Assert(operation != null, "The 'operation' parameter should not be null.");

            DataContractFormatAttribute dataContract = null;
            XmlSerializerFormatAttribute xmlSerializer = null;

            foreach (Attribute attribute in operation.Attributes)
            {
                if (dataContract == null)
                {
                    dataContract = attribute as DataContractFormatAttribute;
                }

                if (xmlSerializer == null)
                {
                    xmlSerializer = attribute as XmlSerializerFormatAttribute;
                }
            }

            if (xmlSerializer == null && dataContract != null)
            {
                return XmlMediaTypeSerializerFormat.DataContractSerializer;
            }
            else if (xmlSerializer != null && dataContract == null)
            {
                return XmlMediaTypeSerializerFormat.XmlSerializer;
            }

            ContractDescription contract = operation.DeclaringContract;
            if (contract != null)
            {
                Type contractType = contract.ContractType;
                if (contractType != null)
                {
                    foreach (Attribute attribute in contractType.GetCustomAttributes(true).Cast<Attribute>())
                    {
                        if (dataContract == null)
                        {
                            dataContract = attribute as DataContractFormatAttribute;
                        }

                        if (xmlSerializer == null)
                        {
                            xmlSerializer = attribute as XmlSerializerFormatAttribute;
                        }
                    }

                    if (xmlSerializer == null && dataContract != null)
                    {
                        return XmlMediaTypeSerializerFormat.DataContractSerializer;
                    }
                    else if (xmlSerializer != null && dataContract == null)
                    {
                        return XmlMediaTypeSerializerFormat.XmlSerializer;
                    }
                }
            }

            return XmlMediaTypeSerializerFormat.Default;
        }

        /// <summary>
        /// Called when the ordered collection of <see cref="HttpOperationHandler"/> instances is being created for 
        /// the given <paramref name="operation"/>.  Can be overridden in a derived class to customize the 
        /// collection of <see cref="HttpOperationHandler"/> instances returned. 
        /// </summary>
        /// <remarks>
        /// The base implementation returns the standard request <see cref="HttpOperationHandler"/> instances for the given
        /// operation.
        /// </remarks>
        /// <param name="endpoint">The service endpoint.</param>
        /// <param name="operation">The description of the service operation.</param>
        /// <returns>
        /// The ordered collection of <see cref="HttpOperationHandler"/> instances to use when handling 
        /// <see cref="HttpRequestMessage"/> instances for the given operation.
        /// </returns>
        protected virtual Collection<HttpOperationHandler> OnCreateRequestHandlers(ServiceEndpoint endpoint, HttpOperationDescription operation)
        {
            if (endpoint == null)
            {
                throw Fx.Exception.ArgumentNull("endpoint");
            }

            if (operation == null)
            {
                throw Fx.Exception.ArgumentNull("operation");
            }

            // TrailingSlashMode comes from the endpoint.  The default is AutoRedirect.
            HttpEndpoint httpEndpoint = endpoint as HttpEndpoint;
            TrailingSlashMode trailingSlashMode = httpEndpoint == null ? TrailingSlashMode.AutoRedirect : httpEndpoint.TrailingSlashMode;

            Collection<HttpOperationHandler> requestHandlers = new Collection<HttpOperationHandler>();

            HttpMethod method = operation.GetHttpMethod();
            UriTemplate uriTemplate = operation.GetUriTemplate(trailingSlashMode);
            string[] uriTemplateParameterNames = uriTemplate.PathSegmentVariableNames.Concat(uriTemplate.QueryValueVariableNames).ToArray();
            if (uriTemplateParameterNames.Length > 0)
            {
                requestHandlers.Add(new UriTemplateHandler(endpoint.Address.Uri, uriTemplate));
            }

            if (operation.ReturnValue != null 
                && QueryTypeHelper.IsQueryableInterfaceGenericType(operation.ReturnValue.ParameterType))
            {
                requestHandlers.Add(new QueryDeserializationHandler(operation.ReturnValue.ParameterType));
            }

            if (method != HttpMethod.Get && method != HttpMethod.Head)
            {
                HttpParameter requestContentParameter = GetRequestContentHandler(operation, uriTemplateParameterNames);
                if (requestContentParameter != null)
                {
                    requestContentParameter.IsContentParameter = true;
                    requestHandlers.Add(new RequestContentHandler(requestContentParameter, this.Formatters));

                    SetXmlAndJsonSerializers(operation, requestContentParameter, this.Formatters);
                }
            }

            return requestHandlers;
        }

        /// <summary>
        /// Called when the ordered collection of <see cref="HttpOperationHandler"/> instances is being created for 
        /// the given <paramref name="operation"/>.  Can be overridden in a derived class to customize the 
        /// collection of <see cref="HttpOperationHandler"/> instances returned. 
        /// </summary>
        /// <remarks>
        /// The base implementation returns the standard response <see cref="HttpOperationHandler"/> instances for the given
        /// operation.
        /// </remarks>
        /// <param name="endpoint">The service endpoint.</param>
        /// <param name="operation">
        /// The <see cref="HttpOperationDescription"/> for the given operation that the <see cref="HttpOperationHandler"/>
        /// instances will be associated with.</param>
        /// <returns>
        /// The ordered collection of <see cref="HttpOperationHandler"/> instances to use when handling 
        /// <see cref="HttpResponseMessage"/> instances for the given operation.
        /// </returns>
        protected virtual Collection<HttpOperationHandler> OnCreateResponseHandlers(ServiceEndpoint endpoint, HttpOperationDescription operation)
        {
            if (endpoint == null)
            {
                throw Fx.Exception.ArgumentNull("endpoint");
            }

            if (operation == null)
            {
                throw Fx.Exception.ArgumentNull("operation");
            }

            Collection<HttpOperationHandler> responseHandlers = new Collection<HttpOperationHandler>();
            List<HttpParameter> possibleContentParameters = new List<HttpParameter>();
            HttpParameter returnValue = operation.ReturnValue;

            if (returnValue != null && IsPossibleResponseContentParameter(returnValue))
            {
                possibleContentParameters.Add(returnValue);
            }

            foreach (HttpParameter parameter in operation.OutputParameters)
            {
                if (parameter != null && IsPossibleResponseContentParameter(parameter))
                {
                    possibleContentParameters.Add(returnValue);
                }
            }

            if (possibleContentParameters.Count > 1)
            {
                ThrowExceptionForMulitpleResponseContentParameters(possibleContentParameters, returnValue, operation.Name);
            }

            HttpParameter responseContentParameter = possibleContentParameters.Count == 1 ?
                possibleContentParameters[0] :
                returnValue;

            if (responseContentParameter != null &&
                responseContentParameter.ParameterType != TypeHelper.VoidType)
            {
                bool isReturnValue = responseContentParameter == returnValue;
                ValidateResponseContentParameter(responseContentParameter, isReturnValue, operation.Name);
                responseContentParameter.IsContentParameter = true;

                SetXmlAndJsonSerializers(operation, responseContentParameter, this.Formatters);
            }

            ResponseContentHandler responseContentHandler = new ResponseContentHandler(responseContentParameter, this.Formatters);
            responseHandlers.Add(responseContentHandler);

            if (responseContentParameter != null && QueryTypeHelper.IsQueryableInterfaceGenericType(responseContentParameter.ParameterType))
            {
                responseHandlers.Add(new QueryCompositionHandler(responseContentParameter.ParameterType));
            }

            return responseHandlers;
        }

        private static HttpParameter GetRequestContentHandler(HttpOperationDescription operation, string[] uriTemplateParameterNames)
        {
            Fx.Assert(operation != null, "The 'operation' parameter should not be null.");
            Fx.Assert(uriTemplateParameterNames != null, "The 'uriTemplateParameterNames' parameter should not be null.");

            HttpParameter requestContentParameter = null;
            List<HttpParameter> parametersNotUriBound = new List<HttpParameter>();
            List<HttpParameter> possibleContentParameters = new List<HttpParameter>();

            foreach (HttpParameter parameter in operation.InputParameters)
            {
                if (IsPossibleRequestContentParameter(parameter))
                {
                    possibleContentParameters.Add(parameter);
                }

                bool uriTemplateParameterMatch = false;
                foreach (string uriTemplateParameterName in uriTemplateParameterNames)
                {
                    if (string.Equals(uriTemplateParameterName, parameter.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        uriTemplateParameterMatch = true;
                        break;
                    }
                }

                if (!uriTemplateParameterMatch)
                {
                    parametersNotUriBound.Add(parameter);
                }
            }

            if (possibleContentParameters.Count > 1)
            {
                ThrowExceptionForMulitpleRequestContentParameters(possibleContentParameters, operation.Name);
            }

            if (possibleContentParameters.Count == 1)
            {
                requestContentParameter = possibleContentParameters[0];
            }
            else
            {
                if (parametersNotUriBound.Count > 1)
                {
                    ThrowExceptionForUnknownRequestContentParameter(operation.Name);
                }

                if (parametersNotUriBound.Count == 0)
                {
                    return null;
                }

                requestContentParameter = parametersNotUriBound[0];
            }

            ValidateRequestContentParameter(requestContentParameter, operation.Name);

            return requestContentParameter;
        }

        private static void ValidateRequestContentParameter(HttpParameter requestContentParameter, string operationName)
        {
            Fx.Assert(requestContentParameter != null, "The 'requestContentParameter' parameter should not be null.");
            Fx.Assert(operationName != null, "The 'operationName' parameter should not be null.");

            if (!IsValidContentType(requestContentParameter) ||
                HttpTypeHelper.HttpResponseMessageType.IsAssignableFrom(requestContentParameter.ParameterType))
            {
                throw Fx.Exception.AsError(
                    new InvalidOperationException(
                        Http.SR.InvalidRequestContentParameter(
                            operationName,
                            requestContentParameter.ParameterType.Name,
                            httpOperationHandlerFactoryType.Name)));
            }
        }

        private static void ValidateResponseContentParameter(HttpParameter responseContentParameter, bool isReturnValue, string operationName)
        {
            Fx.Assert(responseContentParameter != null, "The 'responseContentParameter' parameter should not be null.");
            Fx.Assert(operationName != null, "The 'operationName' parameter should not be null.");

            if (!IsValidContentType(responseContentParameter) ||
                HttpTypeHelper.HttpRequestMessageType.IsAssignableFrom(responseContentParameter.ParameterType))
            {
                if (isReturnValue)
                {
                    throw Fx.Exception.AsError(
                        new InvalidOperationException(
                            Http.SR.InvalidReturnValueContentParameter(
                                operationName,
                                responseContentParameter.ParameterType.Name,
                                httpOperationHandlerFactoryType.Name)));
                }

                throw Fx.Exception.AsError(
                        new InvalidOperationException(
                            Http.SR.InvalidResponseContentParameter(
                                operationName,
                                responseContentParameter.ParameterType.Name,
                                httpOperationHandlerFactoryType.Name)));
            }
        }

        private static bool IsValidContentType(HttpParameter requestContentParameter)
        {
            Fx.Assert(requestContentParameter != null, "The 'requestContentParameter' parameter should not be null.");

            foreach (Type invalidType in invalidContentTypes)
            {
                if (invalidType.IsAssignableFrom(requestContentParameter.ParameterType))
                {
                    return false;
                }
            }

            return true;
        }

        private static void ThrowExceptionForUnknownRequestContentParameter(string operationName)
        {
            if (string.IsNullOrEmpty(operationName))
            {
                operationName = HttpOperationDescription.UnknownName;
            }

            throw Fx.Exception.AsError(
                    new InvalidOperationException(
                        Http.SR.UnknownRequestContentParameter(
                            httpOperationHandlerFactoryType.Name,
                            operationName,
                            HttpParameter.IsContentParameterPropertyName,
                            bool.TrueString,
                            HttpTypeHelper.HttpContentType.Name,
                            HttpTypeHelper.ObjectContentGenericType.Name,
                            HttpTypeHelper.HttpRequestMessageType.Name,
                            HttpTypeHelper.HttpRequestMessageGenericType.Name)));
        }

        private static void ThrowExceptionForMulitpleRequestContentParameters(List<HttpParameter> possibleContentParameters, string operationName)
        {
            if (string.IsNullOrEmpty(operationName))
            {
                operationName = HttpOperationDescription.UnknownName;
            }

            string errorMessage = Http.SR.MultipleRequestContentParameters(
                httpOperationHandlerFactoryType.Name,
                operationName,
                possibleContentParameters.Count);
            StringBuilder stringBuilder = new StringBuilder(errorMessage);

            foreach (HttpParameter parameter in possibleContentParameters)
            {
                string parameterMessage = null;
                if (parameter.IsContentParameter)
                {
                    parameterMessage = Http.SR.RequestParameterWithIsContentParameterSet(
                            parameter.Name,
                            HttpParameter.IsContentParameterPropertyName,
                            bool.TrueString);
                }
                else
                {
                    parameterMessage = Http.SR.RequestParameterWithContentType(
                            parameter.Name,
                            parameter.ParameterType.Name);
                }

                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(parameterMessage);
            }

            throw Fx.Exception.AsError(new InvalidOperationException(stringBuilder.ToString()));
        }

        private static void ThrowExceptionForMulitpleResponseContentParameters(List<HttpParameter> possibleContentParameters, HttpParameter returnValue, string operationName)
        {
            Fx.Assert(possibleContentParameters != null, "The 'possibleContentParameters' parameter should not be null.");
            Fx.Assert(returnValue != null, "The 'returnValue' parameter should not be null.");
            Fx.Assert(operationName != null, "The 'operationName' parameter should not be null.");

            string errorMessage = Http.SR.MultipleResponseContentParameters(
                httpOperationHandlerFactoryType.Name,
                operationName,
                possibleContentParameters.Count);
            StringBuilder stringBuilder = new StringBuilder(errorMessage);

            foreach (HttpParameter parameter in possibleContentParameters)
            {
                string parameterMessage = null;
                if (parameter.IsContentParameter)
                {
                    if (parameter == returnValue)
                    {
                        parameterMessage = Http.SR.ReturnValueWithIsContentParameterSet(
                                HttpParameter.IsContentParameterPropertyName,
                                bool.TrueString);
                    }
                    else
                    {
                        parameterMessage = Http.SR.ResponseParameterWithIsContentParameterSet(
                                parameter.Name,
                                HttpParameter.IsContentParameterPropertyName,
                                bool.TrueString);
                    }
                }
                else
                {
                    if (parameter == returnValue)
                    {
                        parameterMessage = Http.SR.ReturnValueWithContentType(
                                parameter.ParameterType.Name);
                    }
                    else
                    {
                        parameterMessage = Http.SR.ResponseParameterWithContentType(
                                parameter.Name,
                                parameter.ParameterType.Name);
                    }
                }

                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(parameterMessage);
            }

            throw Fx.Exception.AsError(new InvalidOperationException(stringBuilder.ToString()));
        }

        private static bool IsPossibleResponseContentParameter(HttpParameter parameter)
        {
            Fx.Assert(parameter != null, "The 'parameter' parameter should not be null.");

            if (parameter.IsContentParameter ||
                HttpTypeHelper.GetHttpResponseOrContentInnerTypeOrNull(parameter.ParameterType) != null)
            {
                return true;
            }

            return false;
        }

        private static bool IsPossibleRequestContentParameter(HttpParameter parameter)
        {
            Fx.Assert(parameter != null, "The 'parameter' parameter should not be null.");

            if (parameter.IsContentParameter || parameter.ParameterType == HttpTypeHelper.HttpRequestMessageType ||
                HttpTypeHelper.GetHttpRequestOrContentInnerTypeOrNull(parameter.ParameterType) != null)
            {
                return true;
            }

            return false;
        }

        private static void SetXmlAndJsonSerializers(HttpOperationDescription operation, HttpParameter httpParameter, MediaTypeFormatterCollection formatters)
        {
            Fx.Assert(operation != null, "The 'operation' parameter should not be null.");
            Fx.Assert(httpParameter != null, "The 'httpParameter' parameter should not be null.");
            Fx.Assert(formatters != null, "The 'formatters' parameter should not be null.");

            Type contentType = HttpTypeHelper.GetHttpInnerTypeOrNull(httpParameter.ParameterType) ?? httpParameter.ParameterType;
            if (!HttpTypeHelper.IsHttp(contentType) && !HttpTypeHelper.IsJsonValue(contentType))
            {
                SetSerializerForXmlFormatter(operation, contentType, formatters);
                SetSerializerForJsonFormatter(operation, contentType, httpParameter.Name, formatters);
            }
        }

        private static void SetSerializerForXmlFormatter(HttpOperationDescription operation, Type type, MediaTypeFormatterCollection formatters)
        {
            Fx.Assert(operation != null, "The 'operation' parameter should not be null.");
            Fx.Assert(formatters != null, "The 'formatters' parameter should not be null.");

            XmlMediaTypeSerializerFormat serializerFormat = DetermineSerializerFormat(operation);
            Collection<Type> knownTypes = operation.KnownTypes;

            XmlMediaTypeFormatter xmlFormatter = formatters.XmlFormatter;

            // Set the serializer on xmlFormatter only when the xmlFormatter doesn't have one for the type.
            if (xmlFormatter != null && !xmlFormatter.ContainsSerializerForType(type))
            {
                if ((xmlFormatter.UseDataContractSerializer && serializerFormat == XmlMediaTypeSerializerFormat.Default) || 
                    serializerFormat == XmlMediaTypeSerializerFormat.DataContractSerializer)
                {
                    MediaTypeFormatter.TryGetDelegatingTypeForIQueryableGenericOrSame(ref type);

                    DataContractSerializerOperationBehavior behavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                    XmlObjectSerializer xmlObjectSerializer = null;
                    if (behavior != null)
                    {
                        xmlObjectSerializer = new DataContractSerializer(
                            type,
                            knownTypes,
                            behavior.MaxItemsInObjectGraph,
                            behavior.IgnoreExtensionDataObject,
                            false,
                            behavior.DataContractSurrogate,
                            behavior.DataContractResolver);
                    }
                    else
                    {
                        xmlObjectSerializer = new DataContractSerializer(type, knownTypes);
                    }

                    xmlFormatter.SetSerializer(type, xmlObjectSerializer);
                }
                else
                {
                    MediaTypeFormatter.TryGetDelegatingTypeForIEnumerableGenericOrSame(ref type);

                    XmlSerializer xmlSerializer = knownTypes.Count > 0 ?
                        new XmlSerializer(type, knownTypes.ToArray()) :
                        new XmlSerializer(type);
                    xmlFormatter.SetSerializer(type, xmlSerializer);
                }
            }
        }

        private static void SetSerializerForJsonFormatter(HttpOperationDescription operation, Type type, string name, MediaTypeFormatterCollection formatters)
        {
            Fx.Assert(operation != null, "The 'operation' parameter should not be null.");
            Fx.Assert(type != null, "The 'type' parameter should not be null.");
            Fx.Assert(name != null, "The 'name' parameter should not be null.");
            Fx.Assert(formatters != null, "The 'formatters' parameter should not be null.");

            JsonMediaTypeFormatter jsonFormatter = formatters.JsonFormatter;

            // Set the serializer on jsonFormatter only when the jsonFormatter doesn't have one for the type.
            if (jsonFormatter != null && !jsonFormatter.ContainsSerializerForType(type))
            {
                DataContractJsonSerializer jsonSerializer = null;
                DataContractSerializerOperationBehavior dataContractSerializerBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (dataContractSerializerBehavior != null)
                {
                    jsonSerializer = new DataContractJsonSerializer(
                        type,
                        operation.KnownTypes,
                        dataContractSerializerBehavior.MaxItemsInObjectGraph,
                        dataContractSerializerBehavior.IgnoreExtensionDataObject,
                        dataContractSerializerBehavior.DataContractSurrogate,
                        false);
                }
                else
                {
                    jsonSerializer = new DataContractJsonSerializer(type, "root", operation.KnownTypes);
                }

                jsonFormatter.SetSerializer(type, jsonSerializer);
            }
        }
    }
}