using System;
using GIDX.SDK.Models.WebCashier;

namespace GIDX.SDK
{
    public interface IWebCashierClient
    {
        CreateSessionResponse CreateSession(CreateSessionRequest request);
        CreateSessionWebWalletResponse CreateSessionWebWallet(CreateSessionWebWalletRequest request);
        SessionStatusCallback ParseCallback(string json);
        PaymentDetailResponse PaymentDetail(PaymentDetailRequest request);
        PaymentDetailResponse PaymentDetail(string merchantTransactionID);
        PaymentUpdateResponse PaymentUpdate(PaymentUpdateRequest request);
        PaymentUpdateResponse PaymentUpdate(string merchantTransactionID, PaymentStatusCode paymentStatusCode);
        WebCashierStatusResponse WebCashierStatus(WebCashierStatusRequest request);
        WebCashierStatusResponse WebCashierStatus(string merchantSessionID);
    }
}
