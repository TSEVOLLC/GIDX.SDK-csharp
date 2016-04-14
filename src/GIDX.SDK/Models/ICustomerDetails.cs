using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public interface ICustomerDetails
    {
        string MerchantCustomerID { get; set; }

        string Salutation { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Suffix { get; set; }
        string FullName { get; set; }

        DateTime? DateOfBirth { get; set; }
        string EmailAddress { get; set; }
        string CitizenshipCountryCode { get; set; }
        string IdentificationTypeCode { get; set; }
        string IdentificationNumber { get; set; }

        string PhoneNumber { get; set; }
        string MobilePhoneNumber { get; set; }

        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string StateCode { get; set; }
        string PostalCode { get; set; }
        string CountryCode { get; set; }

        string CustomerIpAddressCountryCode { get; set; }

        List<string> AdditionalCustomerData { get; set; }

        /// <summary>
        /// Optional registration date for customer.  Used if you are importing historical customers into the system.
        /// </summary>
        DateTime? DateRegistered { get; set; }
        string Username { get; set; }
    }
}
