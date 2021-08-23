using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    public enum Action {
        read,
        subscribe,
        unsubscribe
    }
    
    public enum EventType {
        all,
        sms_mo,
        dlr,
        voice_status
    }
    
    public enum RequestMethod {
        GET,
        JSON,
        POST
    }
    
    public class Subscription {
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("id")] public int Id { get; set; }
    }
    
    public class Unsubscription {
        [JsonProperty("success")] public bool Success { get; set; }
    }

    public class Read {
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("hooks")] public Entry[] Entries { get; set; }
    }
    
    public class Entry {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("target_url")] public string TargetUrl { get; set; }
        [JsonProperty("event_type")] public EventType EventType { get; set; }
        [JsonProperty("request_method")] public RequestMethod RequestMethod { get; set; }
        [JsonProperty("created")] public string Created { get; set; }
    }
    
    public class Params {
        [JsonProperty("id")] public int? Id { get; set; }
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))] public Action Action { get; set; }
        [JsonProperty("target_url")] public string? TargetUrl { get; set; }
        [JsonProperty("event_type"), JsonConverter(typeof(StringEnumConverter))] public EventType? EventType { get; set; }
        [JsonProperty("request_method"), JsonConverter(typeof(StringEnumConverter))] public RequestMethod? RequestMethod { get; set; }
    }
}