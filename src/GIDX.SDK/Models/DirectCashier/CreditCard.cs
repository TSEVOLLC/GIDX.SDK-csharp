using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class CreditCard : PaymentMethod
    {
        public override string Type => "CC";

        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
        public string Network { get; set; }

        /// <summary>
        /// 3D Secure values received for the card. Not required.
        /// </summary>
        public ThreeDS ThreeDS { get; set; }

        /// <summary>
        /// FirtSix will be populated by GIDX. You do not need to set it.
        /// </summary>
        public string FirstSix { get; set; }

        /// <summary>
        /// LastFour will be populated by GIDX. You do not need to set it.
        /// </summary>
        public string LastFour { get; set; }

        /// <summary>
        /// The Address Verification Service result for the credit card, based on the <see cref="PaymentMethod.BillingAddress"/> provided.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CreditCardAVSResult AVSResult { get; set; }

        /// <summary>
        /// The Card Verification Value result for the credit card, based on the <see cref="CVV"/> provided.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CreditCardCVVResult CVVResult { get; set; }
    }
}
