using System;
using GIDX.SDK.Models.WebReg;

namespace GIDX.SDK
{
    public interface IWebRegClient
    {
        CreateSessionResponse CreateSession(CreateSessionRequest request);
        RegistrationStatusResponse RegistrationStatus(RegistrationStatusRequest request);
        RegistrationStatusResponse RegistrationStatus(string merchantSessionID);
    }
}
