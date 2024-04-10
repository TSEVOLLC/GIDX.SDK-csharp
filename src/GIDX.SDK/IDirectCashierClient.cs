using System;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DirectCashier;

namespace GIDX.SDK
{
    public interface IDirectCashierClient
    {
        Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request);
        Task<CompleteSessionResponse> CompleteSessionAsync(CompleteSessionRequest request);
        SessionStatusCallback ParseCallback(string json);
        Task<PaymentDetailResponse> PaymentDetailAsync(PaymentDetailRequest request);
        Task<PaymentDetailResponse> PaymentDetailAsync(string merchantSessionID, string merchantTransactionID);
        Task<PaymentUpdateResponse> PaymentUpdateAsync(PaymentUpdateRequest request);
        Task<PaymentUpdateResponse> PaymentUpdateAsync(string merchantTransactionID, PaymentStatusCode paymentStatusCode);
        Task<SavePaymentMethodResponse> SavePaymentMethodAsync(SavePaymentMethodRequest request);

        #region Legacy non-async methods

        CreateSessionResponse CreateSession(CreateSessionRequest request);
        CompleteSessionResponse CompleteSession(CompleteSessionRequest request);
        PaymentDetailResponse PaymentDetail(PaymentDetailRequest request);
        PaymentDetailResponse PaymentDetail(string merchantSessionID, string merchantTransactionID);
        PaymentUpdateResponse PaymentUpdate(PaymentUpdateRequest request);
        PaymentUpdateResponse PaymentUpdate(string merchantTransactionID, PaymentStatusCode paymentStatusCode);
        SavePaymentMethodResponse SavePaymentMethod(SavePaymentMethodRequest request);

        #endregion
    }
}
