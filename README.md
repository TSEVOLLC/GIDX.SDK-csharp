# GIDX.SDK-csharp
A C# SDK for accessing the GIDX DirectAPI services.

Available via NuGet: [GIDX.SDK](https://www.nuget.org/packages/GIDX.SDK)

## Usage

### Creating a client

To make a request, you first need to create a **GIDXClient**.  Its constructor accepts a **MerchantCredentials** object which you should populate with the credentials we provide you.
```csharp
var credentials = new MerchantCredentials
{
    MerchantID = "[Insert MerchantID]",
    ApiKey = "[Insert ApiKey]",
    ProductTypeID = "[Insert ProductTypeID]",
    DeviceTypeID = "[Insert DeviceTypeID]",
    ActivityTypeID = "[Insert ActivityTypeID]"
};
var gidxClient = new GIDXClient(credentials);
```

### Customer Identity

#### Making a request

Each API method has a corresponding request object used to transport the request parameters as shown below.  The credentials that you passed to the **GIDXClient** constructor can be overridden here by setting the corresponding properties on the request object.

```csharp
var request = new CustomerRegistrationRequest
{
    //A GUID is generated below for MerchantCustomerID and MerchantSessionID for testing purposes only.
    //Ideally, you would pull these from your database.
    MerchantCustomerID = Guid.NewGuid().ToString("N"),
    MerchantSessionID = Guid.NewGuid().ToString("N"),
    FirstName = "Michael",
    LastName = "Bluth",
    DateOfBirth = DateTime.Parse("1967-12-14"),
    AddressLine1 = "1 Lucille Lane",
    City = "Sudden Valley",
    StateCode = "CA",
    PostalCode = "90001",
    EmailAddress = "michael.bluth@saveourbluths.org",
    DeviceIpAddress = "144.214.138.154"
};
var response = gidxClient.CustomerIdentity.CustomerRegistration(request);
```
**Note**: The data used in this example is just a sample and will not return any results. 

#### Using the response

Each response object returned from **GIDXClient** has properties you can use to determine the status of the response.  Use the **IsSuccess** property to know if the request completed without a problem.

```csharp
if (response.IsSuccess)
{
    //Continue on with your code here
}
```

### Document Library

#### Uploading a document

To upload a document, you will pass a **DocumentRegistrationRequest** request object, along with the file you would like to upload.

```csharp
var request = new DocumentRegistrationRequest
{
    //A GUID is generated below for MerchantCustomerID and MerchantSessionID for testing purposes only.
    //Ideally, you would pull these from your database.
    MerchantCustomerID = Guid.NewGuid().ToString("N"),
    MerchantSessionID = Guid.NewGuid().ToString("N"),
    CategoryType = CategoryType.Other,
    DocumentStatus = DocumentStatus.ReviewComplete
};

var response = gidxClient.DocumentLibrary.DocumentRegistration(request, @"C:\Path\To\File.png");

//Or if the file is not saved locally, you can load it into a Stream

var response = gidxClient.DocumentLibrary.DocumentRegistration(request, stream, "File.png");
```

#### Downloading a document

To download a document, you will pass its DocumentID.  If the request is successful, the **DownloadDocumentResponse** object will have its FileStream and FileName properties filled.  If the request was unsuccessful, the ResponseCode and ResponseMessage properties will be filled.

```csharp
var documentID = "abc123";
var merchantSessionID = Guid.NewGuid().ToString("N");
var response = gidxClient.DocumentLibrary.DownloadDocument(documentID, merchantSessionID);

if (response.IsSuccess)
{
    //The following code example will save the downloaded file to a local directory
    var localPath = System.IO.Path.Combine(@"C:\Path\To\Save", response.FileName);
    using (var localFileStream = System.IO.File.OpenWrite(localPath))
    {
        response.FileStream.CopyTo(localFileStream);
    }
}
```
