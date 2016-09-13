using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GIDX.SDK.Models.WebCashier
{
    public class PaymentDetail
    {
        public decimal PaymentAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string PaymentMethodType { get; set; }
        public string PaymentMethodAccount { get; set; }
        public string PaymentStatusMessage { get; set; }
        public DateTime? PaymentApprovalDateTime { get; set; }
        public DateTime PaymentStatusDateTime { get; set; }
        public DateTime PaymentProcessDateTime { get; set; }
        public decimal FinancialConfidenceScore { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentAmountCode PaymentAmountCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentAmountType PaymentAmountType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatusCode PaymentStatusCode { get; set; }
    }
}
