using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public abstract class SessionStatusResponseBase : ResponseBase
    {
        public decimal SessionScore { get; set; }
        public string SessionStatusCode { get; set; }
        public string SessionStatusMessage { get; set; }
        public List<string> ReasonCodes { get; set; }
    }
}
