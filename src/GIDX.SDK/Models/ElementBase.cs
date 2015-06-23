using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public abstract class ElementBase
    {
        public decimal IdentityConfidenceScore { get; set; }
        public bool Primary { get; set; }
    }
}
