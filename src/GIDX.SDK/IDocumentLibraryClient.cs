using System;
using System.IO;
using System.Threading.Tasks;
using GIDX.SDK.Models.DocumentLibrary;

namespace GIDX.SDK
{
    /// <summary>
    /// The client used to access the GIDX Document Library Direct API
    /// </summary>
    public interface IDocumentLibraryClient : IClient
    {
        /// <summary>
        /// Make a request to our CustomerDocuments endpoint to get a list of uploaded documents attached to a customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CustomerDocumentsResponse> CustomerDocumentsAsync(CustomerDocumentsRequest request);

        /// <summary>
        /// Make a request to our CustomerDocuments endpoint to get a list of uploaded documents attached to a customer.
        /// </summary>
        /// <param name="merchantCustomerID"></param>
        /// <param name="merchantSessionID">Required.  Used for logging purposes.</param>
        /// <returns></returns>
        Task<CustomerDocumentsResponse> CustomerDocumentsAsync(string merchantCustomerID, string merchantSessionID);

        /// <summary>
        /// Make a request to our DocumentRegistration endpoint to upload a document and attach it to a MerchantCustomerID.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="fileStream">A stream of the file to upload</param>
        /// <param name="fileName">The name of the file to upload</param>
        /// <returns></returns>
        Task<DocumentRegistrationResponse> DocumentRegistrationAsync(DocumentRegistrationRequest request, Stream fileStream, string fileName);

        /// <summary>
        /// Make a request to our DocumentRegistration endpoint to upload a document and attach it to a MerchantCustomerID.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="filePath">The local file path of the file to upload</param>
        /// <returns></returns>
        Task<DocumentRegistrationResponse> DocumentRegistrationAsync(DocumentRegistrationRequest request, string filePath);

        /// <summary>
        /// Make a request to our DownloadDocument endpoint to download a file that was previously uploaded.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DownloadDocumentResponse> DownloadDocumentAsync(DownloadDocumentRequest request);

        /// <summary>
        /// Make a request to our DownloadDocument endpoint to download a file that was previously uploaded.
        /// </summary>
        /// <param name="documentID">The DocumentID of the file.  It is returned in the <see cref="Document"/> object from the DocumentRegistration and CustomerDocuments methods.</param>
        /// <param name="merchantSessionID">Required.  Used for logging purposes.</param>
        /// <returns></returns>
        Task<DownloadDocumentResponse> DownloadDocumentAsync(string documentID, string merchantSessionID);
    }
}
