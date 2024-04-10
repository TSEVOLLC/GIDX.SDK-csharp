using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class CashierPaymentAmount
    {
        public decimal? PaymentAmount { get; set; }
        public bool? PaymentAmountOverride { get; set; }
        public decimal? BonusAmount { get; set; }
        public bool? BonusAmountOverride { get; set; }
        public string BonusDetails { get; set; }
        public DateTime? BonusExpirationDateTime { get; set; }
        public string PaymentCurrencyCode { get; set; }
        public bool? OverrideLimit { get; set; }
    }
}
