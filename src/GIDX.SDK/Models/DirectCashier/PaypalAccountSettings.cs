using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class PaypalAccountSettings : PaymentMethodSettings
    {
        public override string Type => "Paypal";

        public string ClientID { get; set; }
    }
}
