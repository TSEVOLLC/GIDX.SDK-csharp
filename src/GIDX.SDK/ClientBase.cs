using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using Newtonsoft.Json;

namespace GIDX.SDK
{
    /// <summary>
    /// The base class that all child clients should inherit.  Includes common methods for submitting HTTP requests.
    /// </summary>
    internal abstract class ClientBase
    {
        protected readonly HttpClient _httpClient;
        private readonly JsonSerializer _jsonSerializer;
        private readonly Uri _baseAddress;

        public MerchantCredentials Credentials { get; set; }

        protected ClientBase(MerchantCredentials credentials, Uri baseAddress, HttpClient httpClient, string service)
        {
            Credentials = credentials;

            _baseAddress = baseAddress;
            if (!string.IsNullOrEmpty(service))
            {
                _baseAddress = new Uri(_baseAddress, service);
            }

            if (!_baseAddress.AbsoluteUri.EndsWith("/"))
            {
                //Make sure baseAddress ends in slash so that we can just pass the method name when making requests
                _baseAddress = new Uri(_baseAddress.AbsoluteUri + "/");
            }

            _httpClient = httpClient;

            //Creating a JsonSerializer instead of using JsonConvert because we don't want to use any default settings set by the application
            _jsonSerializer = JsonSerializer.Create();
        }

        protected TResponse SendPostRequest<TRequest, TResponse>(TRequest request, string endpoint)
            where TRequest : RequestBase
            where TResponse : ResponseBase, new()
        {
            SetCredentials(request);

            var requestJson = ToJson(request);

            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_baseAddress, endpoint)))
            {
                httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpRequest.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                var httpResponse = _httpClient.SendAsync(httpRequest).Result;

                return LoadResponse<TResponse>(httpResponse);
            }
        }

        protected TResponse SendGetRequest<TRequest, TResponse>(TRequest request, string endpoint)
            where TRequest : RequestBase
            where TResponse : ResponseBase, new()
        {
            var httpResponse = SendGetRequest<TRequest>(request, endpoint);
            return LoadResponse<TResponse>(httpResponse);
        }

        protected HttpResponseMessage SendGetRequest<TRequest>(TRequest request, string endpoint)
            where TRequest : RequestBase
        {
            SetCredentials(request);

            var queryString = BuildQueryString(request);
            var fullUrl = string.Format("{0}?{1}", endpoint, queryString);

            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, new Uri(_baseAddress, fullUrl)))
            {
                httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return _httpClient.SendAsync(httpRequest).Result;
            }
        }

        protected TResponse UploadFile<TRequest, TResponse>(TRequest request, Stream fileStream, string fileName, string endpoint)
            where TRequest : RequestBase
            where TResponse : ResponseBase, new()
        {
            SetCredentials(request);

            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_baseAddress, endpoint)))
            {
                httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestContent = new MultipartFormDataContent();

                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                requestContent.Add(fileContent, "file", fileName);

                string requestJson = ToJson(request);
                var jsonContent = new StringContent(requestJson);
                requestContent.Add(jsonContent, "json");

                httpRequest.Content = requestContent;
                var httpResponse = _httpClient.SendAsync(httpRequest).Result;

                return LoadResponse<TResponse>(httpResponse);
            }
        }

        protected TResponse LoadResponse<TResponse>(HttpResponseMessage httpResponse)
            where TResponse : ResponseBase, new()
        {
            TResponse response;

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseJson = httpResponse.Content.ReadAsStringAsync().Result;
                response = FromJson<TResponse>(responseJson);
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
        protected void SetCredentials(IMerchantCredentials credentials)
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
        protected string BuildQueryString<TRequest>(TRequest request)
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

        protected string ToJson(object o)
        {
            using(var stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                _jsonSerializer.Serialize(stringWriter, o);
                return stringWriter.ToString();
            }
        }

        protected T FromJson<T>(string json)
        {
            using (var jsonReader = new JsonTextReader(new StringReader(json)))
            {
                return _jsonSerializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
