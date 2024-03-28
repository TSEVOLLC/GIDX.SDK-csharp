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
        public DirectCashierClient(MerchantCredentials credentials, Uri baseAddress, HttpClient httpClient)
            : base(credentials, baseAddress, httpClient, "DirectCashier")
        {

        }

        public async Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }

        public async Task<CompleteSessionResponse> CompleteSessionAsync(CompleteSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CompleteSessionRequest, CompleteSessionResponse>(request, "CompleteSession");
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

        #endregion

        public async Task<SavePaymentMethodResponse> SavePaymentMethodAsync(SavePaymentMethodRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<SavePaymentMethodRequest, SavePaymentMethodResponse>(request, "PaymentMethod");
        }
    }
}
