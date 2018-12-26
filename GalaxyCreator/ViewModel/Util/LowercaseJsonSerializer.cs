using GalaxyCreator.Model.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GalaxyCreator.ViewModel.Util
{
    public class ClusterConveter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<Cluster>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return existingValue;
            //throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var Clusters = value as List<Cluster>;

            foreach (Cluster c in Clusters)
            {
                if ( c.GameStart == false)
                {
                    c.FactionHq = null;
                    c.FactionStart = null;
                }
            }

            serializer.Serialize(writer, Clusters.Where(c => c.IsEnabled == true));

            //throw new NotImplementedException();
        }
    }

    public class LowercaseJsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        };

        public static void Serialize(TextWriter file, object o)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                ContractResolver = new LowercaseContractResolver(),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            serializer.Converters.Add(new ClusterConveter());
            serializer.Serialize(file, o);
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
            }
        }
    }
}
