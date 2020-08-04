using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Status {
        [JsonPropertyName("code")] public string Code { get; set; }

        [JsonPropertyName("timestamp")] public string Timestamp { get; set; }
    }

    public enum StatusCode {
        Delivered,
        NotDelivered,
        Buffered,
        Transmitted,
        Accepted,
        Expired,
        Rejected,
        Failed,
        Unknown,
    }
}