//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Net.Http.Formatting.OData.Test.Sample {
    
    
    internal partial class BaselineResource {
        
        static System.Resources.ResourceManager resourceManager;
        
        static System.Globalization.CultureInfo resourceCulture;
        
        private BaselineResource() {
        }
        
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceManager, null)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Microsoft.Net.Http.Formatting.OData.Test.Sample.BaselineResource", typeof(BaselineResource).Assembly);
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
        
        /// <summary>Gets localized string like: ﻿<?xml version="1.0" encoding="utf-8"?>
        ///<entry xml:base="http://www.tempuri.org/" xmlns="http://www.w3.org/2005/Atom" xmlns:d="http://schemas.microsoft.com/ado/2007/08/dataservices" xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata" xmlns:georss="http://www.georss.org/georss" xmlns:gml="http://www.opengis.net/gml">
        ///  <id>http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Person(10)</id>
        ///  <category term="http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Person" scheme="http://schemas.microsoft.com/ado/2007/08/dataservices/scheme" />
        ///  <link rel="self" href="http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Person(10)" />
        ///  <title />
        ///  <updated>UpdatedTime</updated>
        ///  <author>
        ///    <name />
        ///  </author>
        ///  <content type="application/xml">
        ///    <m:properties>
        ///      <d:Age m:type="Edm.Int32">10</d:Age>
        ///      <d:MyGuid m:type="Edm.Guid">f99080c0-2f9e-472e-8c72-1a8ecd9f902d</d:MyGuid>
        ///      <d:Name>Asha</d:Name>
        ///      <d:Order m:type="http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Order">
        ///        <d:OrderAmount m:type="Edm.Int32">235342</d:OrderAmount>
        ///        <d:OrderName>FirstOrder</d:OrderName>
        ///      </d:Order>
        ///      <d:PerId m:type="Edm.Int32">10</d:PerId>
        ///    </m:properties>
        ///  </content>
        ///</entry></summary>
        internal static string EntryTypePersonAtom {
            get {
                return ResourceManager.GetString("EntryTypePersonAtom", Culture);
            }
        }
        
        /// <summary>Gets localized string like: 
        ///    %
        ///  "d":%
        ///  "__metadata":%
        ///  "id":"http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Person(10)","uri":"http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Person(10)","type":"http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Person"
        ///  },"Age":10,"MyGuid":"f99080c0-2f9e-472e-8c72-1a8ecd9f902d","Name":"Asha","Order":%
        ///  "__metadata":%
        ///  "type":"http://schemas.datacontract.org/2004/07/ODataFormatter.Sample/Order"
        ///  },"OrderAmount":235342,"OrderName":"FirstOrder"
        ///  },"PerId":10
        ///  }
        ///  }
        ///  </summary>
        internal static string EntryTypePersonODataJson {
            get {
                return ResourceManager.GetString("EntryTypePersonODataJson", Culture);
            }
        }
        
        /// <summary>Gets localized string like: %"Age":10,"MyGuid":"f99080c0-2f9e-472e-8c72-1a8ecd9f902d","Name":"Asha","Order":%"OrderAmount":235342,"OrderName":"FirstOrder"},"PerId":10}</summary>
        internal static string EntryTypePersonRegularJson {
            get {
                return ResourceManager.GetString("EntryTypePersonRegularJson", Culture);
            }
        }
    }
}

