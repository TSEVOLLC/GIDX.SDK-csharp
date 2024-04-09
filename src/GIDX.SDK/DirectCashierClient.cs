using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DirectCashier;

namespace GIDX.SDK
{
    internal class DirectCashierClient : ClientBase, IDirectCashierClient
    {
        public DirectCashierClient(MerchantCredentials credentials, Uri baseAddress, Func<HttpClient> getHttpClient)
            : base(credentials, baseAddress, getHttpClient, "DirectCashier")
        {

        }

        public async Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }

        public CreateSessionResponse CreateSession(CreateSessionRequest request)
        {
            return CreateSessionAsync(request).Result;
        }

        public async Task<CompleteSessionResponse> CompleteSessionAsync(CompleteSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CompleteSessionRequest, CompleteSessionResponse>(request, "CompleteSession");
        }

        public CompleteSessionResponse CompleteSession(CompleteSessionRequest request)
        {
            return CompleteSessionAsync(request).Result;
        }

        public SessionStatusCallback ParseCallback(string json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return FromJson<SessionStatusCallback>(json);
        }

        #region PaymentDetail

        public async Task<PaymentDetailResponse> PaymentDetailAsync(PaymentDetailRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendGetRequestAsync<PaymentDetailRequest, PaymentDetailResponse>(request, "PaymentDetail");
        }

        public Task<PaymentDetailResponse> PaymentDetailAsync(string merchantSessionID, string merchantTransactionID)
        {
            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantTransactionID");

            if (merchantTransactionID == null)
                throw new ArgumentNullException("merchantTransactionID");

            var request = new PaymentDetailRequest
            {
                MerchantSessionID = merchantSessionID,
                MerchantTransactionID = merchantTransactionID
            };

            return PaymentDetailAsync(request);
        }

        public PaymentDetailResponse PaymentDetail(PaymentDetailRequest request)
        {
            return PaymentDetailAsync(request).Result;
        }

        public PaymentDetailResponse PaymentDetail(string merchantSessionID, string merchantTransactionID)
        {
            return PaymentDetailAsync(merchantSessionID, merchantTransactionID).Result;
        }

        #endregion

        #region PaymentUpdate

        public async Task<PaymentUpdateResponse> PaymentUpdateAsync(PaymentUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<PaymentUpdateRequest, PaymentUpdateResponse>(request, "PaymentUpdate");
        }

        public Task<PaymentUpdateResponse> PaymentUpdateAsync(string merchantTransactionID, PaymentStatusCode paymentStatusCode)
        {
            if (merchantTransactionID == null)
                throw new ArgumentNullException("merchantTransactionID");

            var request = new PaymentUpdateRequest
            {
                MerchantTransactionID = merchantTransactionID,
                PaymentStatusCode = paymentStatusCode
            };

            return PaymentUpdateAsync(request);
        }

        public PaymentUpdateResponse PaymentUpdate(PaymentUpdateRequest request)
        {
            return PaymentUpdateAsync(request).Result;
        }

        public PaymentUpdateResponse PaymentUpdate(string merchantTransactionID, PaymentStatusCode paymentStatusCode)
        {
            return PaymentUpdateAsync(merchantTransactionID, paymentStatusCode).Result;
        }

        #endregion

        public async Task<SavePaymentMethodResponse> SavePaymentMethodAsync(SavePaymentMethodRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<SavePaymentMethodRequest, SavePaymentMethodResponse>(request, "PaymentMethod");
        }

        public SavePaymentMethodResponse SavePaymentMethod(SavePaymentMethodRequest request)
        {
            return SavePaymentMethodAsync(request).Result;
        }
    }
}
