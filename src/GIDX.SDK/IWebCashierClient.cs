using System;
using System.Threading.Tasks;
using GIDX.SDK.Models;
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

        #region Legacy non-async methods

        CreateSessionResponse CreateSession(CreateSessionRequest request);
        CreateSessionWebWalletResponse CreateSessionWebWallet(CreateSessionWebWalletRequest request);
        PaymentDetailResponse PaymentDetail(PaymentDetailRequest request);
        PaymentDetailResponse PaymentDetail(string merchantSessionID, string merchantTransactionID);
        PaymentUpdateResponse PaymentUpdate(PaymentUpdateRequest request);
        PaymentUpdateResponse PaymentUpdate(string merchantTransactionID, PaymentStatusCode paymentStatusCode);
        WebCashierStatusResponse WebCashierStatus(WebCashierStatusRequest request);
        WebCashierStatusResponse WebCashierStatus(string merchantSessionID);

        #endregion
    }
}
