using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Status {
        [JsonPropertyName("code")] public string Code { get; set; }

        [JsonPropertyName("timestamp")] public string Timestamp { get; set; }
    }

    public class StatusParams {
        [JsonPropertyName("msg_id")] public long MsgId { get; set; }
    }
}