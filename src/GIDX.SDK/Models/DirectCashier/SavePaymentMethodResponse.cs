using GIDX.SDK.Models.CustomerIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DirectCashier
{
    public class SavePaymentMethodResponse : ResponseBase
    {
        public PaymentMethod PaymentMethod { get; set; }
    }
}
