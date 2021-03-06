﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace Microsoft.ApplicationServer.Common.Test.Services
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public class OneWayService
    {
        [OperationContract(IsOneWay = true)]
        [WebGet(UriTemplate = "{name}")]
        public void GetLocalCustomer(string name) { }
    }
}
