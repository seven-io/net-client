using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Network {
        [JsonPropertyName("mcc")] public string Mcc { get; set; }

        [JsonPropertyName("mncs")] public List<string> Mncs { get; set; }

        [JsonPropertyName("networkName")] public string NetworkName { get; set; }

        [JsonPropertyName("price")] public double Price { get; set; }

        [JsonPropertyName("features")] public List<string> Features { get; set; }

        [JsonPropertyName("comment")] public string Comment { get; set; }
    }
}