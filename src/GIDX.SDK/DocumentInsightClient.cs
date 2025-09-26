using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DocumentInsight;

namespace GIDX.SDK
{
    internal class DocumentInsightClient : ClientBase, IDocumentInsightClient
    {
        public DocumentInsightClient(MerchantCredentials credentials, Uri baseAddress, Func<HttpClient> getHttpClient)
            : base(credentials, baseAddress, getHttpClient, "DocumentInsight")
        {

        }

        public async Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }

        public CreateSessionResponse CreateSession(CreateSessionRequest request)
        {
            return CreateSessionAsync(request).Result;
        }

        public SessionStatusCallback ParseCallback(string json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return FromJson<SessionStatusCallback>(json);
        }

        #region SessionStatus

        public async Task<SessionStatusResponse> SessionStatusAsync(SessionStatusRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendGetRequestAsync<SessionStatusRequest, SessionStatusResponse>(request, "SessionStatus");
        }

        public Task<SessionStatusResponse> SessionStatusAsync(string merchantSessionID)
        {
            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantTransactionID");

            var request = new SessionStatusRequest
            {
                MerchantSessionID = merchantSessionID
            };

            return SessionStatusAsync(request);
        }

        public SessionStatusResponse SessionStatus(SessionStatusRequest request)
        {
            return SessionStatusAsync(request).Result;
        }

        public SessionStatusResponse SessionStatus(string merchantSessionID)
        {
            return SessionStatusAsync(merchantSessionID).Result;
        }

        #endregion
    }
}
