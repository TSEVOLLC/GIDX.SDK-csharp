using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.WebReg;

namespace GIDX.SDK
{
    internal class WebRegClient : ClientBase, IWebRegClient
    {
        public WebRegClient(MerchantCredentials credentials, Uri baseAddress)
            : base(credentials, baseAddress, "WebReg")
        {

        }

        public CreateSessionResponse CreateSession(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }

        public RegistrationStatusResponse RegistrationStatus(string merchantSessionID)
        {
            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantSessionID");

            var request = new RegistrationStatusRequest
            {
                MerchantSessionID = merchantSessionID
            };
            return RegistrationStatus(request);
        }

        public RegistrationStatusResponse RegistrationStatus(RegistrationStatusRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<RegistrationStatusRequest, RegistrationStatusResponse>(request, "RegistrationStatus");
        }
    }
}
