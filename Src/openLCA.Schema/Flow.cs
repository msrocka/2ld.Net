using System.Collections.Generic;
using Newtonsoft.Json;

namespace openLCA.Schema
{
    public class Flow : CategorizedEntity
    {
        public override string Type => "Flow";

        [JsonProperty(PropertyName = "flowType", Order = 6)]
        public string FlowType;

        [JsonProperty(PropertyName = "flowProperties", Order = 7)]
        public readonly List<FlowPropertyFactor> FlowProperties = new List<FlowPropertyFactor>();

    }

    public class FlowPropertyFactor : Entity
    {
        public override string Type => "FlowPropertyFactor";

        [JsonProperty(PropertyName = "flowProperty", Order = 5)]
        public Ref FlowProperty;

        [JsonProperty(PropertyName = "conversionFactor", Order = 6)]
        public double ConversionFactor;

        [JsonProperty(PropertyName = "referenceFlowProperty", Order = 7)]
        public bool IsReferenceFlowProperty;
    }
    
    public sealed class FlowType
    {
        public static readonly string ELEMENTARY_FLOW = "ELEMENTARY_FLOW";
        public static readonly string PRODUCT_FLOW = "PRODUCT_FLOW";
        public static readonly string WASTE_FLOW = "WASTE_FLOW";

        private FlowType()
        {
        }
    }

}
