﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.WebCashier;

namespace GIDX.SDK
{
    internal class WebCashierClient : ClientBase, IWebCashierClient
    {
        public WebCashierClient(MerchantCredentials credentials, Uri baseAddress, Func<HttpClient> getHttpClient)
            : base(credentials, baseAddress, getHttpClient, "WebCashier")
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

        public async Task<CreateSessionWebWalletResponse> CreateSessionWebWalletAsync(CreateSessionWebWalletRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendPostRequestAsync<CreateSessionWebWalletRequest, CreateSessionWebWalletResponse>(request, "CreateSessionWebWallet");
        }

        public CreateSessionWebWalletResponse CreateSessionWebWallet(CreateSessionWebWalletRequest request)
        {
            return CreateSessionWebWalletAsync(request).Result;
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

        #region WebCashierStatus

        public async Task<WebCashierStatusResponse> WebCashierStatusAsync(WebCashierStatusRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendGetRequestAsync<WebCashierStatusRequest, WebCashierStatusResponse>(request, "WebCashierStatus");
        }

        public Task<WebCashierStatusResponse> WebCashierStatusAsync(string merchantSessionID)
        {
            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantSessionID");

            var request = new WebCashierStatusRequest
            {
                MerchantSessionID = merchantSessionID
            };

            return WebCashierStatusAsync(request);
        }

        public WebCashierStatusResponse WebCashierStatus(WebCashierStatusRequest request)
        {
            return WebCashierStatusAsync(request).Result;
        }

        public WebCashierStatusResponse WebCashierStatus(string merchantSessionID)
        {
            return WebCashierStatusAsync(merchantSessionID).Result;
        }

        #endregion
    }
}
