using System.Collections.Generic;
using Newtonsoft.Json;

namespace openLCA.Schema
{
    public class Process : CategorizedEntity
    {
        public override string Type => "Process";

        [JsonProperty(PropertyName = "processType", Order = 6)]
        public string ProcessType;

        [JsonProperty(PropertyName = "exchanges", Order = 7)]
        public readonly List<Exchange> Exchanges = new List<Exchange>();
    }

    public sealed class ProcessType
    {
        public static readonly string LCI_RESULT = "LCI_RESULT";
        public static readonly string UNIT_PROCESS = "UNIT_PROCESS";

        private ProcessType()
        {
        }
    }

    public class Exchange : Entity
    {
        public override string Type => "Exchange";

        [JsonProperty(PropertyName = "flow", Order = 6)]
        public Ref Flow;

        [JsonProperty(PropertyName = "flowProperty", Order = 7)]
        public Ref FlowProperty;

        [JsonProperty(PropertyName = "input", Order = 8)]
        public bool IsInput;

        [JsonProperty(PropertyName = "quantitativeReference", Order = 9)]
        public bool IsQuantitativeReference;

        [JsonProperty(PropertyName = "amount", Order = 10)]
        public double Amount;

        [JsonProperty(PropertyName = "unit", Order = 6)]
        public Ref Unit;
    }
}
