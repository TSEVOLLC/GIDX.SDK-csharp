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


        #region CustomerMonitor

        public CustomerMonitorResponse CustomerMonitor(CustomerMonitorRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CustomerMonitorRequest, CustomerMonitorResponse>(request, "CustomerMonitor");
        }

        public CustomerMonitorResponse CustomerMonitor(string merchantCustomerID, string merchantSessionID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            var request = new CustomerMonitorRequest
            {
                MerchantCustomerID = merchantCustomerID,
                MerchantSessionID = merchantSessionID
            };
            return CustomerMonitor(request);
        }

        #endregion

        #region CustomerProfile

        public CustomerProfileResponse CustomerProfile(CustomerProfileRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<CustomerProfileRequest, CustomerProfileResponse>(request, "CustomerProfile");
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

        #endregion

        public CustomerRegistrationResponse CustomerRegistration(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CustomerRegistrationRequest, CustomerRegistrationResponse>(request, "CustomerRegistration");
        }
    }
}
