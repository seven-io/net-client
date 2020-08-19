using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sms77Api {
    class Client : BaseClient {
        public Client(string apiKey, string sentWith = "CSharp", bool debug = false) : base(apiKey, sentWith, debug) {
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
            HttpMethod httpMethod = ContactsAction.read == @params.Action ? HttpMethod.Get : HttpMethod.Post;
            string method = Util.ToTitleCase(httpMethod.Method);
            MethodInfo methodInfo = GetType().GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic);
            object[] paras = {"contacts", @params};
            var response = await (Task<dynamic>) methodInfo.Invoke(this, paras);

            if (!@params.Json) {
                return response;
            }

            return @params.Action switch {
                ContactsAction.write => WriteContact.FromCsv(response),
                ContactsAction.del => DelContact.FromCsv(response),
                _ => JsonConvert.DeserializeObject<Contact[]>(response)
            };
        }

        public async Task<dynamic> Lookup(LookupParams @params) {
            var dict = Util.ToDictionary(@params, "Type");
            dict.Add("type", Enum.GetName(typeof(LookupType), @params.Type));

            var response = await Get("lookup", dict);

            if (LookupType.format == @params.Type) {
                return JsonConvert.DeserializeObject<FormatLookup>(response);
            }

            if (LookupType.hlr == @params.Type) {
                return JsonSerializer.Deserialize<HlrLookup>(response);
            }

            if (LookupType.cnam == @params.Type) {
                return JsonSerializer.Deserialize<CnamLookup>(response);
            }

            if (LookupType.mnp == @params.Type && true == @params.Json) {
                return JsonConvert.DeserializeObject<MnpLookup>(response);
            }

            return response;
        }

        public async Task<dynamic> Pricing(PricingParams @params = null) {
            var pricing = await Get("pricing", @params);

            return null == @params || "csv" == @params.Format
                ? pricing
                : JsonSerializer.Deserialize<Pricing>(pricing);
        }

        public async Task<dynamic> Sms(SmsParams @params) {
            var response = await Post("sms", @params);

            return true == @params.Json
                ? JsonConvert.DeserializeObject<Sms>(response)
                : response;
        }

        public async Task<dynamic> Status(StatusParams @params, bool json = false) {
            var response = await Get("status", @params);

            return json ? Sms77Api.Status.FromString(response) : response;
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