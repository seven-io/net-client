using System;
using System.Text.Json.Serialization;

namespace Sms77Api {
    public class Voice {
        public Voice(string response = null) {
            if (null != response) {
                var lines = Util.SplitByLine(response);

                Code = Convert.ToUInt16(lines[0]);
                Id = Convert.ToUInt32(lines[1]);
                Cost = Convert.ToDouble(lines[2]);
            }
        }

        [JsonPropertyName("code")] public ushort Code { get; set; }

        [JsonPropertyName("id")] public uint Id { get; set; }

        [JsonPropertyName("cost")] public double Cost { get; set; }
    }

    public class VoiceParams {
        [JsonPropertyName("text")] public string Text { get; set; }

        [JsonPropertyName("to")] public string To { get; set; }

        [JsonPropertyName("xml")] public bool Xml { get; set; }

        [JsonPropertyName("from")] public string From { get; set; }
    }
}