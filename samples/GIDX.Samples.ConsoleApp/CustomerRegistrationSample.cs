using GIDX.SDK;
using GIDX.SDK.Models;
using GIDX.SDK.Models.CustomerIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.Samples.ConsoleApp
{
    internal class CustomerRegistrationSample : ISample
    {
        private readonly GIDXClient gidxClient;

        public CustomerRegistrationSample(GIDXClient gidxClient)
        {
            this.gidxClient = gidxClient;
        }

        public async Task Run()
        {
            //Replace the user information below with a real person's data, or from the test data provided to you.
            //The information below as is will not result in a verified user.
            var customerRegistrationRequest = new CustomerRegistrationRequest
            {
                MerchantSessionID = Guid.NewGuid().ToString(),
                MerchantCustomerID = Guid.NewGuid().ToString(),
                DeviceIpAddress = "167.67.11.74",
                DeviceGps = new DeviceGpsDetails
                {
                    Latitude = 29.77637,
                    Longitude = -95.4454449
                },
                EmailAddress = "email@email.com",
                FirstName = "Paul",
                LastName = "Atreides",
                DateOfBirth = DateTime.Parse("08/01/1965"),
                AddressLine1 = "123 Main St",
                City = "Houston",
                StateCode = "TX",
                PostalCode = "77001",
                CitizenshipCountryCode = "US"
            };

            var customerRegistrationResponse = await gidxClient.CustomerIdentity.CustomerRegistrationAsync(customerRegistrationRequest);
        }
    }
}
