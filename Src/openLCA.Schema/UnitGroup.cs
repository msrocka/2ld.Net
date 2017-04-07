using System.Collections.Generic;
using Newtonsoft.Json;

namespace openLCA.Schema
{
    public class UnitGroup : CategorizedEntity
    {
        public override string Type => "UnitGroup";

        [JsonProperty(PropertyName = "defaultFlowProperty", Order = 6)]
        public Ref DefaultFlowProperty;

        [JsonProperty(PropertyName = "units", Order = 6)]
        public readonly List<Unit> Units = new List<Unit>();
    }

    public class Unit : RootEntity
    {
        public override string Type => "Unit";

        [JsonProperty(PropertyName = "conversionFactor", Order = 6)]
        public double ConversionFactor;

        [JsonProperty(PropertyName = "referenceUnit", Order = 7)]
        public bool IsReferenceUnit;

    }
}
