using System;
using Newtonsoft.Json;

namespace seven_library.Api.Library {
    public class Voice {
        public Voice(string response = null) {
            if (null != response) {
                var lines = Util.SplitByLine(response);

                Code = Convert.ToUInt16(lines[0]);
                Id = Convert.ToUInt32(lines[1]);
                Cost = Convert.ToDouble(lines[2]);
            }
        }

        [JsonProperty("code")] public ushort Code { get; set; }
        [JsonProperty("id")] public uint Id { get; set; }
        [JsonProperty("cost")] public double Cost { get; set; }
    }

    public class VoiceParams {
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("to")] public string To { get; set; }
        [JsonProperty("xml")] public bool Xml { get; set; }
        [JsonProperty("from")] public string From { get; set; }
    }
}