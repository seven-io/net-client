using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

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

        public async Task<dynamic> Get(string endpoint, IDictionary<string, string> parameters = null) {
            var builder = new UriBuilder(BaseUrl + "/" + endpoint);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            if (null != parameters) {
                foreach (var (key, value) in parameters) {
                    query[key] = value;
                }
            }

            query["p"] = ApiKey;
            query["sentWith"] = SentWith;
            builder.Query = query.ToString();
            string url = builder.ToString();

            var response = await client.GetStringAsync(url);
            Console.WriteLine(response);
            return response;
        }
    }
}