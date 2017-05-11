using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class DeviceGpsDetails
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Radius { get; set; }
        public double? Speed { get; set; }
        public double? Altitude { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
