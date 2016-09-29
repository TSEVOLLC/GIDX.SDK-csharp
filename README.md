# GIDX.SDK-csharp
A C# SDK for accessing the GIDX API services.

Available via NuGet: [GIDX.SDK](https://www.nuget.org/packages/GIDX.SDK)

### What's Here

- [Using the SDK](#using-the-sdk)
- [Customer Identity](#customer-identity)
  - [Direct API](#customer-identity-direct-api)
  - [Web API](#customer-identity-web-api)
- [Web Cashier](#web-cashier)
- [Upgrading to v2](#upgrading-to-v2)

## Using the SDK

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

### Making a request

Each API method has a corresponding request object used to transport the request parameters.  The credentials that you passed to the **GIDXClient** constructor can be overridden here by setting the corresponding properties on the request object.  See code below for examples.

### Using the response

Each response object returned from **GIDXClient** has properties you can use to determine the status of the response.  Use the **IsSuccess** property to know if the request completed without a problem.

```csharp
if (response.IsSuccess)
{
    //Continue on with your code here
}
```

## Customer Identity

### Customer Identity (Direct API)

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

### Customer Identity (Web API)

#### Creating a session

```csharp
var request = new WebReg.CreateSessionRequest
{
    //A GUID is generated below for MerchantCustomerID and MerchantSessionID for testing purposes only.
    //Ideally, you would pull these from your database.
    MerchantCustomerID = Guid.NewGuid().ToString("N"),
    MerchantSessionID = Guid.NewGuid().ToString("N"),
    CallbackURL = "http://www.yourserver.com/callback",
    FirstName = "Michael",
    LastName = "Bluth",
    EmailAddress = "michael.bluth@saveourbluths.org",
    CustomerIpAddress = "144.214.138.154"
};
var response = gidxClient.WebReg.CreateSession(request);

//response.SessionURL will contain the HTML of the script tag you should embed in your page
```

#### Getting the session status

```csharp
var response = gidxClient.WebReg.RegistrationStatus("[Original MerchantSessionID]");
```

#### Handling the callback

The SDK provides **SessionStatusCallback** and **SessionStatusCallbackResponse** models for you to use in your callback.  You can attempt to let your web framework handle the model binding or use the **ParseCallback** method provided by the SDK.

```csharp
var callback = gidxClient.WebReg.ParseCallback(callbackJson);

var callbackResponse = new WebReg.SessionStatusCallbackResponse
{
    MerchantID = gidxClient.Credentials.MerchantID,
    SessionStatus = "OK",
    CustomerID = "[Insert MerchantCustomerID]"
};

//Get customer details after registration is completed
var customerRegistration = gidxClient.WebReg.CustomerRegistration("[Insert MerchantCustomerID]");
```

## Web Cashier

### Creating a session

```csharp
var request = new WebCashier.CreateSessionRequest
{
    //A GUID is generated below for MerchantCustomerID, MerchantSessionID, MerchantOrderID and MerchantTransactionID for testing purposes only.
    //Ideally, you would pull these from your database.
    MerchantCustomerID = Guid.NewGuid().ToString("N"),
    MerchantSessionID = Guid.NewGuid().ToString("N"),
    MerchantOrderID = Guid.NewGuid().ToString("N"),
    MerchantTransactionID = Guid.NewGuid().ToString("N"),
    CallbackURL = "http://www.yourserver.com/callback",
    CustomerIpAddress = "144.214.138.154",
    PayActionCode = PayActionCode.Pay
};
var response = gidxClient.WebCashier.CreateSession(request);

//response.SessionURL will contain the HTML of the script tag you should embed in your page
```

### Getting the session status

```csharp
var response = gidxClient.WebCashier.WebCashierStatus("[Original MerchantSessionID]");
```

### Handling the callback

The SDK provides **SessionStatusCallback** and **SessionStatusCallbackResponse** models for you to use in your callback.  You can attempt to let your web framework handle the model binding or use the **ParseCallback** method provided by the SDK.

```csharp
var callback = gidxClient.WebCashier.ParseCallback(callbackJson);

var callbackResponse = new WebCashier.SessionStatusCallbackResponse
{
    MerchantID = gidxClient.Credentials.MerchantID,
    SessionStatus = "OK",
    MerchantTransactionID = callback.MerchantTransactionID
};

//Get payment details not returned in the callback
var paymentDetails = gidxClient.WebCashier.PaymentDetail(callback.MerchantTransactionID);
```

## Document Library

### Uploading a document

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

### Downloading a document

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

## Upgrading to v2

### Breaking changes

- **Sub-clients** - To stop the **GIDXClient** class from getting too big, API methods for different services were organized into sub-clients exposed as properties in **GIDXClient**

- **Model namespaces** - Models that aren't shared across sub-clients were moved into their own namespace under **GIDX.SDK.Models**

### Migration

#### Customer Identity (Direct API)

- **CustomerRegistration** and **CustomerProfile** methods were moved to the **CustomerIdentity** sub-client
- Models namespace is now **GIDX.SDK.Models.CustomerIdentity**

```csharp
using GIDX.SDK.Models.CustomerIdentity;

//v1
var response = gidxClient.CustomerRegistration(request);
//v2 equivalent
var response = gidxClient.CustomerIdentity.CustomerRegistration(request);
```

#### Document Library

- **DocumentRegistration**, **DownloadDocument** and **CustomerDocuments** methods were moved to the **DocumentLibrary** sub-client
- Models namespace is now **GIDX.SDK.Models.DocumentLibrary**

```csharp
using GIDX.SDK.Models.DocumentLibrary;

//v1
var response = gidxClient.DocumentRegistration(request, @"C:\Path\To\File.png");
//v2 equivalent
var response = gidxClient.DocumentLibrary.DocumentRegistration(request, @"C:\Path\To\File.png");
```
