﻿using System;
using System.Threading.Tasks;
using GIDX.SDK.Models.CustomerIdentity;

namespace GIDX.SDK
{
    /// <summary>
    /// The client used to access the GIDX Customer Identity Direct API
    /// </summary>
    public interface ICustomerIdentityClient : IClient
    {
        /// <summary>
        /// Make a request to our CustomerMonitor endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CustomerMonitorResponse> CustomerMonitorAsync(CustomerMonitorRequest request);

        /// <summary>
        /// Make a request to our CustomerMonitor endpoint.
        /// </summary>
        /// <param name="merchantCustomerID"></param>
        /// <param name="merchantSessionID"></param>
        /// <returns></returns>
        Task<CustomerMonitorResponse> CustomerMonitorAsync(string merchantCustomerID, string merchantSessionID);

        /// <summary>
        /// Make a request to our CustomerProfile endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CustomerProfileResponse> CustomerProfileAsync(CustomerProfileRequest request);

        /// <summary>
        /// Make a request to our CustomerProfile endpoint.
        /// </summary>
        /// <param name="merchantCustomerID"></param>
        /// <param name="merchantSessionID"></param>
        /// <returns></returns>
        Task<CustomerProfileResponse> CustomerProfileAsync(string merchantCustomerID, string merchantSessionID);

        /// <summary>
        /// Make a request to our CustomerRegistration endpoint.
        /// </summary>
        /// <param name="request">The <see cref="Models.MerchantCredentials"/> fields on the request will default to the values in the client's <see cref="Credentials"/> property, but can be overridden if manually set on the <paramref name="request"/>.</param>
        /// <returns></returns>
        Task<CustomerRegistrationResponse> CustomerRegistrationAsync(CustomerRegistrationRequest request);

        /// <summary>
        /// Make a request to our Location endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LocationResponse> LocationAsync(LocationRequest request);

        /// <summary>
        /// Make a request to our RemoveCustomer endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RemoveCustomerResponse> RemoveCustomerAsync(RemoveCustomerRequest request);
    }
}
