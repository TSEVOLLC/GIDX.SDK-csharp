﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.WebReg;

namespace GIDX.SDK
{
    internal class WebRegClient : ClientBase, IWebRegClient
    {
        public WebRegClient(MerchantCredentials credentials, Uri baseAddress)
            : base(credentials, baseAddress, "WebReg")
        {

        }

        public CreateSessionResponse CreateSession(CreateSessionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CreateSessionRequest, CreateSessionResponse>(request, "CreateSession");
        }

        #region CustomerRegistration

        public CustomerRegistrationResponse CustomerRegistration(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<CustomerRegistrationRequest, CustomerRegistrationResponse>(request, "CustomerRegistration");
        }

        public CustomerRegistrationResponse CustomerRegistration(string merchantCustomerID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            var request = new CustomerRegistrationRequest
            {
                MerchantCustomerID = merchantCustomerID
            };
            return CustomerRegistration(request);
        }

        #endregion

        public SessionStatusCallback ParseCallback(string json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return FromJson<SessionStatusCallback>(json);
        }

        #region RegistrationStatus

        public RegistrationStatusResponse RegistrationStatus(RegistrationStatusRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<RegistrationStatusRequest, RegistrationStatusResponse>(request, "RegistrationStatus");
        }

        public RegistrationStatusResponse RegistrationStatus(string merchantSessionID)
        {
            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantSessionID");

            var request = new RegistrationStatusRequest
            {
                MerchantSessionID = merchantSessionID
            };
            return RegistrationStatus(request);
        }

        #endregion
    }
}
