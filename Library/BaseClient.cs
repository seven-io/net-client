using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sms77Api {
    class BaseClient {
        private readonly Version _httpVersion = new Version(2, 0);
        protected readonly string ApiKey;
        protected readonly Uri BaseUri = new Uri("https://gateway.sms77.io/api");
        protected readonly HttpClient Client;
        protected readonly string SentWith;
        protected readonly bool Debug;
        protected readonly Dictionary<string, string> CommonPayload;

        public BaseClient(string apiKey, string sentWith = "CSharp", bool debug = false) {
            ApiKey = apiKey;
            SentWith = sentWith;
            Debug = debug;

            Client = Debug ? new HttpClient(new LoggingHandler(new HttpClientHandler())) : new HttpClient();

            CommonPayload = new Dictionary<string, string> {
                {"p", ApiKey},
                {"sentWith", SentWith},
            };
        }

        private UriBuilder InitUriBuilder(string endpoint) {
            return new UriBuilder(BaseUri + "/" + endpoint) {Port = -1};
        }

        protected async Task<dynamic> Get(string endpoint, object @params = null) {
            var builder = InitUriBuilder(endpoint);
            var query = HttpUtility.ParseQueryString(builder.Query);

            if (null != @params) {
                foreach (var (k, v) in JsonConvert.DeserializeObject<Dictionary<string, dynamic>>
                    (JsonSerializer.Serialize(@params))) {
                    if (null != v) {
                        query.Add(Util.LcFirst(k), Util.ToString(v));
                    }
                }
            }

            foreach (var (key, value) in CommonPayload) {
                query.Add(key, value);
            }

            builder.Query = query.ToString();

            return await Client.GetStringAsync(builder.ToString());
        }

        protected async Task<dynamic> Post(string endpoint, object @params = null) {
            var builder = InitUriBuilder(endpoint);
            var body = new List<KeyValuePair<string, string>>();

            foreach (var (key, value) in CommonPayload) {
                body.Add(new KeyValuePair<string, string>(key, value));
            }

            if (null != @params) {
                string json = JsonConvert.SerializeObject(@params, Formatting.None,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
                JObject obj = JsonConvert.DeserializeObject<JObject>(json);

                foreach (var item in obj) {
                    if (null != item.Value) {
                        body.Add(new KeyValuePair<string, string>(item.Key, Util.ToString(item.Value)));
                    }
                }

                // if (@params is string) { TODO?
                // @params = JsonConvert.DeserializeObject<ContactsParams>((string) @params);
                // }

                var props = @params.GetType().GetProperties();

                // foreach (var prop in props) {
                //     var value = prop.GetValue(@params);
                //
                //     if (null != value) {
                //         body.Add(new KeyValuePair<string, string>(Util.LcFirst(prop.Name), Util.ToString(value)));
                //     }
                // }
            }

            var response = await Client.SendAsync(new HttpRequestMessage {
                Content = new FormUrlEncodedContent(body),
                Method = HttpMethod.Post,
                RequestUri = new Uri(builder.ToString()),
                Version = _httpVersion,
            });

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}