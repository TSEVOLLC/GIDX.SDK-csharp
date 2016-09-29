using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.CustomerIdentity
{
    public class CustomerProfileResponse : ResponseBase, IReasonCodes
    {
        public string MerchantCustomerID { get; set; }
        
        public string ProfileVerificationStatus { get; set; }

        public List<string> ReasonCodes { get; set; }

        public List<Name> Name { get; set; }
        public List<Birth> DateOfBirth { get; set; }
        public List<Citizenship> Citizenship { get; set; }
        public List<IdDocument> IdDocument { get; set; }
        public List<Email> Email { get; set; }
        public List<Phone> Phone { get; set; }
        public List<Address> Address { get; set; }
        public List<Device> Device { get; set; }
    }
}
