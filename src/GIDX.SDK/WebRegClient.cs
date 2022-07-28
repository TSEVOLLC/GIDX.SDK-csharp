using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.WebReg;

namespace GIDX.SDK
{
    internal class WebRegClient : ClientBase, IWebRegClient
    {
        public WebRegClient(MerchantCredentials credentials, Uri baseAddress, HttpClient httpClient)
            : base(credentials, baseAddress, httpClient, "WebReg")
        {

        }

        public async Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }

        #region CustomerRegistration

        public async Task<CustomerRegistrationResponse> CustomerRegistrationAsync(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendGetRequestAsync<CustomerRegistrationRequest, CustomerRegistrationResponse>(request, "CustomerRegistration");
        }

        public Task<CustomerRegistrationResponse> CustomerRegistrationAsync(string merchantCustomerID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            var request = new CustomerRegistrationRequest
            {
                MerchantCustomerID = merchantCustomerID
            };

            return CustomerRegistrationAsync(request);
        }

        #endregion

        public SessionStatusCallback ParseCallback(string json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return FromJson<SessionStatusCallback>(json);
        }

        #region RegistrationStatus

        public async Task<RegistrationStatusResponse> RegistrationStatusAsync(RegistrationStatusRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendGetRequestAsync<RegistrationStatusRequest, RegistrationStatusResponse>(request, "RegistrationStatus");
        }

        public Task<RegistrationStatusResponse> RegistrationStatusAsync(string merchantSessionID)
        {
            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantSessionID");

            var request = new RegistrationStatusRequest
            {
                MerchantSessionID = merchantSessionID
            };

            return RegistrationStatusAsync(request);
        }

        #endregion
    }
}
