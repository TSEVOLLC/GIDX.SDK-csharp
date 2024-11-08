using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class CreditCardSettings : PaymentMethodSettings
    {
        public override string Type => PaymentMethodType.CreditCard;
    }
}
