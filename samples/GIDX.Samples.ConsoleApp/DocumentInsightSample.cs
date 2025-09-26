using GIDX.SDK;
using GIDX.SDK.Models;
using GIDX.SDK.Models.DocumentInsight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.Samples.ConsoleApp
{
    internal class DocumentInsightSample : ISample
    {
        private readonly GIDXClient gidxClient;
        
        public DocumentInsightSample(GIDXClient gidxClient)
        {
            this.gidxClient = gidxClient;
        }

        public async Task Run()
        {
            var createSessionRequest = new CreateSessionRequest
            {
                MerchantSessionID = Guid.NewGuid().ToString(),
                MerchantCustomerID = Guid.NewGuid().ToString(),
                DeviceIpAddress = "167.67.11.74",
                DeviceGps = new DeviceGpsDetails
                {
                    Latitude = 29.77637,
                    Longitude = -95.4454449
                },
                CallbackURL = "https://callback url here",
                ReasonCode = "DOC-VERIFIED" //In sandbox, provide either DOC-VERIFIED or DOC-FAIL to simulate final decision.
            };

            var createSessionResponse = await gidxClient.DocumentInsight.CreateSessionAsync(createSessionRequest);

            //After the user completes the session, you will get a callback. You can also call the SessionStatus API at anytime to find out the current status.
            var sessionStatusResponse = await gidxClient.DocumentInsight.SessionStatusAsync(createSessionRequest.MerchantSessionID);
        }
    }
}
