using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public abstract class SessionStatusCallbackBase : IReasonCodes
    {
        public string SessionID { get; set; }
        public string MerchantSessionID { get; set; }
        public string MerchantCustomerID { get; set; }
        public decimal SessionScore { get; set; }
        public List<string> ReasonCodes { get; set; }
        public string ServiceType { get; set; }

        public SessionStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}
