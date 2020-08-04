using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Pricing {
        [JsonPropertyName("countCountries")] public int CountCountries { get; set; }

        [JsonPropertyName("countNetworks")] public int CountNetworks { get; set; }

        [JsonPropertyName("countries")] public List<Country> Countries { get; set; }
    }
}