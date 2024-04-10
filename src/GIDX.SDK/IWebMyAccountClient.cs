using System;
using System.Threading.Tasks;
using GIDX.SDK.Models.WebMyAccount;

namespace GIDX.SDK
{
    public interface IWebMyAccountClient
    {
        Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request);

        #region Legacy non-async methods

        CreateSessionResponse CreateSession(CreateSessionRequest request);

        #endregion
    }
}
