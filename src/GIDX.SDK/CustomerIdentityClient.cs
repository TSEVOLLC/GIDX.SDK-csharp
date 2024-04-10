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

        public CustomerMonitorResponse CustomerMonitor(CustomerMonitorRequest request)
        {
            return CustomerMonitorAsync(request).Result;
        }

        public CustomerMonitorResponse CustomerMonitor(string merchantCustomerID, string merchantSessionID)
        {
            return CustomerMonitorAsync(merchantCustomerID, merchantSessionID).Result;
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

        public CustomerProfileResponse CustomerProfile(CustomerProfileRequest request)
        {
            return CustomerProfileAsync(request).Result;
        }

        public CustomerProfileResponse CustomerProfile(string merchantCustomerID, string merchantSessionID)
        {
            return CustomerProfileAsync(merchantCustomerID, merchantSessionID).Result;
        }

        #endregion

        public async Task<CustomerRegistrationResponse> CustomerRegistrationAsync(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CustomerRegistrationRequest, CustomerRegistrationResponse>(request, "CustomerRegistration");
        }

        public CustomerRegistrationResponse CustomerRegistration(CustomerRegistrationRequest request)
        {
            return CustomerRegistrationAsync(request).Result;
        }

        public async Task<CustomerUpdateResponse> CustomerUpdateAsync(CustomerUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CustomerUpdateRequest, CustomerUpdateResponse>(request, "CustomerUpdate");
        }

        public CustomerUpdateResponse CustomerUpdate(CustomerUpdateRequest request)
        {
            return CustomerUpdateAsync(request).Result;
        }

        public async Task<LocationResponse> LocationAsync(LocationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<LocationRequest, LocationResponse>(request, "Location");
        }

        public LocationResponse Location(LocationRequest request)
        {
            return LocationAsync(request).Result;
        }

        public async Task<RemoveCustomerResponse> RemoveCustomerAsync(RemoveCustomerRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<RemoveCustomerRequest, RemoveCustomerResponse>(request, "RemoveCustomer");
        }

        public RemoveCustomerResponse RemoveCustomer(RemoveCustomerRequest request)
        {
            return RemoveCustomerAsync(request).Result;
        }
    }
}
