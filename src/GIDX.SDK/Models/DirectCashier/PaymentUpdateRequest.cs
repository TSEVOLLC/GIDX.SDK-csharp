using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DirectCashier
{
    public class PaymentUpdateRequest : RequestBase
    {
        public string MerchantTransactionID { get; set; }
        public PaymentStatusCode PaymentStatusCode { get; set; }
    }
}
