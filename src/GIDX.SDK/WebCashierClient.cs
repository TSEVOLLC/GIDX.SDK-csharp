using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.WebCashier;

namespace GIDX.SDK
{
    internal class WebCashierClient : ClientBase, IWebCashierClient
    {
        public WebCashierClient(MerchantCredentials credentials, Uri baseAddress)
            : base(credentials, baseAddress, "WebCashier")
        {

        }

        public CreateSessionResponse CreateSession(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }

        public CreateSessionWebWalletResponse CreateSessionWebWallet(CreateSessionWebWalletRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CreateSessionWebWalletRequest, CreateSessionWebWalletResponse>(request, "CreateSessionWebWallet");
        }

        public WebCashierStatusResponse WebCashierStatus(string merchantSessionID)
        {
            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantSessionID");

            var request = new WebCashierStatusRequest
            {
                MerchantSessionID = merchantSessionID
            };
            return WebCashierStatus(request);
        }

        public WebCashierStatusResponse WebCashierStatus(WebCashierStatusRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<WebCashierStatusRequest, WebCashierStatusResponse>(request, "WebCashierStatus");
        }

        public PaymentDetailResponse PaymentDetail(string merchantTransactionID)
        {
            if (merchantTransactionID == null)
                throw new ArgumentNullException("merchantTransactionID");

            var request = new PaymentDetailRequest
            {
                MerchantTransactionID = merchantTransactionID
            };
            return PaymentDetail(request);
        }

        public PaymentDetailResponse PaymentDetail(PaymentDetailRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<PaymentDetailRequest, PaymentDetailResponse>(request, "PaymentDetail");
        }

        public PaymentUpdateResponse PaymentUpdate(string merchantTransactionID, PaymentStatusCode paymentStatusCode)
        {
            if (merchantTransactionID == null)
                throw new ArgumentNullException("merchantTransactionID");

            if (paymentStatusCode == null)
                throw new ArgumentNullException("paymentStatusCode");

            var request = new PaymentUpdateRequest
            {
                MerchantTransactionID = merchantTransactionID,
                PaymentStatusCode = paymentStatusCode
            };
            return PaymentUpdate(request);
        }

        public PaymentUpdateResponse PaymentUpdate(PaymentUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<PaymentUpdateRequest, PaymentUpdateResponse>(request, "PaymentUpdate");
        }

        public SessionStatusCallback ParseCallback(string json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return FromJson<SessionStatusCallback>(json);
        }
    }
}
