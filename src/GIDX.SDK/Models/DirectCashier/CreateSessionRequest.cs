using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GIDX.SDK.Models.DirectCashier
{
    public class CreateSessionRequest : RequestBase, IContestActivity
    {
        public CreateSessionRequest()
        {
            PayActionCode = PayActionCode.Pay;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public PayActionCode PayActionCode { get; set; }
        public string MerchantCustomerID { get; set; }
        public string MerchantTransactionID { get; set; }
        public string MerchantOrderID { get; set; }
        public bool Recurring { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RecurringInterval? RecurringInterval { get; set; }
        public DateTime? FirstRecurringDate { get; set; }
        public string CallbackURL { get; set; }
        public CustomerDetails CustomerRegistration { get; set; }
        public List<string> ContestCodes { get; set; }
    }
}
