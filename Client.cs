using System;
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
            var response = await Get("status", @params);
            string[] lines = response.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            return new Status {
                Code = lines[0],
                Timestamp = lines[1],
            };
        }

        public async Task<dynamic> Pricing(PricingParams @params = null) {
            var pricing = await Get("pricing", @params);

            return null == @params || "csv" == @params.Format
                ? pricing
                : JsonSerializer.Deserialize<Pricing>(pricing);
        }

        public async Task<dynamic> ValidateForVoice(ValidateForVoiceParams @params) {
            var validation = await Post("validate_for_voice", @params);
            
            return JsonSerializer.Deserialize<ValidateForVoice>(validation);
        }
    }
}