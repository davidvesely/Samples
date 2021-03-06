﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace Microsoft.ApplicationServer.Http.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    using Microsoft.ApplicationServer.Common.Test.Services;
    using Microsoft.ApplicationServer.Http.Description;
    using Microsoft.TestCommon;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HttpBehaviorElementTests
    {
        [TestMethod]
        [TestCategory("CIT")]
        [Timeout(TimeoutConstant.DefaultTimeout)]
        [Owner("vinelap")]
        [Description("HttpBehaviorElement ctor initializes all properties to known defaults")]
        public void HttpBehaviorElement_Ctor_Initializes_All_Properties()
        {
            HttpBehaviorElement el = new HttpBehaviorElement();

            Assert.AreEqual(HttpBehavior.DefaultHelpEnabled, el.HelpEnabled, "HelpEnabled wrong");
            Assert.AreEqual(HttpBehavior.DefaultTestClientEnabled, el.TestClientEnabled, "TestClientEnabled wrong");
            Assert.AreEqual(HttpBehavior.DefaultTrailingSlashMode, el.TrailingSlashMode, "TrailingSlashMode wrong");
            Assert.AreEqual(string.Empty, el.OperationHandlerFactory, "HttpOperationHandlerFactory should default to empty");

            Assert.AreEqual(typeof(HttpBehavior), el.BehaviorType, "BehaviorType wrong");
        }

        [TestMethod]
        [TestCategory("CIT")]
        [Timeout(TimeoutConstant.DefaultTimeout)]
        [Owner("vinelap")]
        [Description("HttpBehaviorElement set and test all mutable properties")]
        public void HttpBehaviorElement_Set_Properties()
        {
            HttpBehaviorElement el = new HttpBehaviorElement();

            el.HelpEnabled = false;
            Assert.IsFalse(el.HelpEnabled, "HelpEnabled false");
            el.HelpEnabled = true;
            Assert.IsTrue(el.HelpEnabled, "HelpEnabled true");

            el.TestClientEnabled = false;
            Assert.IsFalse(el.TestClientEnabled, "TestClientEnabled false");
            el.TestClientEnabled = true;
            Assert.IsTrue(el.TestClientEnabled, "TestClientEnabled true");

            el.TrailingSlashMode = TrailingSlashMode.AutoRedirect;
            Assert.AreEqual(TrailingSlashMode.AutoRedirect, el.TrailingSlashMode, "Autoredirect failed");
            el.TrailingSlashMode = TrailingSlashMode.Ignore;
            Assert.AreEqual(TrailingSlashMode.Ignore, el.TrailingSlashMode, "Ignore failed");

            el.OperationHandlerFactory = "hello";
            Assert.AreEqual("hello", el.OperationHandlerFactory, "OperationHandlerFactory failed");
            el.OperationHandlerFactory = null;
            Assert.AreEqual(string.Empty, el.OperationHandlerFactory, "Null handler provider failed");
            el.OperationHandlerFactory = "  ";
            Assert.AreEqual(string.Empty, el.OperationHandlerFactory, "whitespace handler provider failed");
        }

        [TestMethod]
        [TestCategory("CIT")]
        [Timeout(TimeoutConstant.DefaultTimeout)]
        [Owner("vinelap")]
        [Description("Setting HttpOperationHandlerFactory to invalid type throws")]
        public void Behavior_Bad_HttpOperationHandlerFactory_Throws()
        {
            HttpBehaviorElement el = new HttpBehaviorElement();
            UnitTest.Asserters.Exception.Throws<ConfigurationErrorsException>(
                "Setting HttpOperationHandlerFactory to wrong type throws",
                Http.SR.HttpMessageConfigurationPropertyTypeMismatch(typeof(string).FullName, "operationHandlerFactory", typeof(HttpOperationHandlerFactory)),
                () => HttpBehaviorElement.GetHttpOperationHandlerFactory(typeof(string).FullName));
        }

        [TestMethod]
        [TestCategory("CIT")]
        [Timeout(TimeoutConstant.DefaultTimeout)]
        [Owner("vinelap")]
        [Description("A config file with single default HttpBehavior loads correctly")]
        [DeploymentItem("ConfigFiles\\Microsoft.ApplicationServer.Http.CIT.Unit.ConfiguredHttpBehaviorTest.config")]
        public void Behavior_Element_From_Config_Directly()
        {
            UnitTest.Asserters.Config.Execute("Microsoft.ApplicationServer.Http.CIT.Unit.ConfiguredHttpBehaviorTest.config", () =>
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ServiceModelSectionGroup section = ServiceModelSectionGroup.GetSectionGroup(config);
                BehaviorsSection behaviors = section.Behaviors;

                Assert.AreEqual(2, behaviors.EndpointBehaviors.Count, "Wrong number of behaviors");

                HttpBehaviorElement namedElement = behaviors.EndpointBehaviors[0].FirstOrDefault() as HttpBehaviorElement;
                Assert.AreEqual(TrailingSlashMode.Ignore, namedElement.TrailingSlashMode, "TrailingSlash wrong");
                Assert.IsFalse(namedElement.HelpEnabled, "HelpEnabled wrong");
                Assert.IsFalse(namedElement.TestClientEnabled, "TestClientEnabled wrong");

                HttpBehaviorElement defaultElement = behaviors.EndpointBehaviors[1].FirstOrDefault() as HttpBehaviorElement;
                Assert.AreEqual(TrailingSlashMode.Ignore, defaultElement.TrailingSlashMode, "TrailingSlash wrong");
                Assert.IsFalse(defaultElement.HelpEnabled, "HelpEnabled wrong");
                Assert.IsFalse(namedElement.TestClientEnabled, "TestClientEnabled wrong");
            });
        }

        [TestMethod]
        [TestCategory("CIT")]
        [Timeout(TimeoutConstant.DefaultTimeout)]
        [Owner("vinelap")]
        [Description("A config file with single configured HttpBehavior loads correctly")]
        [DeploymentItem("ConfigFiles\\Microsoft.ApplicationServer.Http.CIT.Unit.ConfiguredHttpBehaviorWithServiceTest.config")]
        public void Behavior_Configured_Behavior_From_Host()
        {
            UnitTest.Asserters.Config.Execute("Microsoft.ApplicationServer.Http.CIT.Unit.ConfiguredHttpBehaviorWithServiceTest.config", () =>
            {
                HttpBehavior[] behaviors = GetBehaviorsFromServiceHost(typeof(CustomerService), new Uri("http://somehost"));
                Assert.AreEqual(1, behaviors.Length, "Expected 1 behavior");
                HttpBehavior behavior = behaviors[0];

                Assert.IsFalse(behavior.HelpEnabled, "HelpEnabled wrong");
                Assert.IsFalse(behavior.TestClientEnabled, "TestClientEnabled wrong");
                Assert.AreEqual(TrailingSlashMode.Ignore, behavior.TrailingSlashMode, "TrailingSlashMode wrong");
            });
        }

        private static HttpBehavior[] GetBehaviorsFromServiceHost(Type serviceType, Uri uri)
        {
            HttpServiceHost host = new HttpServiceHost(serviceType, uri);

            List<HttpBehavior> foundBehaviors = new List<HttpBehavior>();
            foreach (var endpoint in host.Description.Endpoints)
            {
                foreach (var behavior in endpoint.Behaviors.OfType<HttpBehavior>())
                {
                    foundBehaviors.Add(behavior);
                }
            }

            return foundBehaviors.ToArray();
        }

        private static HttpBehavior[] GetBehaviorsFromServiceHostOpen(Type serviceType, Uri uri)
        {
            HttpServiceHost host = new HttpServiceHost(serviceType, uri);
            try
            {
                host.Open();
            }
            catch (AddressAlreadyInUseException)
            {
                // currently necessary to recover from failed attempt to open port 80 again
            }

            List<HttpBehavior> foundBehaviors = new List<HttpBehavior>();
            foreach (var endpoint in host.Description.Endpoints)
            {
                foreach (var behavior in endpoint.Behaviors.OfType<HttpBehavior>())
                {
                    foundBehaviors.Add(behavior);
                }
            }
            return foundBehaviors.ToArray();
        }
    }
}
