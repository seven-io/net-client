using System.Text.Json.Serialization;

namespace Sms77Api {
    public enum LookupType {
        format,
        cnam,
        hlr,
        mnp
    }

    public class CnamLookup {
        [JsonPropertyName("success")] public string Success { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("number")] public string Number { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public class FormatLookup {
        [JsonPropertyName("success")] public bool Success { get; set; }
        [JsonPropertyName("international")] public string International { get; set; }

        [JsonPropertyName("international_formatted")]
        public string InternationalFormatted { get; set; }

        [JsonPropertyName("national")] public string National { get; set; }
        [JsonPropertyName("country_iso")] public string CountryIso { get; set; }
        [JsonPropertyName("country_name")] public string CountryName { get; set; }
        [JsonPropertyName("country_code")] public string CountryCode { get; set; }
        [JsonPropertyName("carrier")] public string Carrier { get; set; }
        [JsonPropertyName("network_type")] public string NetworkType { get; set; }
    }

    public class LookupParams {
        [JsonPropertyName("type")] public LookupType Type { get; set; }
        [JsonPropertyName("number")] public string Number { get; set; }
        [JsonPropertyName("json")] public bool? Json { get; set; }
    }

    public class Mnp {
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("number")] public string Number { get; set; }

        [JsonPropertyName("international_formatted")]
        public string InternationalFormatted { get; set; }

        [JsonPropertyName("national_format")] public string NationalFormat { get; set; }
        [JsonPropertyName("network")] public string Network { get; set; }
        [JsonPropertyName("mccmnc")] public string MccMnc { get; set; }
        [JsonPropertyName("isPorted")] public bool IsPorted { get; set; }
    }

    public class Carrier {
        [JsonPropertyName("network_code")] public string NetworkCode { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("network_type")] public string NetworkType { get; set; }
    }

    public class HlrLookup {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("status_message")] public string StatusMessage { get; set; }
        [JsonPropertyName("lookup_outcome")] public bool LookupOutcome { get; set; }

        [JsonPropertyName("lookup_outcome_message")]
        public string LookupOutcomeMessage { get; set; }

        [JsonPropertyName("international_format_number")]
        public string InternationalFormatNumber { get; set; }

        [JsonPropertyName("international_formatted")]
        public string InternationalFormatted { get; set; }

        [JsonPropertyName("national_format_number")]
        public string NationalFormatNumber { get; set; }

        [JsonPropertyName("country_code")] public string CountryCode { get; set; }
        [JsonPropertyName("country_name")] public string CountryName { get; set; }
        [JsonPropertyName("country_prefix")] public string CountryPrefix { get; set; }
        [JsonPropertyName("current_carrier")] public Carrier CurrentCarrier { get; set; }
        [JsonPropertyName("original_carrier")] public Carrier OriginalCarrier { get; set; }
        [JsonPropertyName("valid_number")] public string ValidNumber { get; set; }
        [JsonPropertyName("reachable")] public string Reachable { get; set; }
        [JsonPropertyName("ported")] public string Ported { get; set; }
        [JsonPropertyName("roaming")] public string Roaming { get; set; }
        [JsonPropertyName("gsm_code")] public string GsmCode { get; set; }
        [JsonPropertyName("gsm_message")] public string GsmMessage { get; set; }
    }

    public class MnpLookup {
        [JsonPropertyName("price")] public double Price { get; set; }
        [JsonPropertyName("success")] public bool Success { get; set; }
        [JsonPropertyName("code")] public uint Code { get; set; }
        [JsonPropertyName("mnp")] public Mnp Mnp { get; set; }
    }
}