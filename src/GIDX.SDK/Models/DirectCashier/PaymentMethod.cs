using GIDX.SDK.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    [JsonConverter(typeof(DiscriminatedJsonConverter), typeof(PaymentMethodDiscriminatorOptions))]
    public abstract class PaymentMethod
    {
        public abstract string Type { get; }

        public string Token { get; set; }
        public string DisplayName { get; set; }
        public string NameOnAccount { get; set; }
        public Address BillingAddress { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PaymentMethodDiscriminatorOptions : DiscriminatorOptions
    {
        public override Type BaseType => typeof(PaymentMethod);

        public override string DiscriminatorFieldName => nameof(PaymentMethod.Type);

        public override bool SerializeDiscriminator => true;

        public override IEnumerable<(string TypeName, Type Type)> GetDiscriminatedTypes()
        {
            var types = new List<(string TypeName, Type Type)>
            {
                (PaymentMethodType.BankAcount, typeof(BankAccount)),
                (PaymentMethodType.CreditCard, typeof(CreditCard)),
                (PaymentMethodType.Paypal, typeof(PaypalAccount)),
                (PaymentMethodType.ApplePay, typeof(ApplePay)),
                (PaymentMethodType.GooglePay, typeof(GooglePay))
            };

            return types;
        }
    }
}
