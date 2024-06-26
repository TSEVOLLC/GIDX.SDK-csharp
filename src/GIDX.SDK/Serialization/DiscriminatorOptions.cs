﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Serialization
{
    public delegate object CustomObjectCreator(Type discriminatedType);

    public delegate void JsonPreprocessor(string discriminator, JObject jsonObject);

    /// <summary>
    ///     Extend this class to configure a type with a discriminator field.
    /// </summary>
    public abstract class DiscriminatorOptions
    {
        /// <summary>Gets the base type, which is typically (but not necessarily) abstract.</summary>
        public abstract Type BaseType { get; }

        /// <summary>Gets the name of the discriminator field.</summary>
        public abstract string DiscriminatorFieldName { get; }

        /// <summary>Returns true if the discriminator should be serialized to the CLR type; otherwise false.</summary>
        public abstract bool SerializeDiscriminator { get; }

        /// <summary>Gets the mappings from discriminator values to CLR types.</summary>
        public abstract IEnumerable<(string TypeName, Type Type)> GetDiscriminatedTypes();

        /// <summary>Callback that creates an object which will then be populated by the serializer.</summary>
        public CustomObjectCreator Activator { get; protected set; } = null;

        /// <summary>Callback that can optionally mutate the JObject before it is converted.</summary>
        public JsonPreprocessor Preprocessor { get; protected set; } = null;
    }
}
