using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public abstract class SessionStatusCallbackResponseBase
    {
        public string MerchantID { get; set; }
        public string SessionStatus { get; set; }
    }
}
