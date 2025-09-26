using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GIDX.SDK.Models.DocumentInsight
{
    public class CreateSessionRequest : RequestBase
    {
        public string MerchantCustomerID { get; set; }
        public string CallbackURL { get; set; }
        public string RedirectURL { get; set; }
        public CustomerDetails CustomerRegistration { get; set; }
        public string ReasonCode { get; set; }
    }
}
