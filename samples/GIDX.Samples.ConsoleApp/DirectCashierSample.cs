using GIDX.SDK;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DirectCashier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.Samples.ConsoleApp
{
    internal class DirectCashierSample : ISample
    {
        private readonly GIDXClient gidxClient;
        
        public DirectCashierSample(GIDXClient gidxClient)
        {
            this.gidxClient = gidxClient;
        }

        public async Task Run()
        {
            /* Steps
             * 1. Call CreateSession
             * 2. Call SavePaymentMethod to get credit card token
             * 3. Call CompleteSession with the credit card's token
             */

            //Replace with a MerchantCustomerID you have already verified via CustomerRegistration
            var merchantCustomerID = "481ba6b8-f3a2-4802-9d5f-1c5f60fe6f36";

            var createSessionRequest = new CreateSessionRequest
            {
                MerchantSessionID = Guid.NewGuid().ToString(),
                MerchantCustomerID = merchantCustomerID,
                MerchantTransactionID = DateTime.Now.ToString("yyyyMMddhhmmss"),
                PayActionCode = PayActionCode.Pay,
                CallbackURL = "https://callback url here",
                DeviceIpAddress = "167.67.11.74",
                DeviceGps = new DeviceGpsDetails
                {
                    Latitude = 29.77637,
                    Longitude = -95.4454449
                }
            };
            createSessionRequest.MerchantOrderID = createSessionRequest.MerchantTransactionID;

            var createSessionResponse = await gidxClient.DirectCashier.CreateSessionAsync(createSessionRequest);

            if (createSessionResponse.IsSuccess)
            {
                //In a real implementation, you will be making this PaymentMethod call on the user's device so you never have to send the credit card number to your servers.
                //This step is here just to illustrate all the API calls you need to make.
                var savePaymentMethodRequest = new SavePaymentMethodRequest
                {
                    MerchantSessionID = createSessionRequest.MerchantSessionID,
                    PaymentMethod = new CreditCard
                    {
                        CardNumber = "4111111111111111",
                        CVV = "123",
                        ExpirationDate = "12/28",
                        NameOnAccount = "Nicholas Miller",
                        BillingAddress = new Address
                        {
                            AddressLine1 = "123 Main St",
                            City = "Houston",
                            StateCode = "TX",
                            PostalCode = "77001"
                        }
                    }
                };
                var savePaymentMethodResponse = await gidxClient.DirectCashier.SavePaymentMethodAsync(savePaymentMethodRequest);

                var completeSessionRequest = new CompleteSessionRequest
                {
                    MerchantSessionID = createSessionRequest.MerchantSessionID,
                    PaymentAmount = new CashierPaymentAmount
                    {
                        PaymentAmount = 20
                    },
                    PaymentMethod = new CreditCard
                    {
                        Token = savePaymentMethodResponse.PaymentMethod.Token,
                        CVV = "123"
                    }
                };

                var completeSessionResponse = await gidxClient.DirectCashier.CompleteSessionAsync(completeSessionRequest);
            }
        }
    }
}
