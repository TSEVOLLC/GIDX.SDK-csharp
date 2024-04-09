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
    internal class CustomerUpdateSample : ISample
    {
        private readonly GIDXClient gidxClient;

        public CustomerUpdateSample(GIDXClient gidxClient)
        {
            this.gidxClient = gidxClient;
        }

        public async Task Run()
        {
            var customerUpdateRequest = new CustomerUpdateRequest
            {
                MerchantSessionID = Guid.NewGuid().ToString(),
                MerchantCustomerID = "481ba6b8-f3a2-4802-9d5f-1c5f60fe6f36",
                Verified = true
            };

            var customerUpdateResponse = gidxClient.CustomerIdentity.CustomerUpdateAsync(customerUpdateRequest).Result;
            //var customerUpdateResponse = await gidxClient.CustomerIdentity.CustomerUpdateAsync(customerUpdateRequest);
        }
    }
}
