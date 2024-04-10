using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class SavePaymentMethodRequest : RequestBase
    {
        /// <summary>
        /// Not required if <see cref="RequestBase.MerchantSessionID"/> references an active DirectCashier session
        /// </summary>
        public string MerchantCustomerID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        
        /// <summary>
        /// Should the payment method be remembered for future use.
        /// </summary>
        public bool? SavePaymentMethod { get; set; }
    }
}
