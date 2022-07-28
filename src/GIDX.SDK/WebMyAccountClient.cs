using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.WebMyAccount;

namespace GIDX.SDK
{
    internal class WebMyAccountClient : ClientBase, IWebMyAccountClient
    {
        public WebMyAccountClient(MerchantCredentials credentials, Uri baseAddress, HttpClient httpClient)
            : base(credentials, baseAddress, httpClient, "WebMyAccount")
        {

        }

        public CreateSessionResponse CreateSession(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }
    }
}
