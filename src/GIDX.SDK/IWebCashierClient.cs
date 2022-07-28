using System;
using System.Threading.Tasks;
using GIDX.SDK.Models.WebCashier;

namespace GIDX.SDK
{
    public interface IWebCashierClient
    {
        Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request);
        Task<CreateSessionWebWalletResponse> CreateSessionWebWalletAsync(CreateSessionWebWalletRequest request);
        SessionStatusCallback ParseCallback(string json);
        Task<PaymentDetailResponse> PaymentDetailAsync(PaymentDetailRequest request);
        Task<PaymentDetailResponse> PaymentDetailAsync(string merchantSessionID, string merchantTransactionID);
        Task<PaymentUpdateResponse> PaymentUpdateAsync(PaymentUpdateRequest request);
        Task<PaymentUpdateResponse> PaymentUpdateAsync(string merchantTransactionID, PaymentStatusCode paymentStatusCode);
        Task<WebCashierStatusResponse> WebCashierStatusAsync(WebCashierStatusRequest request);
        Task<WebCashierStatusResponse> WebCashierStatusAsync(string merchantSessionID);
    }
}
