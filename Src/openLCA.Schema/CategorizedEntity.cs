using Newtonsoft.Json;

namespace openLCA.Schema
{
    public abstract class CategorizedEntity : RootEntity
    {
        [JsonProperty(PropertyName = "category", Order = 3)]
        public Ref Category;
    }
}
