# How to use GIDX.Samples.ConsoleApp

## Credentials

The application uses User Secrets to store your credentials. To set it up with your credentials, open the solution, right-click the GIDX.Samples.ConsoleApp project and choose "Manage User Secrets". In the JSON file that opens, enter your credentials in the format below.
```json
{
  "GIDXCredentials:MerchantID": "[Insert your MerchantID]",
  "GIDXCredentials:ApiKey": "[Insert your ApiKey]",
  "GIDXCredentials:ProductTypeID": "[Insert your ProductTypeID]",
  "GIDXCredentials:ActivityTypeID": "[Insert your ActivityTypeID]",
  "GIDXCredentials:DeviceTypeID": "[Insert your DeviceTypeID]"
}
```

## Running Samples

Choose which sample you want to run by commenting and uncommenting lines 44-48 of Program.cs. 

For samples that act on existing customers and transactions, you will need to open the samples and fill in the correct IDs.

For example, **CustomerProfileSample** requires you to provide a MerchantCustomerID that you have previously registered.

Open each sample to see what values you need to provide before running them.