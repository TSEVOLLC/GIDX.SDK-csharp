using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class BankAccount : PaymentMethod
    {
        public override string Type => PaymentMethodType.BankAcount;

        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }

        /// <summary>
        /// BankName will be populated by GIDX based on <see cref="RoutingNumber"/>
        /// </summary>
        public string BankName { get; set; }
    }
}
