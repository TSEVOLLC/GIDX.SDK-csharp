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
    internal class PaymentDetailSample : ISample
    {
        private readonly GIDXClient gidxClient;

        public PaymentDetailSample(GIDXClient gidxClient)
        {
            this.gidxClient = gidxClient;
        }

        public async Task Run()
        {
            //Replace with MerchantTransactionID and MerchantSessionID you have already created
            var merchantTransactionID = "20240410085002";
            var merchantSessionID = "7fd56efa-0b1d-4a4e-877c-3dce26994ae1";

            var paymentDetailResponse = await gidxClient.DirectCashier.PaymentDetailAsync(merchantSessionID, merchantTransactionID);
        }
    }
}
