using System;

namespace GIDX.SDK.Models
{
    public abstract class RequestBase : IMerchantCredentials
    {
        public string ApiKey { get; set; }
        public string MerchantID { get; set; }
        public string ProductTypeID { get; set; }
        public string DeviceTypeID { get; set; }
        public string ActivityTypeID { get; set; }

        public string MerchantSessionID { get; set; }
        public string DeviceIpAddress { get; set; }
    }
}