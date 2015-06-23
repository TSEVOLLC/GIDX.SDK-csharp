using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class Citizenship : ElementBase
    {
        public string CountryCode { get; set; }
        public DateTime? DateAcquired { get; set; }
    }
}
