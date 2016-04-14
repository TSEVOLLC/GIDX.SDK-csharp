using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.WebCashier
{
    public class SessionStatusCallback : SessionStatusCallbackBase
    {
        public string MerchantTransactionID { get; set; }
        public PaymentStatusCode TransactionStatusCode { get; set; }
        public string TransactionStatusMessage { get; set; }
    }
}
