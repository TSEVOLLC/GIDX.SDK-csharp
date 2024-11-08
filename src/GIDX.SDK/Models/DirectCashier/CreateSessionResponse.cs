using GIDX.SDK.Models.CustomerIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DirectCashier
{
    public class CreateSessionResponse : ResponseBase, IReasonCodes
    {
        public string MerchantTransactionID { get; set; }
        public string SessionID { get; set; }
        public decimal SessionScore { get; set; }
        public string SessionStatusCode { get; set; }
        public string SessionStatusMessage { get; set; }

        public CashierLimits Limits { get; set; }
        public List<PaymentAmountOption> PaymentAmounts { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public LocationDetail LocationDetail { get; set; }
        public List<string> ReasonCodes { get; set; }

        public decimal FraudConfidenceScore { get; set; }
        public List<WatchCheck> WatchChecks { get; set; }

        public CustomerRegistrationResponse CustomerRegistration { get; set; }
    }
}
