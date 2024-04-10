using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class PaymentAmountOption
    {
        public decimal PaymentAmount { get; set; }
        public decimal BonusAmount { get; set; }
        public string PaymentCurrencyCode { get; set; }
    }
}
