using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sms77Api {
    class BaseClient {
        protected string ApiKey;
        protected string SentWith;

        protected readonly string BaseUrl = "https://gateway.sms77.io/api";
        protected readonly HttpClient client = new HttpClient();

        public BaseClient(string apiKey, string sentWith = "CSharp") {
            ApiKey = apiKey;
            SentWith = sentWith;
        }

        public async Task<dynamic> Get(string endpoint, object @params = null) {
            var builder = new UriBuilder(BaseUrl + "/" + endpoint);
            builder.Port = -1;

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

            query.Add("p", ApiKey);
            query.Add("sentWith", SentWith);

            builder.Query = query.ToString();

            return await client.GetStringAsync(builder.ToString());
        }
    }
}