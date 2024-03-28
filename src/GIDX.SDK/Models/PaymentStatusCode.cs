using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public enum PaymentStatusCode
    {
        NotFound = -1,
        Pending = 0,
        Complete = 1,
        Ineligible = 2,
        Failed = 3,
        Processing = 4,
        Reversed = 5
    }
}
