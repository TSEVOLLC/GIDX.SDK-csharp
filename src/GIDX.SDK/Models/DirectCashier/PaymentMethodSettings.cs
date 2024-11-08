using GIDX.SDK.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    [JsonConverter(typeof(DiscriminatedJsonConverter), typeof(PaymentMethodSettingsDiscriminatorOptions))]
    public abstract class PaymentMethodSettings
    {
        public abstract string Type { get; }
    }

    public class PaymentMethodSettingsDiscriminatorOptions : DiscriminatorOptions
    {
        public override Type BaseType => typeof(PaymentMethodSettings);

        public override string DiscriminatorFieldName => nameof(PaymentMethodSettings.Type);

        public override bool SerializeDiscriminator => true;

        public override IEnumerable<(string TypeName, Type Type)> GetDiscriminatedTypes()
        {
            var types = new List<(string TypeName, Type Type)>
            {
                ("ACH", typeof(BankAccountSettings)),
                ("CC", typeof(CreditCardSettings)),
                ("Paypal", typeof(PaypalAccountSettings)),
                ("ApplePay", typeof(ApplePaySettings)),
                ("GooglePay", typeof(GooglePaySettings))
            };

            return types;
        }
    }
}
