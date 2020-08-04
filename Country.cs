using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Country {
        [JsonPropertyName("countryCode")] public string CountryCode { get; set; }

        [JsonPropertyName("countryName")] public string CountryName { get; set; }

        [JsonPropertyName("countryPrefix")] public string CountryPrefix { get; set; }

        [JsonPropertyName("networks")] public List<Network> Networks { get; set; }
    }
}