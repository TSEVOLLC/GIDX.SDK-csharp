using System;

namespace GIDX.SDK.Models
{
    public abstract class RequestBase : IMerchantCredentials
    {
        private string _ipAddress;

        public string ApiKey { get; set; }
        public string MerchantID { get; set; }
        public string ProductTypeID { get; set; }
        public string DeviceTypeID { get; set; }
        public string ActivityTypeID { get; set; }

        public string MerchantSessionID { get; set; }

        /// <summary>
        /// <see cref="CustomerIpAddress"/> and <see cref="DeviceIpAddress"/> are interchangeable.
        /// Direct API requests expect DeviceIpAddress and Web API requests expect CustomerIpAddress, but they represent the same information, the customer's IP address.
        /// </summary>
        public string CustomerIpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        /// <summary>
        /// <see cref="CustomerIpAddress"/> and <see cref="DeviceIpAddress"/> are interchangeable.
        /// Direct API requests expect DeviceIpAddress and Web API requests expect CustomerIpAddress, but they represent the same information, the customer's IP address.
        /// </summary>
        public string DeviceIpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }
    }
}