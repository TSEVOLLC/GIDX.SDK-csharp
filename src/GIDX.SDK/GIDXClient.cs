using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using GIDX.SDK.Models;
using GIDX.SDK.Models.CustomerIdentity;
using GIDX.SDK.Models.DocumentLibrary;
using Newtonsoft.Json;

namespace GIDX.SDK
{
    public class GIDXClient : IGIDXClient
    {
        private const string DefaultDomain = "https://api.gidx-service.in";
        private const string DefaultVersion = "v2.01";

        private HttpClient httpClient;

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

            httpClient = new HttpClient()
            {
                BaseAddress = baseAddress
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region CustomerIdentity Methods

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

        #region DocumentLibrary Methods
        
        /// <summary>
        /// Make a request to our DocumentRegistration endpoint to upload a document and attach it to a MerchantCustomerID.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="filePath">The local file path of the file to upload</param>
        /// <returns></returns>
        public DocumentRegistrationResponse DocumentRegistration(DocumentRegistrationRequest request, string filePath)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (filePath == null)
                throw new ArgumentNullException("filePath");

            return DocumentRegistration(request, File.OpenRead(filePath), Path.GetFileName(filePath));
        }
        
        /// <summary>
        /// Make a request to our DocumentRegistration endpoint to upload a document and attach it to a MerchantCustomerID.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="fileStream">A stream of the file to upload</param>
        /// <param name="fileName">The name of the file to upload</param>
        /// <returns></returns>
        public DocumentRegistrationResponse DocumentRegistration(DocumentRegistrationRequest request, Stream fileStream, string fileName)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (fileStream == null)
                throw new ArgumentNullException("fileStream");
            
            return UploadFile<DocumentRegistrationRequest, DocumentRegistrationResponse>(request, fileStream, fileName, "DocumentLibrary/DocumentRegistration");
        }

        /// <summary>
        /// Make a request to our CustomerDocuments endpoint to get a list of uploaded documents attached to a customer.
        /// </summary>
        /// <param name="merchantCustomerID"></param>
        /// <param name="merchantSessionID">Required.  Used for logging purposes.</param>
        /// <returns></returns>
        public CustomerDocumentsResponse CustomerDocuments(string merchantCustomerID, string merchantSessionID)
        {
            if (merchantCustomerID == null)
                throw new ArgumentNullException("merchantCustomerID");

            if (merchantSessionID == null)
                throw new ArgumentNullException("merchantSessionID");

            var request = new CustomerDocumentsRequest
            {
                MerchantCustomerID = merchantCustomerID,
                MerchantSessionID = merchantSessionID
            };
            return CustomerDocuments(request);
        }

        /// <summary>
        /// Make a request to our CustomerDocuments endpoint to get a list of uploaded documents attached to a customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CustomerDocumentsResponse CustomerDocuments(CustomerDocumentsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<CustomerDocumentsRequest, CustomerDocumentsResponse>(request, "DocumentLibrary/CustomerDocuments");
        }

        /// <summary>
        /// Make a request to our DownloadDocument endpoint to download a file that was previously uploaded.
        /// </summary>
        /// <param name="documentID">The DocumentID of the file.  It is returned in the <see cref="Document"/> object from the DocumentRegistration and CustomerDocuments methods.</param>
        /// <param name="merchantSessionID">Required.  Used for logging purposes.</param>
        /// <returns></returns>
        public DownloadDocumentResponse DownloadDocument(string documentID, string merchantSessionID)
        {
            if (documentID == null)
                throw new ArgumentNullException("documentID");

            var request = new DownloadDocumentRequest
            {
                DocumentID = documentID,
                MerchantSessionID = merchantSessionID
            };

            return DownloadDocument(request);
        }

        /// <summary>
        /// Make a request to our DownloadDocument endpoint to download a file that was previously uploaded.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DownloadDocumentResponse DownloadDocument(DownloadDocumentRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            DownloadDocumentResponse response = null;
            var httpResponse = SendGetRequest(request, "DocumentLibrary/DownloadDocument");

            //The DownloadDocument endpoint will return either the file as an attachment, or a JSON object if there was an error.

            //DispositionType will be attachment if file was successfully returned.
            if (httpResponse.Content.Headers.ContentDisposition != null && httpResponse.Content.Headers.ContentDisposition.DispositionType == "attachment")
            {
                response = new DownloadDocumentResponse
                {
                    FileStream = httpResponse.Content.ReadAsStreamAsync().Result,
                    FileName = httpResponse.Content.Headers.ContentDisposition.FileName
                };
            }
            else
            {
                //File was not successfully returned, check for JSON response instead
                response = LoadResponse<DownloadDocumentResponse>(httpResponse);
            }

            response.DocumentID = request.DocumentID;
            return response;
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
            var httpResponse = SendGetRequest<TRequest>(request, endpoint);
            return LoadResponse<TResponse>(httpResponse);
        }

        private HttpResponseMessage SendGetRequest<TRequest>(TRequest request, string endpoint)
            where TRequest : RequestBase
        {
            SetCredentials(request);

            var queryString = BuildQueryString(request);
            var fullUrl = string.Format("{0}?{1}", endpoint, queryString);
            var httpResponse = httpClient.GetAsync(fullUrl).Result;

            return httpResponse;
        }

        private TResponse UploadFile<TRequest, TResponse>(TRequest request, Stream fileStream, string fileName, string endpoint)
            where TRequest : RequestBase
            where TResponse : ResponseBase, new()
        {
            SetCredentials(request);

            var requestContent = new MultipartFormDataContent();

            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            requestContent.Add(fileContent, "file", fileName);

            string requestJson = JsonConvert.SerializeObject(request);
            var jsonContent = new StringContent(requestJson);
            requestContent.Add(jsonContent, "json");

            var httpResponse = httpClient.PostAsync(endpoint, requestContent).Result;

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
