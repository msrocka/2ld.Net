using Newtonsoft.Json;

namespace openLCA.Schema
{
    public abstract class RootEntity : Entity
    {
        [JsonProperty(PropertyName = "name", Order = 2)]
        public string Name;

        [JsonProperty(PropertyName = "description", Order = 4)]
        public string Description;
    }
}
