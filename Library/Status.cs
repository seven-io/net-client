using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Status {
        public static Status FromString(string response) {
            string[] lines = Util.SplitByLine(response);

            return new Status {
                Code = lines[0],
                Timestamp = lines[1],
            };
        }
        
        [JsonPropertyName("code")] public string Code { get; set; }

        [JsonPropertyName("timestamp")] public string Timestamp { get; set; }
    }

    public class StatusParams {
        [JsonPropertyName("msg_id")] public ulong MsgId { get; set; }
    }
}