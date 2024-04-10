using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DocumentLibrary;

namespace GIDX.SDK
{
    internal class DocumentLibraryClient : ClientBase, IDocumentLibraryClient
    {
        public DocumentLibraryClient(MerchantCredentials credentials, Uri baseAddress, Func<HttpClient> getHttpClient)
            : base(credentials, baseAddress, getHttpClient, "DocumentLibrary")
        {

        }

        #region CustomerDocuments

        public async Task<CustomerDocumentsResponse> CustomerDocumentsAsync(CustomerDocumentsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return await SendGetRequestAsync<CustomerDocumentsRequest, CustomerDocumentsResponse>(request, "CustomerDocuments");
        }

        public Task<CustomerDocumentsResponse> CustomerDocumentsAsync(string merchantCustomerID, string merchantSessionID)
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
            return CustomerDocumentsAsync(request);
        }

        public CustomerDocumentsResponse CustomerDocuments(CustomerDocumentsRequest request)
        {
            return CustomerDocumentsAsync(request).Result;
        }

        public CustomerDocumentsResponse CustomerDocuments(string merchantCustomerID, string merchantSessionID)
        {
            return CustomerDocumentsAsync(merchantCustomerID, merchantSessionID).Result;
        }

        #endregion

        #region DocumentRegistration

        public async Task<DocumentRegistrationResponse> DocumentRegistrationAsync(DocumentRegistrationRequest request, Stream fileStream, string fileName)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (fileStream == null)
                throw new ArgumentNullException("fileStream");

            return await UploadFileAsync<DocumentRegistrationRequest, DocumentRegistrationResponse>(request, fileStream, fileName, "DocumentRegistration");
        }

        public Task<DocumentRegistrationResponse> DocumentRegistrationAsync(DocumentRegistrationRequest request, string filePath)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (filePath == null)
                throw new ArgumentNullException("filePath");

            return DocumentRegistrationAsync(request, File.OpenRead(filePath), Path.GetFileName(filePath));
        }

        public DocumentRegistrationResponse DocumentRegistration(DocumentRegistrationRequest request, Stream fileStream, string fileName)
        {
            return DocumentRegistrationAsync(request, fileStream, fileName).Result;
        }

        public DocumentRegistrationResponse DocumentRegistration(DocumentRegistrationRequest request, string filePath)
        {
            return DocumentRegistrationAsync(request, filePath).Result;
        }

        #endregion

        #region DownloadDocument

        public async Task<DownloadDocumentResponse> DownloadDocumentAsync(DownloadDocumentRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            DownloadDocumentResponse response = null;
            var httpResponse = await SendGetRequestAsync(request, "DownloadDocument");

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
                response = await LoadResponseAsync<DownloadDocumentResponse>(httpResponse);
            }

            response.DocumentID = request.DocumentID;
            return response;
        }

        public Task<DownloadDocumentResponse> DownloadDocumentAsync(string documentID, string merchantSessionID)
        {
            if (documentID == null)
                throw new ArgumentNullException("documentID");

            var request = new DownloadDocumentRequest
            {
                DocumentID = documentID,
                MerchantSessionID = merchantSessionID
            };

            return DownloadDocumentAsync(request);
        }

        public DownloadDocumentResponse DownloadDocument(DownloadDocumentRequest request)
        {
            return DownloadDocumentAsync(request).Result;
        }

        public DownloadDocumentResponse DownloadDocument(string documentID, string merchantSessionID)
        {
            return DownloadDocumentAsync(documentID, merchantSessionID).Result;
        }

        #endregion
    }
}
