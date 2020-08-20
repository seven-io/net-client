using Newtonsoft.Json;

namespace Sms77.Api.Library {
    public enum LookupType {
        format,
        cnam,
        hlr,
        mnp
    }

    public class CnamLookup {
        [JsonProperty("success")] public string Success { get; set; }
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("number")] public string Number { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }

    public class FormatLookup {
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("international")] public string International { get; set; }
        [JsonProperty("international_formatted")] public string InternationalFormatted { get; set; }
        [JsonProperty("national")] public string National { get; set; }
        [JsonProperty("country_iso")] public string CountryIso { get; set; }
        [JsonProperty("country_name")] public string CountryName { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("carrier")] public string Carrier { get; set; }
        [JsonProperty("network_type")] public string NetworkType { get; set; }
    }

    public class LookupParams {
        [JsonProperty("type")] public LookupType Type { get; set; }
        [JsonProperty("number")] public string Number { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }

    public class Mnp {
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("number")] public string Number { get; set; }
        [JsonProperty("international_formatted")] public string InternationalFormatted { get; set; }
        [JsonProperty("national_format")] public string NationalFormat { get; set; }
        [JsonProperty("network")] public string Network { get; set; }
        [JsonProperty("mccmnc")] public string MccMnc { get; set; }
        [JsonProperty("isPorted")] public bool IsPorted { get; set; }
    }

    public class Carrier {
        [JsonProperty("network_code")] public string NetworkCode { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("network_type")] public string NetworkType { get; set; }
    }

    public class HlrLookup {
        [JsonProperty("status")] public bool Status { get; set; }
        [JsonProperty("status_message")] public string StatusMessage { get; set; }
        [JsonProperty("lookup_outcome")] public bool LookupOutcome { get; set; }
        [JsonProperty("lookup_outcome_message")] public string LookupOutcomeMessage { get; set; }
        [JsonProperty("international_format_number")] public string InternationalFormatNumber { get; set; }
        [JsonProperty("international_formatted")] public string InternationalFormatted { get; set; }
        [JsonProperty("national_format_number")] public string NationalFormatNumber { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("country_name")] public string CountryName { get; set; }
        [JsonProperty("country_prefix")] public string CountryPrefix { get; set; }
        [JsonProperty("current_carrier")] public Carrier CurrentCarrier { get; set; }
        [JsonProperty("original_carrier")] public Carrier OriginalCarrier { get; set; }
        [JsonProperty("valid_number")] public string ValidNumber { get; set; }
        [JsonProperty("reachable")] public string Reachable { get; set; }
        [JsonProperty("ported")] public string Ported { get; set; }
        [JsonProperty("roaming")] public string Roaming { get; set; }
        [JsonProperty("gsm_code")] public string GsmCode { get; set; }
        [JsonProperty("gsm_message")] public string GsmMessage { get; set; }
    }

    public class MnpLookup {
        [JsonProperty("price")] public double Price { get; set; }
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("code")] public uint Code { get; set; }
        [JsonProperty("mnp")] public Mnp Mnp { get; set; }
    }
}