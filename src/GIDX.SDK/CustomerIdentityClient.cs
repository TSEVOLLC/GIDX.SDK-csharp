using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.CustomerIdentity;

namespace GIDX.SDK
{
    internal class CustomerIdentityClient : ClientBase, ICustomerIdentityClient
    {
        public CustomerIdentityClient(MerchantCredentials credentials, Uri baseAddress, Func<HttpClient> getHttpClient)
            : base(credentials, baseAddress, getHttpClient, "CustomerIdentity")
        {

        }

        #region CustomerMonitor

        public async Task<CustomerMonitorResponse> CustomerMonitorAsync(CustomerMonitorRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CustomerMonitorRequest, CustomerMonitorResponse>(request, "CustomerMonitor");
        }

        public Task<CustomerMonitorResponse> CustomerMonitorAsync(string merchantCustomerID, string merchantSessionID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            var request = new CustomerMonitorRequest
            {
                MerchantCustomerID = merchantCustomerID,
                MerchantSessionID = merchantSessionID
            };
            return CustomerMonitorAsync(request);
        }

        #endregion

        #region CustomerProfile

        public async Task<CustomerProfileResponse> CustomerProfileAsync(CustomerProfileRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendGetRequestAsync<CustomerProfileRequest, CustomerProfileResponse>(request, "CustomerProfile");
        }

        public Task<CustomerProfileResponse> CustomerProfileAsync(string merchantCustomerID, string merchantSessionID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            var request = new CustomerProfileRequest
            {
                MerchantCustomerID = merchantCustomerID,
                MerchantSessionID = merchantSessionID
            };
            return CustomerProfileAsync(request);
        }

        #endregion

        public async Task<CustomerRegistrationResponse> CustomerRegistrationAsync(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CustomerRegistrationRequest, CustomerRegistrationResponse>(request, "CustomerRegistration");
        }

        public async Task<CustomerUpdateResponse> CustomerUpdateAsync(CustomerUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CustomerUpdateRequest, CustomerUpdateResponse>(request, "CustomerUpdate");
        }

        public async Task<LocationResponse> LocationAsync(LocationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<LocationRequest, LocationResponse>(request, "Location");
        }

        public async Task<RemoveCustomerResponse> RemoveCustomerAsync(RemoveCustomerRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<RemoveCustomerRequest, RemoveCustomerResponse>(request, "RemoveCustomer");
        }
    }
}
