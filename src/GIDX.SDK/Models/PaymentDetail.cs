using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models.DirectCashier;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GIDX.SDK.Models
{
    public class PaymentDetail
    {
        public decimal PaymentAmount { get; set; }
        public string CurrencyCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentStatusMessage { get; set; }
        public DateTime? PaymentApprovalDateTime { get; set; }
        public DateTime PaymentStatusDateTime { get; set; }
        public DateTime PaymentProcessDateTime { get; set; }
        public decimal FinancialConfidenceScore { get; set; }

        public bool Recurring { get; set; }
        public RecurringInterval? RecurringInterval { get; set; }
        public DateTime? NextRecurringDate { get; set; }

        /// <summary>
        /// Used for Direct Cashier. Will always be false in Web Cashier.
        /// </summary>
        public bool AllowRetry { get; set; }

        /// <summary>
        /// Used for Direct Cashier. Will always be null in Web Cashier.
        /// </summary>
        public TransactionAction Action { get; set; }
        
        public string ProcessorName { get; set; }
        public string ProcessorTransactionID { get; set; }
        public string ProcessorResponseCode { get; set; }
        public string ProcessorResponseMessage { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentAmountCode PaymentAmountCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentAmountType PaymentAmountType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatusCode PaymentStatusCode { get; set; }

        /// <summary>
        /// Payment method information has moved to <see cref="PaymentMethod"/>. This is left for backwards compatibility.
        /// </summary>
        public string PaymentMethodType { get; set; }
        /// <summary>
        /// Payment method information has moved to <see cref="PaymentMethod"/>. This is left for backwards compatibility.
        /// </summary>
        public string PaymentMethodAccount { get; set; }
        /// <summary>
        /// Payment method information has moved to <see cref="PaymentMethod"/>. This is left for backwards compatibility.
        /// </summary>
        public string PaymentMethodDisplay { get; set; }
    }
}
