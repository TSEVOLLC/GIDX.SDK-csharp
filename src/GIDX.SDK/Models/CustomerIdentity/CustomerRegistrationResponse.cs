using System;
using System.Collections.Generic;

namespace GIDX.SDK.Models.CustomerIdentity
{
    public class CustomerRegistrationResponse : ResponseBase
    {
        public string MerchantCustomerID { get; set; }
        public decimal IdentityConfidenceScore { get; set; }
        public decimal FraudConfidenceScore { get; set; }
        public List<string> ReasonCodes { get; set; }

        public LocationDetail LocationDetail { get; set; }
        public ProfileMatch ProfileMatch { get; set; }
        public List<WatchCheck> WatchChecks { get; set; }
    }
}