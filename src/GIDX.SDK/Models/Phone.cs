using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class Phone : ElementBase
    {
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Extension { get; set; }
        public string Carrier { get; set; }
        public string LineType { get; set; }
    }
}
