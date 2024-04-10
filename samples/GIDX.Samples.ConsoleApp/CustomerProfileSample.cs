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
    internal class CustomerProfileSample : ISample
    {
        private readonly GIDXClient gidxClient;

        public CustomerProfileSample(GIDXClient gidxClient)
        {
            this.gidxClient = gidxClient;
        }

        public async Task Run()
        {
            //Replace with a MerchantCustomerID you have created
            string merchantCustomerID = "481ba6b8-f3a2-4802-9d5f-1c5f60fe6f36";
            var customerProfileResponse = await gidxClient.CustomerIdentity.CustomerProfileAsync(merchantCustomerID, Guid.NewGuid().ToString());
        }
    }
}
