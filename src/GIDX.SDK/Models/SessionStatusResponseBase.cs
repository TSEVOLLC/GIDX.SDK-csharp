using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GIDX.SDK.Models
{
    public abstract class SessionStatusResponseBase : ResponseBase
    {
        public decimal SessionScore { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SessionStatusCode SessionStatusCode { get; set; }

        public string SessionStatusMessage { get; set; }
        public List<string> ReasonCodes { get; set; }
    }
}
