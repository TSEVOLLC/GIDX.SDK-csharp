using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class ApplePaySettings : PaymentMethodSettings
    {
        public override string Type => PaymentMethodType.ApplePay;
    }
}
