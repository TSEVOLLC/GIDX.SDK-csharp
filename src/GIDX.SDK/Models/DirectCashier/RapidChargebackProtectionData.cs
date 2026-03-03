using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class RapidChargebackProtectionData
    {
        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Create your own class that is serializable by Newtonsoft.Json and use it here.
        /// </summary>
        [JsonProperty(PropertyName = "rawProductData")]
        public object RawProductData { get; set; }
    }
}
