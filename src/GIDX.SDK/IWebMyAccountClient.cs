using System;
using System.Threading.Tasks;
using GIDX.SDK.Models.WebMyAccount;

namespace GIDX.SDK
{
    public interface IWebMyAccountClient
    {
        Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request);
    }
}
