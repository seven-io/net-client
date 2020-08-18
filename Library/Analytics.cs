using System.Text.Json.Serialization;

namespace Sms77Api {
    public class AnalyticsParams {
        [JsonPropertyName("end")] public string End { get; set; }

        [JsonPropertyName("group_by")] public string GroupBy { get; set; }

        [JsonPropertyName("label")] public string Label { get; set; }

        [JsonPropertyName("start")] public string Start { get; set; }

        [JsonPropertyName("subaccounts")] public string Subaccounts { get; set; }
    }

    public class Analytics {
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("date")] public string Date { get; set; }

        [JsonPropertyName("direct")] public int Direct { get; set; }

        [JsonPropertyName("economy")] public int Economy { get; set; }

        [JsonPropertyName("hlr")] public int Hlr { get; set; }

        [JsonPropertyName("inbound")] public int Inbound { get; set; }

        [JsonPropertyName("mnp")] public int Mnp { get; set; }

        [JsonPropertyName("voice")] public int Voice { get; set; }

        [JsonPropertyName("usage_eur")] public double UsageEur { get; set; }
    }
}