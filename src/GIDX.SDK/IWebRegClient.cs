using System;
using System.Threading.Tasks;
using GIDX.SDK.Models.WebReg;

namespace GIDX.SDK
{
    public interface IWebRegClient
    {
        Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request);
        Task<CustomerRegistrationResponse> CustomerRegistrationAsync(CustomerRegistrationRequest request);
        Task<CustomerRegistrationResponse> CustomerRegistrationAsync(string merchantCustomerID);
        SessionStatusCallback ParseCallback(string json);
        Task<RegistrationStatusResponse> RegistrationStatusAsync(RegistrationStatusRequest request);
        Task<RegistrationStatusResponse> RegistrationStatusAsync(string merchantSessionID);

        #region Legacy non-async methods

        CreateSessionResponse CreateSession(CreateSessionRequest request);
        CustomerRegistrationResponse CustomerRegistration(CustomerRegistrationRequest request);
        CustomerRegistrationResponse CustomerRegistration(string merchantCustomerID);
        RegistrationStatusResponse RegistrationStatus(RegistrationStatusRequest request);
        RegistrationStatusResponse RegistrationStatus(string merchantSessionID);

        #endregion
    }
}
