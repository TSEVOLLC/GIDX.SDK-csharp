using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class BankAccountSettings : PaymentMethodSettings
    {
        public override string Type => "ACH";
    }
}
