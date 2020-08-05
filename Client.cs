using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sms77Api {
    class Client : BaseClient {
        public Client(string apiKey, string sentWith = "CSharp") : base(apiKey, sentWith) {
        }

        public async Task<Analytics[]> Analytics(AnalyticsParams @params = null) {
            return JsonConvert.DeserializeObject<Analytics[]>(await Get("analytics", @params));
        }

        public async Task<double> Balance() {
            var response = await Get("balance");

            if (Int32.TryParse(response, out int _)) {
                throw new ApiException("Invalid API-Key or API busy.");
            }

            return Convert.ToDouble(response);
        }

        public async Task<dynamic> Status(StatusParams @params) {
            var obj = JsonConvert.SerializeObject(@params);
            var paras = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(obj);
            var response = await Get("status", paras);
            string[] lines = response.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            return new Status {
                Code = lines[0],
                Timestamp = lines[1],
            };
        }

        public async Task<dynamic> Pricing(PricingParams @params = null) {
            var obj = JsonConvert.SerializeObject(@params);
            var paras = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(obj);

            var pricing = await Get("pricing", paras);

            return "csv" == @params.Format
                ? pricing
                : JsonSerializer.Deserialize<Pricing>(pricing);
        }
    }
}