using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class IdDocument : ElementBase
    {
        public string IDTypeCode { get; set; }
        public string IDNumber { get; set; }
        public string IssuingPlace { get; set; }
        public DateTime? IssuingDate { get; set; }
        public string NameOnID { get; set; }
    }
}
