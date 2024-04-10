# GIDX.SDK-csharp
A C# SDK for accessing the GIDX API services.

Available via NuGet: [GIDX.SDK](https://www.nuget.org/packages/GIDX.SDK)

### What's Here

- [Using the SDK](#using-the-sdk)
  - [Creating a client](#creating-a-client)
  - [Dependency injection](#dependency-injection)
- [Samples](#samples)
- [Customer Identity](#customer-identity)
  - [Direct API](#customer-identity-direct-api)
  - [Web API](#customer-identity-web-api)
- [Direct Cashier](#direct-cashier)
- [Document Library](#document-library)
- [Upgrading to v3](#upgrading-to-v3)

## Using the SDK

### Creating a client

To make a request, you first need to create a **GIDXClient**.  There are multiple constructor overloads, but these are the possible parameters:
- A **MerchantCredentials** object which you should populate with the credentials we provide you.
- The GIDX domain you are connecting to: **GIDXClient.SandboxDomain** or **GIDXClient.ProductionDomain**
- The GIDX version: **GIDXClient.Version3**
- An **HttpClient** or **IHttpClientFactory**. If neither are provided, an **HttpClient** will be created for every instance of **GIDXClient**.
```csharp
var credentials = new MerchantCredentials
{
    MerchantID = "[Insert MerchantID]",
    ApiKey = "[Insert ApiKey]",
    ProductTypeID = "[Insert ProductTypeID]",
    DeviceTypeID = "[Insert DeviceTypeID]",
    ActivityTypeID = "[Insert ActivityTypeID]"
};
var gidxClient = new GIDXClient(credentials, GIDXClient.SandboxDomain, GIDXClient.Version3, httpClientFactory);
```

### Dependency injection

A working example can be found in the [GIDX.Samples.ConsoleApp project](./samples/GIDX.Samples.ConsoleApp/Program.cs). The relevant parts are below:
```csharp
//Use IHttpClientFactory to create HttpClient for GIDXClient
builder.Services.AddHttpClient(GIDXClient.GIDXHttpClientName);

//Using .net User Secrets for storing credentials. Replace "GIDXCredentials" with whatever your configuration section is called.
builder.Services.AddOptions<MerchantCredentials>()
    .BindConfiguration("GIDXCredentials");

builder.Services.AddScoped(sp =>
{
    //Choose between sandbox and production
    var domain = GIDXClient.SandboxDomain;
    var domain = GIDXClient.ProductionDomain;

    //Get MerchantCredentials registerd above
    var credentials = sp.GetRequiredService<IOptions<MerchantCredentials>>();

    //Get IHttpClientFactory registered above
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();

    return new GIDXClient(credentials.Value, domain, GIDXClient.Version3, httpClientFactory);
});
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

## Samples

For working samples, check out the [GIDX.Samples](./samples) solution in this repository.

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
    DeviceIpAddress = "144.214.138.154",
    DeviceGps = new DeviceGpsDetails {
        Latitude = 29.77637,
        Longitude = -95.4454449
    }
};
var response = await gidxClient.CustomerIdentity.CustomerRegistrationAsync(request);
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
    CustomerIpAddress = "144.214.138.154",
    DeviceGps = new DeviceGpsDetails {
        Latitude = 29.77637,
        Longitude = -95.4454449
    }
};
var response = await gidxClient.WebReg.CreateSessionAsync(request);

//response.SessionURL will contain the HTML of the script tag you should embed in your page
```

#### Getting the session status

```csharp
var response = await gidxClient.WebReg.RegistrationStatusAsync("[Original MerchantSessionID]");
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
var customerProfile = await gidxClient.CustomerIdentity.CustomerProfileAsync("[Insert MerchantCustomerID]", "[Insert MerchantSessionID]");
```

## Direct Cashier

### Creating and completing a session

For a full working example of creating a session, saving a payment method, and completing a session, look in the [DirectCashierSample](./samples/GIDX.Samples.ConsoleApp/DirectCashierSample.cs).

### Handling the callback

The SDK provides **SessionStatusCallback** and **SessionStatusCallbackResponse** models for you to use in your callback.  You can attempt to let your web framework handle the model binding or use the **ParseCallback** method provided by the SDK.

```csharp
var callback = gidxClient.DirectCashier.ParseCallback(callbackJson);

var callbackResponse = new DirectCashier.SessionStatusCallbackResponse
{
    MerchantID = gidxClient.Credentials.MerchantID,
    SessionStatus = "OK",
    MerchantTransactionID = callback.MerchantTransactionID
};

//Get payment details not returned in the callback
var paymentDetails = await gidxClient.DirectCashier.PaymentDetailAsync(callback.MerchantSessionID, callback.MerchantTransactionID);
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

var response = await gidxClient.DocumentLibrary.DocumentRegistrationAsync(request, @"C:\Path\To\File.png");

//Or if the file is not saved locally, you can load it into a Stream

var response = await gidxClient.DocumentLibrary.DocumentRegistrationAsync(request, stream, "File.png");
```

### Downloading a document

To download a document, you will pass its DocumentID.  If the request is successful, the **DownloadDocumentResponse** object will have its FileStream and FileName properties filled.  If the request was unsuccessful, the ResponseCode and ResponseMessage properties will be filled.

```csharp
var documentID = "abc123";
var merchantSessionID = Guid.NewGuid().ToString("N");
var response = await gidxClient.DocumentLibrary.DownloadDocumentAsync(documentID, merchantSessionID);

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

## Upgrading to v3

### Breaking changes

- **Target Framework** - Changed to .Net Standard 2.0
- **WebCashier Model namespaces** - Models shared by both WebCashier and DirectCashier were moved from **GIDX.SDK.Models.WebCashier** to **GIDX.SDK.Models**. Affected types are:
  - CashierPaymentAmount
  - PayActionCode
  - PaymentAmountCode
  - PaymentAmountType
  - PaymentDetail
  - PaymentStatusCode
  - RecurringInterval

### Non-breaking changes

- DirectCashier was added.
- Async methods were added for all API calls. The non-async methods were left for backwards compatibility.
- Support for IHttpClientFactory was added.