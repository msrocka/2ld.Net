using Newtonsoft.Json;

namespace openLCA.Schema
{
    public abstract class Entity
    {
        [JsonProperty(PropertyName = "@id", Order = 0)]
        public string ID;

        [JsonProperty(PropertyName = "@type", Order = 1)]
        public abstract string Type { get; }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, Formatting.Indented, settings);
        }
    }
}
