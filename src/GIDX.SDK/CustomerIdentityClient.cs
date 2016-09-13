using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.CustomerIdentity;

namespace GIDX.SDK
{
    internal class CustomerIdentityClient : ClientBase, ICustomerIdentityClient
    {
        public CustomerIdentityClient(MerchantCredentials credentials, Uri baseAddress)
            : base(credentials, baseAddress, "CustomerIdentity")
        {

        }

        public CustomerRegistrationResponse CustomerRegistration(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CustomerRegistrationRequest, CustomerRegistrationResponse>(request, "CustomerRegistration");
        }

        public CustomerProfileResponse CustomerProfile(string merchantCustomerID, string merchantSessionID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            var request = new CustomerProfileRequest
            {
                MerchantCustomerID = merchantCustomerID,
                MerchantSessionID = merchantSessionID
            };
            return CustomerProfile(request);
        }

        public CustomerProfileResponse CustomerProfile(CustomerProfileRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<CustomerProfileRequest, CustomerProfileResponse>(request, "CustomerProfile");
        }
    }
}
