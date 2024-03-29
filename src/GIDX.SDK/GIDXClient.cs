using System;
using System.IO;
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
        public const string GIDXHttpClientName = "GIDX";

        private const string DefaultDomain = "https://api.gidx-service.in";
        private const string DefaultVersion = "v3.0";
        
        private Uri _baseAddress;
        private HttpClient _httpClient;
        private IHttpClientFactory _httpClientFactory;
        private Func<HttpClient> _getHttpClient;

        /// <summary>
        /// Default credentials to use when sending requests.  Credentials can be overridden on the request objects themselves.
        /// </summary>
        public MerchantCredentials Credentials { get; set; }

        /// <summary>
        /// Initializes a client that will use the sandbox endpoint.
        /// </summary>
        /// <param name="credentials"></param>
        public GIDXClient(MerchantCredentials credentials)
            : this(credentials, DefaultDomain, DefaultVersion, (HttpClient)null)
        {
            
        }

        /// <summary>
        /// Initializes a client that will use the sandbox endpoint.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="httpClient">An HttpClient to use for HTTP requests.</param>
        public GIDXClient(MerchantCredentials credentials, HttpClient httpClient)
            : this(credentials, DefaultDomain, DefaultVersion, httpClient)
        {

        }

        /// <summary>
        /// Initializes a client that will use the domain and version provided instead of the sandbox endpoint.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="domain">The domain of the endpoint (ex: "https://api.gidx-service.in").</param>
        /// <param name="version">The API version number you want to use.</param>
        public GIDXClient(MerchantCredentials credentials, string domain, string version)
            : this(credentials, domain, version, (HttpClient)null)
        {

        }

        /// <summary>
        /// Initializes a client that will use the domain and version provided instead of the sandbox endpoint.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="domain">The domain of the endpoint (ex: "https://api.gidx-service.in").</param>
        /// <param name="version">The API version number you want to use.</param>
        /// <param name="httpClient">An HttpClient to use for HTTP requests.</param>
        public GIDXClient(MerchantCredentials credentials, string domain, string version, HttpClient httpClient)
        {
            if (version[0] != 'v')
                version = "v" + version;

            var path = string.Format("/{0}/api/", version);
            Init(credentials, new Uri(new Uri(domain), path), httpClient, null);
        }

        /// <summary>
        /// Initializes a client that will use the base address provided instead of concatenating the domain and version.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="baseAddress">The base address of the endpoint (ex: "https://api.gidx-service.in/v3.0/api/")</param>
        /// <param name="httpClient">An HttpClient to use for HTTP requests.</param>
        public GIDXClient(MerchantCredentials credentials, string baseAddress, HttpClient httpClient)
        {
            Init(credentials, new Uri(baseAddress), httpClient, null);
        }

        /// <summary>
        /// Initializes a client that will use the domain and version provided instead of the sandbox endpoint.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="domain">The domain of the endpoint (ex: "https://api.gidx-service.in").</param>
        /// <param name="version">The API version number you want to use.</param>
        /// <param name="httpClientFactory">An IHttpClientFactory to use to create HttpClients. A named client will be created using <see cref="GIDXHttpClientName"/>.</param>
        public GIDXClient(MerchantCredentials credentials, string domain, string version, IHttpClientFactory httpClientFactory)
        {
            if (version[0] != 'v')
                version = "v" + version;

            var path = string.Format("/{0}/api/", version);
            Init(credentials, new Uri(new Uri(domain), path), null, httpClientFactory);
        }

        /// <summary>
        /// Initializes a client that will use the base address provided instead of concatenating the domain and version.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="baseAddress">The base address of the endpoint (ex: "https://api.gidx-service.in/v3.0/api/")</param>
        /// <param name="httpClientFactory">An IHttpClientFactory to use to create HttpClients. A named client will be created using <see cref="GIDXHttpClientName"/>.</param>
        public GIDXClient(MerchantCredentials credentials, string baseAddress, IHttpClientFactory httpClientFactory)
        {
            Init(credentials, new Uri(baseAddress), null, httpClientFactory);
        }

        private void Init(MerchantCredentials credentials, Uri baseAddress, HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            Credentials = credentials;
            _baseAddress = baseAddress;

            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
            if (_httpClient == null && _httpClientFactory == null)
                _httpClient = new HttpClient();

            _getHttpClient = () => {
                if (_httpClientFactory == null)
                    return _httpClient;
                return _httpClientFactory.CreateClient(GIDXHttpClientName);
            };
        }

        #region Child Client Properties

        private ICustomerIdentityClient _customerIdentity;
        public ICustomerIdentityClient CustomerIdentity
        {
            get
            {
                if (_customerIdentity == null)
                    _customerIdentity = new CustomerIdentityClient(Credentials, _baseAddress, _getHttpClient);
                return _customerIdentity;
            }
        }

        private IDirectCashierClient _directCashier;
        public IDirectCashierClient DirectCashier
        {
            get
            {
                if (_directCashier == null)
                    _directCashier = new DirectCashierClient(Credentials, _baseAddress, _getHttpClient);
                return _directCashier;
            }
        }

        private IDocumentLibraryClient _documentLibrary;
        public IDocumentLibraryClient DocumentLibrary
        {
            get
            {
                if (_documentLibrary == null)
                    _documentLibrary = new DocumentLibraryClient(Credentials, _baseAddress, _getHttpClient);
                return _documentLibrary;
            }
        }

        private IWebCashierClient _webCashier;
        public IWebCashierClient WebCashier
        {
            get
            {
                if (_webCashier == null)
                    _webCashier = new WebCashierClient(Credentials, _baseAddress, _getHttpClient);
                return _webCashier;
            }
        }

        private IWebMyAccountClient _webMyAccount;
        public IWebMyAccountClient WebMyAccount
        {
            get
            {
                if (_webMyAccount == null)
                    _webMyAccount = new WebMyAccountClient(Credentials, _baseAddress, _getHttpClient);
                return _webMyAccount;
            }
        }

        private IWebRegClient _webReg;
        public IWebRegClient WebReg
        {
            get
            {
                if (_webReg == null)
                    _webReg = new WebRegClient(Credentials, _baseAddress, _getHttpClient);
                return _webReg;
            }
        }

        #endregion
    }
}
