﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace Microsoft.TestCommon.WCF.Types
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Microsoft.TestCommon.Types;

    [DataContract]
    public class GenericDataContractType<T> : IGenericValueContainer
    {
        private T value;

        public GenericDataContractType()
        {
        }

        public GenericDataContractType(T value)
        {
            this.value = value;
        }

        [DataMember]
        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.ValueSet = true;
                this.value = value;
            }
        }

        [XmlIgnore]
        public bool ValueSet { get; private set; }

        public object GetValue()
        {
            return this.Value;
        }
    }
}
