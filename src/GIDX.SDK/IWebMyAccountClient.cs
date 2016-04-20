using System;
using GIDX.SDK.Models.WebMyAccount;

namespace GIDX.SDK
{
    public interface IWebMyAccountClient
    {
        CreateSessionResponse CreateSession(CreateSessionRequest request);
    }
}
