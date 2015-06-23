using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class Address : ElementBase
    {
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Neighborhood { get; set; }
    }
}
