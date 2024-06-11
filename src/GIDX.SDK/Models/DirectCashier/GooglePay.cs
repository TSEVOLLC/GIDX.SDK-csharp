using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class GooglePay : PaymentMethod
    {
        public override string Type => "GooglePay";

        /// <summary>
        /// A JSON string of the full PaymentData object returned by the Google Pay SDK.
        /// </summary>
        public string PaymentData { get; set; }

        /// <summary>
        /// A JSON string of just the token information provided by the Google Pay SDK. (JSON path $.paymentMethodData.tokenizationData)
        /// </summary>
        /// <remarks>
        /// If <see cref="PaymentData"/> is provided, do not populate this.
        /// </remarks>
        public string WalletToken { get; set; }

        /// <summary>
        /// A masked version of the credit card number will be provided to GIDX by Google Pay
        /// </summary>
        public string CardNumber { get; set; }
        
        /// <summary>
        /// FirtSix will be populated by GIDX. You do not need to set it.
        /// </summary>
        public string FirstSix { get; set; }

        /// <summary>
        /// LastFour will be populated by GIDX. You do not need to set it.
        /// </summary>
        public string LastFour { get; set; }

        public string Network { get; set; }

        /// <summary>
        /// The Address Verification Service result for the credit card, based on the <see cref="PaymentMethod.BillingAddress"/> provided.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CreditCardAVSResult AVSResult { get; set; }

        /// <summary>
        /// The Card Verification Value result for the credit card.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CreditCardCVVResult CVVResult { get; set; }
    }
}
