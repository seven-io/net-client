using Newtonsoft.Json;

namespace seven_library.Api.Library {
    public enum StatusCode {
        DELIVERED,
        NOTDELIVERED,
        BUFFERED,
        TRANSMITTED,
        ACCEPTED,
        EXPIRED,
        REJECTED,
        FAILED,
        UNKNOWN
    }
    
    public class Status {
        public static Status FromString(string response) {
            string[] lines = Util.SplitByLine(response);

            return new Status {
                Code = lines[0],
                Timestamp = lines[1],
            };
        }
        
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("timestamp")] public string Timestamp { get; set; }
    }

    public class StatusParams {
        [JsonProperty("msg_id")] public ulong MsgId { get; set; }
    }
}