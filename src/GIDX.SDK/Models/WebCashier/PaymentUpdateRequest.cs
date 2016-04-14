using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.WebCashier
{
    public class PaymentUpdateRequest : RequestBase
    {
        public string MerchantTransactionID { get; set; }
        public string PaymentStatusCode { get; set; }
    }
}
