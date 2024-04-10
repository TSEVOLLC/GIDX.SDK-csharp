using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class PaypalAccount : PaymentMethod
    {
        public override string Type => "Paypal";

        public string EmailAddress { get; set; }
    }
}
