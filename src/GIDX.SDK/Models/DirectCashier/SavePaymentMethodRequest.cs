using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class SavePaymentMethodRequest : RequestBase
    {
        public PaymentMethod PaymentMethod { get; set; }
        
        /// <summary>
        /// Should the payment method be remembered for future use.
        /// </summary>
        public bool? SavePaymentMethod { get; set; }
    }
}
