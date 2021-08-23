using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace sms77_library.Api.Library
{
    public abstract class BaseClient
    {
        private readonly Dictionary<string, string> _commonPayload = new Dictionary<string, string>();
        protected readonly string ApiKey;
        protected readonly HttpClient Client;
        protected readonly bool Debug;
        protected readonly string SentWith;

        public BaseClient(string apiKey, string sentWith = "CSharp", bool debug = false)
        {
            ApiKey = apiKey;
            SentWith = sentWith;
            Debug = debug;

            Client = Debug ? new HttpClient(new LoggingHandler(new HttpClientHandler())) : new HttpClient();
            Client.BaseAddress = new Uri("https://gateway.sms77.io/api/");

            _commonPayload.Add("p", ApiKey);
            _commonPayload.Add("sentWith", SentWith);
        }

        protected async Task<dynamic> Get(string endpoint, object @params = null)
        {
            var query = HttpUtility.ParseQueryString("");

            if (null != @params)
            {
                foreach (var item in Util.ToJObject(@params))
                {
                    query.Add(item.Key, Util.ToString(item.Value));
                }
            }

            foreach (var item in _commonPayload)
            {
                query.Add(item.Key, item.Value);
            }

            return await Client.GetStringAsync($"{endpoint}?{query}");
        }

        protected async Task<dynamic> Post(string endpoint, object @params = null)
        {
            var body = new List<KeyValuePair<string, string>>();

            foreach (var item in _commonPayload)
            {
                body.Add(new KeyValuePair<string, string>(item.Key, item.Value));
            }

            if (null != @params)
            {
                foreach (var item in Util.ToJObject(@params))
                {
                    body.Add(new KeyValuePair<string, string>(item.Key, Util.ToString(item.Value)));
                }
            }

            var response = await Client.PostAsync(endpoint, new FormUrlEncodedContent(body));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
