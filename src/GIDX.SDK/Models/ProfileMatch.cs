using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class ProfileMatch
    {
        public bool NameMatch { get; set; }
        public bool AddressMatch { get; set; }
        public bool EmailMatch { get; set; }
        public bool IdDocumentMatch { get; set; }
        public bool PhoneMatch { get; set; }
        public bool MobilePhoneMatch { get; set; }
        public bool DateOfBirthMatch { get; set; }
        public bool CitizenshipMatch { get; set; }
    }
}
