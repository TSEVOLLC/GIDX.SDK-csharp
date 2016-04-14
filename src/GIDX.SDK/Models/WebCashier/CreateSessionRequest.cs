using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.WebCashier
{
    public class CreateSessionRequest : RequestBase
    {
        public CreateSessionRequest()
        {
            PayActionCode = PayActionCode.PAY;
        }

        public PayActionCode PayActionCode { get; set; }
        public string MerchantCustomerID { get; set; }
        public string MerchantTransactionID { get; set; }
        public string MerchantOrderID { get; set; }
        public string CallbackURL { get; set; }
        public CashierPaymentAmount CashierPaymentAmount { get; set; }
        public CustomerDetails CustomerRegistration { get; set; }
    }
}
