using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DocumentLibrary;

namespace GIDX.SDK
{
    internal class DocumentLibraryClient : ClientBase, IDocumentLibraryClient
    {
        public DocumentLibraryClient(MerchantCredentials credentials, Uri baseAddress)
            : base(credentials, baseAddress, "DocumentLibrary")
        {

        }

        public DocumentRegistrationResponse DocumentRegistration(DocumentRegistrationRequest request, string filePath)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (filePath == null)
                throw new ArgumentNullException("filePath");

            return DocumentRegistration(request, File.OpenRead(filePath), Path.GetFileName(filePath));
        }

        public DocumentRegistrationResponse DocumentRegistration(DocumentRegistrationRequest request, Stream fileStream, string fileName)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (fileStream == null)
                throw new ArgumentNullException("fileStream");

            return UploadFile<DocumentRegistrationRequest, DocumentRegistrationResponse>(request, fileStream, fileName, "DocumentRegistration");
        }

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

        public CustomerDocumentsResponse CustomerDocuments(CustomerDocumentsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return SendGetRequest<CustomerDocumentsRequest, CustomerDocumentsResponse>(request, "CustomerDocuments");
        }

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

        public DownloadDocumentResponse DownloadDocument(DownloadDocumentRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            DownloadDocumentResponse response = null;
            var httpResponse = SendGetRequest(request, "DownloadDocument");

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
    }
}
