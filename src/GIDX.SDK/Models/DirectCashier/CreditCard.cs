using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class CreditCard : PaymentMethod
    {
        public override string Type => "CC";

        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
        public string Network { get; set; }
    }
}
