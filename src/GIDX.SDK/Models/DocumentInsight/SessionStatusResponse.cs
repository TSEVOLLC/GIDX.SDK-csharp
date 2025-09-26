using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DocumentInsight
{
    public class SessionStatusResponse : CreateSessionResponse
    {
        public List<File> Files { get; set; }
        public IDictionary<string, object> VeriffDecision { get; set; }
    }
}
