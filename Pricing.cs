using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Country {
        [JsonPropertyName("countryCode")] public string CountryCode { get; set; }

        [JsonPropertyName("countryName")] public string CountryName { get; set; }

        [JsonPropertyName("countryPrefix")] public string CountryPrefix { get; set; }

        [JsonPropertyName("networks")] public List<Network> Networks { get; set; }
    }

    public class Pricing {
        [JsonPropertyName("countCountries")] public int CountCountries { get; set; }

        [JsonPropertyName("countNetworks")] public int CountNetworks { get; set; }

        [JsonPropertyName("countries")] public List<Country> Countries { get; set; }
    }

    public class Network {
        [JsonPropertyName("mcc")] public string Mcc { get; set; }

        [JsonPropertyName("mncs")] public List<string> Mncs { get; set; }

        [JsonPropertyName("networkName")] public string NetworkName { get; set; }

        [JsonPropertyName("price")] public double Price { get; set; }

        [JsonPropertyName("features")] public List<string> Features { get; set; }

        [JsonPropertyName("comment")] public string Comment { get; set; }
    }
}