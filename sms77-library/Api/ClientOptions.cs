namespace sms77_library.Api {
    public class ClientOptions {
        protected string ApiKey { get; }
        public bool Debug { get; set; }
        public string SentWith { get; set; } = "CSharp";
        public string? SigningSecret { get; set; }
        
        public ClientOptions(string apiKey) {
            ApiKey = apiKey;
        }
    }
}