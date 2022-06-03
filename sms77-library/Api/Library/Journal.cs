using Newtonsoft.Json;

namespace sms77_library.Api.Library {
    public enum JournalType {
        inbound,
        outbound,
        replies,
        voice
    }
    
    public class JournalParams {
        [JsonProperty("date_from")] public string? DateFrom { get; set; }
        [JsonProperty("date_to")] public string? DateTo { get; set; }
        [JsonProperty("id")] public uint? Id { get; set; }
        [JsonProperty("state")] public string? State { get; set; }
        [JsonProperty("to")] public string? To { get; set; }
        [JsonProperty("type")] public JournalType Type { get; set; }
    }

    public class Journal {
        [JsonProperty("from")] public string From { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("price")] public string Price { get; set; }
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("timestamp")] public string Timestamp { get; set; }
        [JsonProperty("to")] public string Inbound { get; set; }
    }

    public class JournalOutbound : Journal {
        [JsonProperty("connection")] public string Connection { get; set; }
        [JsonProperty("dlr")] public string? Dlr { get; set; }
        [JsonProperty("dlr_timestamp")] public string? DlrTimestamp { get; set; }
        [JsonProperty("foreign_id")] public string? ForeignId { get; set; }
        [JsonProperty("label")] public string? Label { get; set; }
        [JsonProperty("latency")] public string? Latency { get; set; }
        [JsonProperty("mccmnc")] public string? MccMnc { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }
    
    public class JournalVoice : Journal {
        [JsonProperty("duration")] public string Duration { get; set; }
        [JsonProperty("error")] public string Error { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("xml")] public bool Xml { get; set; }
    }
}