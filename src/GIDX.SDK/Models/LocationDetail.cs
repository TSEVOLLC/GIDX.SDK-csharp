using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class LocationDetail : IReasonCodes
    {
        public string IdentifierType { get; set; }
        public string IdentifierUsed { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Radius { get; set; }
        public int? Speed { get; set; }

        public DateTime? LocationDateTime { get; set; }
        public bool ComplianceLocationStatus { get; set; }
        public int LocationStatus { get; set; }
        public string LocationServiceLevel { get; set; }
        public string ComplianceLocationServiceStatus { get; set; }
        public List<string> ReasonCodes { get; set; }
    }
}
