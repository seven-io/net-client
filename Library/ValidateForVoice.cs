using Newtonsoft.Json;

namespace Sms77Api {
    public class ValidateForVoice {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("error")] public string Error { get; set; }
        [JsonProperty("formatted_output")] public string FormattedOutput { get; set; }
        [JsonProperty("id")] public long? Id { get; set; }
        [JsonProperty("sender")] public string Sender { get; set; }
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("voice")] public bool Voice { get; set; }
    }

    public class ValidateForVoiceParams {
        [JsonProperty("callback")] public string Callback { get; set; }
        [JsonProperty("number")] public string Number { get; set; }
    }
}