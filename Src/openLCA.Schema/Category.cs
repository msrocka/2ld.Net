using Newtonsoft.Json;

namespace openLCA.Schema

{
    public class Category : CategorizedEntity
    {
        public override string Type => "Category";

        [JsonProperty(PropertyName = "modelType", Order = 5)]
        public string ModelType;
    }
}
