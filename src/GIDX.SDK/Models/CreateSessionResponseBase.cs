using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public abstract class CreateSessionResponseBase : ResponseBase, IReasonCodes
    {
        public string SessionID { get; set; }
        public string SessionURL { get; set; }
        public DateTime SessionExpirationTime { get; set; }
        public List<string> ReasonCodes { get; set; }
    }
}
