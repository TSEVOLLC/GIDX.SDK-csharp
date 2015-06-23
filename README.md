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

### Making a request
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
    EmailAddress = "michael.bluth@saveourbluths.org"
};
var response = gidxClient.CustomerRegistration(request);
```
**Note**: The data used in this example is just a sample and will not return any results. 

### Using the response
Each response object returned from **GIDXClient** has properties you can use to determine the status of the response.  Use the **IsSuccess** property to know if the request completed without a problem.
```csharp
if (response.IsSuccess)
{
    //Continue on with your code here
}
```
