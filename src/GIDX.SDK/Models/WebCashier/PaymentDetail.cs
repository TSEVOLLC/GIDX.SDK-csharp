using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.WebCashier
{
    public class PaymentDetail
    {
        public string PaymentAmountCode { get; set; }
        public string PaymentAmountType { get; set; }
        public decimal PaymentAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string PaymentMethodType { get; set; }
        public string PaymentMethodAccount { get; set; }
        public string PaymentStatusCode { get; set; }
        public string PaymentStatusMessage { get; set; }
        public DateTime? PaymentApprovalDateTime { get; set; }
        public DateTime PaymentStatusDateTime { get; set; }
        public DateTime PaymentProcessDateTime { get; set; }
        public decimal FinancialConfidenceScore { get; set; }
    }
}
