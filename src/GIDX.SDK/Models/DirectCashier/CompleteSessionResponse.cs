using GIDX.SDK.Models.CustomerIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DirectCashier
{
    public class CompleteSessionResponse : ResponseBase, IReasonCodes
    {
        public string MerchantTransactionID { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
        public bool AllowRetry { get; set; }
        /// <summary>
        /// An action that needs to be taken in order to complete the transaction
        /// </summary>
        public TransactionAction Action { get; set; }
        public List<string> ReasonCodes { get; set; }

        /// <summary>
        /// Internal GIDX SessionID for reference.
        /// </summary>
        public string SessionID { get; set; }
        public decimal SessionScore { get; set; }
        public string SessionStatusCode { get; set; }
        public string SessionStatusMessage { get; set; }
        public decimal FraudConfidenceScore { get; set; }

        public CustomerRegistrationResponse CustomerRegistration { get; set; }
    }
}
