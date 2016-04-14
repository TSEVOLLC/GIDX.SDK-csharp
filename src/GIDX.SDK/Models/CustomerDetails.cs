using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class CustomerDetails : ICustomerDetails
    {
        public string MerchantCustomerID { get; set; }

        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string CitizenshipCountryCode { get; set; }
        public string IdentificationTypeCode { get; set; }
        public string IdentificationNumber { get; set; }

        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }

        public string CustomerIpAddressCountryCode { get; set; }

        public List<string> AdditionalCustomerData { get; set; }

        public DateTime? DateRegistered { get; set; }
        public string Username { get; set; }
    }
}
