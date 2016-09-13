using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.WebCashier
{
    public class PaymentDetailResponse : ResponseBase
    {
        public string MerchantTransactionID { get; set; }
        public decimal FinancialConfidenceScore { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
    }
}
