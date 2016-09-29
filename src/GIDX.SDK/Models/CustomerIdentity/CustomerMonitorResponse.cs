using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.CustomerIdentity
{
    public class CustomerMonitorResponse : ResponseBase, IReasonCodes
    {
        public string MerchantCustomerID { get; set; }

        public string ProfileVerificationStatus { get; set; }
        public decimal IdentityConfidenceScore { get; set; }
        public decimal FraudConfidenceScore { get; set; }

        public LocationDetail LocationDetail { get; set; }

        public List<string> ReasonCodes { get; set; }
        public List<WatchCheck> WatchChecks { get; set; }
    }
}
