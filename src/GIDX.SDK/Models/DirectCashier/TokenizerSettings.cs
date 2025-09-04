using GIDX.SDK.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    [JsonConverter(typeof(DiscriminatedJsonConverter), typeof(TokenizerSettingsDiscriminatorOptions))]
    public abstract class TokenizerSettings
    {
        public abstract string Type { get; }
    }

    public class TokenizerSettingsDiscriminatorOptions : DiscriminatorOptions
    {
        public override Type BaseType => typeof(TokenizerSettings);

        public override string DiscriminatorFieldName => nameof(TokenizerSettings.Type);

        public override bool SerializeDiscriminator => true;

        public override IEnumerable<(string TypeName, Type Type)> GetDiscriminatedTypes()
        {
            var types = new List<(string TypeName, Type Type)>
            {
                ("Evervault", typeof(EvervaultTokenizerSettings)),
                ("Finix", typeof(FinixTokenizerSettings))
            };

            return types;
        }
    }
}
