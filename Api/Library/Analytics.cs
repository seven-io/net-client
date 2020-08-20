using Newtonsoft.Json;

namespace Sms77.Api.Library {
    public class AnalyticsParams {
        [JsonProperty("end")] public string End { get; set; }
        [JsonProperty("group_by")] public string GroupBy { get; set; }
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("start")] public string Start { get; set; }
        [JsonProperty("subaccounts")] public string Subaccounts { get; set; }
    }

    public class Analytics {
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("date")] public string Date { get; set; }
        [JsonProperty("direct")] public int Direct { get; set; }
        [JsonProperty("economy")] public int Economy { get; set; }
        [JsonProperty("hlr")] public int Hlr { get; set; }
        [JsonProperty("inbound")] public int Inbound { get; set; }
        [JsonProperty("mnp")] public int Mnp { get; set; }
        [JsonProperty("voice")] public int Voice { get; set; }
        [JsonProperty("usage_eur")] public double UsageEur { get; set; }
    }
}