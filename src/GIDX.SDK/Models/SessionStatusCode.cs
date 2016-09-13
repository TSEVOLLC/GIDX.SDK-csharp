using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public enum SessionStatusCode
    {
        Complete = 0,
        Ineligible = 1,
        Incomplete = 2,
        Timeout = 3,
        InProgress = 4
    }
}
