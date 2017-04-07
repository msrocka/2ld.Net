using Newtonsoft.Json;

namespace openLCA.Schema
{

    public class FlowProperty : CategorizedEntity
    {
        public override string Type => "FlowProperty";

        [JsonProperty(PropertyName = "flowPropertyType", Order = 6)]
        public string FlowPropertyType;

        [JsonProperty(PropertyName = "unitGroup", Order = 7)]
        public Ref UnitGroup;

    }

    public sealed class FlowPropertyType
    {
        public static readonly string ECONOMIC_QUANTITY = "ECONOMIC_QUANTITY";
        public static readonly string PHYSICAL_QUANTITY = "PHYSICAL_QUANTITY";

        private FlowPropertyType()
        {
        }
    }
}
