using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using GIDX.SDK.Models;
using Newtonsoft.Json;

namespace GIDX.SDK
{
    public class GIDXClient : IGIDXClient
    {
        private const string DefaultDomain = "https://api.gidx-service.in";
        private const string DefaultVersion = "v2.01";

        private readonly HttpClient httpClient;

        /// <summary>
        /// Default credentials to use when sending requests.  Credentials can be overridden on the request objects themselves.
        /// </summary>
        public MerchantCredentials Credentials { get; set; }

        /// <summary>
        /// Initializes a client that will use the testing endpoint.
        /// </summary>
        /// <param name="credentials"></param>
        public GIDXClient(MerchantCredentials credentials)
            : this(credentials, DefaultDomain, DefaultVersion)
        {
            
        }

        /// <summary>
        /// Initializes a client that will use the domain and version provided instead of the testing endpoint.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="domain">The domain of the endpoint (ex: "https://api.gidx-service.in").</param>
        /// <param name="version">The API version number you want to use.</param>
        public GIDXClient(MerchantCredentials credentials, string domain, string version)
        {
            Credentials = credentials;

            if (version[0] != 'v')
                version = "v" + version;

            var path = string.Format("/{0}/api/", version);
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(new Uri(domain), path)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region Public Methods

        /// <summary>
        /// Make a request to our CustomerRegistration endpoint.
        /// </summary>
        /// <param name="request">The <see cref="MerchantCredentials"/> fields on the request will default to the values in the client's <see cref="Credentials"/> property, but can be overridden if manually set on the <paramref name="request"/>.</param>
        /// <returns></returns>
        public CustomerRegistrationResponse CustomerRegistration(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendPostRequest<CustomerRegistrationRequest, CustomerRegistrationResponse>(request, "CustomerIdentity/CustomerRegistration");
        }

        /// <summary>
        /// Make a request to our CustomerProfile endpoint.
        /// </summary>
        /// <param name="merchantCustomerID"></param>
        /// <param name="merchantSessionID"></param>
        /// <returns></returns>
        public CustomerProfileResponse CustomerProfile(string merchantCustomerID, string merchantSessionID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            var request = new CustomerProfileRequest
            {
                MerchantCustomerID = merchantCustomerID,
                MerchantSessionID = merchantSessionID
            };
            return CustomerProfile(request);
        }

        /// <summary>
        /// Make a request to our CustomerProfile endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CustomerProfileResponse CustomerProfile(CustomerProfileRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<CustomerProfileRequest, CustomerProfileResponse>(request, "CustomerIdentity/CustomerProfile");
        }

        #endregion

        #region Private Methods

        private TResponse SendPostRequest<TRequest, TResponse>(TRequest request, string endpoint)
            where TRequest : RequestBase
            where TResponse : ResponseBase, new()
        {
            SetCredentials(request);

            var requestJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var httpResponse = httpClient.PostAsync(endpoint, content).Result;

            return LoadResponse<TResponse>(httpResponse);
        }

        private TResponse SendGetRequest<TRequest, TResponse>(TRequest request, string endpoint)
            where TRequest : RequestBase
            where TResponse : ResponseBase, new()
        {
            SetCredentials(request);

            var queryString = BuildQueryString(request);
            var fullUrl = string.Format("{0}?{1}", endpoint, queryString);
            var httpResponse = httpClient.GetAsync(fullUrl).Result;

            return LoadResponse<TResponse>(httpResponse);
        }

        private TResponse LoadResponse<TResponse>(HttpResponseMessage httpResponse)
            where TResponse : ResponseBase, new()
        {
            TResponse response;

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseJson = httpResponse.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<TResponse>(responseJson);
            }
            else
            {
                //If the actual HTTP request failed (which hopefully will never happen!), use the corresponding
                //StatusCode and ReasonPhrase to populate the response
                response = new TResponse()
                {
                    ResponseCode = (int)httpResponse.StatusCode,
                    ResponseMessage = httpResponse.ReasonPhrase
                };
            }

            return response;
        }

        /// <summary>
        /// Uses the credentials stored in the <see cref="Credentials"/> property.  Values already set in <paramref name="credentials"/> will take precedence.
        /// </summary>
        /// <param name="credentials"></param>
        private void SetCredentials(IMerchantCredentials credentials)
        {
            //Set the default credentials only if they haven't already been overridden
            if (Credentials != null)
            {
                credentials.ApiKey = credentials.ApiKey ?? Credentials.ApiKey;
                credentials.MerchantID = credentials.MerchantID ?? Credentials.MerchantID;
                credentials.ProductTypeID = credentials.ProductTypeID ?? Credentials.ProductTypeID;
                credentials.DeviceTypeID = credentials.DeviceTypeID ?? Credentials.DeviceTypeID;
                credentials.ActivityTypeID = credentials.ActivityTypeID ?? Credentials.ActivityTypeID;
            }
        }

        /// <summary>
        /// Build a query string using the properties of an object.  Does not support properties that are collections since none of our GET requests use them.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private string BuildQueryString<TRequest>(TRequest request)
        {
            var properties = typeof(TRequest).GetProperties();

            var pairs = properties
                .Select(p => new
                {
                    Key = p.Name,
                    Value = p.GetValue(request)
                })
                .Where(p => p.Value != null)
                .Select(p => 
                    string.Format("{0}={1}",
                        WebUtility.UrlEncode(p.Key),
                        WebUtility.UrlEncode(p.Value.ToString()))
                ).ToList();

            return string.Join("&", pairs);
        }

        #endregion
    }
}
