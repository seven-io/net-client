using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public async Task<dynamic> Contacts(ContactsParams @params) {
            var dict = (IDictionary<string, object>) new ExpandoObject();
            var method = ContactsAction.read == @params.Action ? "Get" : "Post";

            foreach (var property in @params.GetType().GetProperties()) {
                var value = property.GetValue(@params);

                if ("Action" != property.Name && null != value) {
                    dict.Add(property.Name, value);
                }
            }

            dict.Add("action", Enum.GetName(typeof(ContactsAction), @params.Action));

            var response = await (Task<dynamic>) GetType().GetMethod(method)
                .Invoke(this, new[] {
                    "contacts", "Get" == method ? (object) dict : JsonConvert.SerializeObject(dict)
                });

            if (!@params.Json) {
                return response;
            }

            return @params.Action switch {
                ContactsAction.write => WriteContact.FromCsv(response),
                ContactsAction.del => DelContact.FromCsv(response),
                _ => JsonConvert.DeserializeObject<Contact[]>(response)
            };
        }

        public async Task<dynamic> Status(StatusParams @params) {
            var response = await Get("status", @params);
            string[] lines = Util.SplitByLine(response);

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

        public async Task<dynamic> Voice(VoiceParams @params, bool json = false) {
            var response = await Post("voice", @params);

            return json ? new Voice(response) : response;
        }
    }
}