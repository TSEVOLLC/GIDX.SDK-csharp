using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.WebReg
{
    public class CustomerRegistrationResponse : ResponseBase, IReasonCodes
    {
        public string RegMerchantSessionID { get; set; }
        public string MerchantCustomerID { get; set; }

        public Name Name { get; set; }
        public Address Address { get; set; }
        public Email Email { get; set; }
        public Birth DateOfBirth { get; set; }
        public Phone Phone { get; set; }
        public IdDocument IdDocument { get; set; }
        public Device Device { get; set; }
        public Citizenship Citizenship { get; set; }

        public decimal IdentityConfidenceScore { get; set; }
        public decimal FraudConfidenceScore { get; set; }

        public DateTime DateTimeCompletion { get; set; }

        public string RegistrationIPAddress { get; set; }

        public List<Note> RegistrationNotes { get; set; }

        public List<WatchCheck> WatchChecks { get; set; }

        public List<string> ReasonCodes { get; set; }

        public ProfileMatch ProfileMatch { get; set; }

        public LocationDetail RegistrationLocation { get; set; }
    }
}
