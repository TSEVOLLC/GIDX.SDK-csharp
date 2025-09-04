using GIDX.SDK.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    [JsonConverter(typeof(DiscriminatedJsonConverter), typeof(TransactionActionDiscriminatorOptions))]
    public abstract class TransactionAction
    {
        public abstract string Type { get; }
    }

    public class TransactionActionDiscriminatorOptions : DiscriminatorOptions
    {
        public override Type BaseType => typeof(TransactionAction);

        public override string DiscriminatorFieldName => nameof(TransactionAction.Type);

        public override bool SerializeDiscriminator => true;

        public override IEnumerable<(string TypeName, Type Type)> GetDiscriminatedTypes()
        {
            var types = new List<(string TypeName, Type Type)>
            {
                ("Open", typeof(OpenAction)),
                ("Paypal", typeof(PaypalAction)),
                ("3DSChallenge", typeof(ThreeDSChallengeAction))
            };

            return types;
        }
    }
}
