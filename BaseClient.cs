using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sms77Api {
    class BaseClient {
        private readonly Version _httpVersion = new Version(2, 0);
        protected readonly string ApiKey;
        protected readonly Uri BaseUri = new Uri("https://gateway.sms77.io/api");
        protected readonly HttpClient Client;
        protected readonly string SentWith;

        public BaseClient(string apiKey, string sentWith = "CSharp") {
            ApiKey = apiKey;
            SentWith = sentWith;

            Client = new HttpClient(new LoggingHandler(new HttpClientHandler())) {
                //BaseAddress = BaseUri
                DefaultRequestVersion = _httpVersion
            };
        }

        private string UriToBuilder(UriBuilder builder, object @params = null) {
            var query = HttpUtility.ParseQueryString(builder.Query);

            if (null != @params) {
                var json = JsonSerializer.Serialize(@params);
                var paras = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);

                foreach (var (key, value) in paras) {
                    if (null != value) {
                        query.Add(key, value is string ? value : value.ToString());
                    }
                }
            }

            SetCommonPayload(query);

            builder.Query = query.ToString();

            return builder.ToString();
        }

        private UriBuilder InitUriBuilder(string endpoint) {
            return new UriBuilder(BaseUri + "/" + endpoint) {Port = -1};
        }

        private void SetCommonPayload(NameValueCollection data) {
            foreach (var (key, value) in new Dictionary<string, string> {
                {"p", ApiKey},
                {"sentWith", SentWith},
            }) {
                data.Add(key, value);
            }
        }

        public async Task<dynamic> Get(string endpoint, object @params = null) {
            return await Client.GetStringAsync(UriToBuilder(InitUriBuilder(endpoint), @params));
        }

        public async Task<dynamic> Post(string endpoint, object @params = null) {
            var builder = InitUriBuilder(endpoint);
            var body = GetCommonPayload();

            if (null != @params) {
                PropertyInfo[] props = @params.GetType().GetProperties();

                foreach (var prop in props) {
                    var value = prop.GetValue(@params);

                    if (null != value) {
                        body.Add(new KeyValuePair<string, string>(prop.Name.ToLower(), value.ToString()));
                    }
                }
            }

            var response = await Client.SendAsync(new HttpRequestMessage {
                RequestUri = new Uri(builder.ToString()),
                Method = HttpMethod.Post,
                Version = _httpVersion,
                Content = new FormUrlEncodedContent(body),
            });

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private List<KeyValuePair<string, string>> GetCommonPayload() {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            foreach (var (key, value) in new Dictionary<string, string> {
                {"p", ApiKey},
                {"sentWith", SentWith},
            }) {
                list.Add(new KeyValuePair<string, string>(key, value));
            }

            return list;
        }
    }
}