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
        private const string DefaultDomain = "https://api.gidx-service.in";
        private const string DefaultVersion = "v2.01";

        private Uri _baseAddress;

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
            if (version[0] != 'v')
                version = "v" + version;

            var path = string.Format("/{0}/api/", version);
            Init(credentials, new Uri(new Uri(domain), path));
        }

        public GIDXClient(MerchantCredentials credentials, string baseAddress)
        {
            Init(credentials, new Uri(baseAddress));
        }

        private void Init(MerchantCredentials credentials, Uri baseAddress)
        {
            Credentials = credentials;
            _baseAddress = baseAddress;
        }

        #region Child Client Properties

        private ICustomerIdentityClient _customerIdentity;
        public ICustomerIdentityClient CustomerIdentity
        {
            get
            {
                if (_customerIdentity == null)
                    _customerIdentity = new CustomerIdentityClient(Credentials, _baseAddress);
                return _customerIdentity;
            }
        }

        private IDocumentLibraryClient _documentLibrary;
        public IDocumentLibraryClient DocumentLibrary
        {
            get
            {
                if (_documentLibrary == null)
                    _documentLibrary = new DocumentLibraryClient(Credentials, _baseAddress);
                return _documentLibrary;
            }
        }

        #endregion
    }
}
