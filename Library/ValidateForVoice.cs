using System.Text.Json.Serialization;

namespace Sms77Api {
    public class ValidateForVoice {
        [JsonPropertyName("code")] public string Code { get; set; }

        [JsonPropertyName("error")] public string Error { get; set; }

        [JsonPropertyName("formatted_output")] public string FormattedOutput { get; set; }

        [JsonPropertyName("id")] public long? Id { get; set; }

        [JsonPropertyName("sender")] public string Sender { get; set; }

        [JsonPropertyName("success")] public bool Success { get; set; }

        [JsonPropertyName("voice")] public bool Voice { get; set; }
    }

    public class ValidateForVoiceParams {
        [JsonPropertyName("callback")] public string Callback { get; set; }

        [JsonPropertyName("number")] public string Number { get; set; }
    }
}