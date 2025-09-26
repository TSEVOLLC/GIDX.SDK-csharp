using System;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DocumentInsight;

namespace GIDX.SDK
{
    public interface IDocumentInsightClient
    {
        Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request);
        SessionStatusCallback ParseCallback(string json);
        Task<SessionStatusResponse> SessionStatusAsync(SessionStatusRequest request);
        Task<SessionStatusResponse> SessionStatusAsync(string merchantSessionID);


        #region Legacy non-async methods

        CreateSessionResponse CreateSession(CreateSessionRequest request);
        SessionStatusResponse SessionStatus(SessionStatusRequest request);
        SessionStatusResponse SessionStatus(string merchantSessionID);

        #endregion
    }
}
