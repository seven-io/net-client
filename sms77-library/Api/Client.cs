#nullable enable
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using sms77_library.Api.Library;
using sms77_library.Api.Library.Hooks;

namespace sms77_library.Api
{
    public class Client : BaseClient
    {
        public Client(
            string apiKey, 
            string sentWith = "CSharp",
            bool debug = false,
            string? signingSecret = null
        ) : base(apiKey, sentWith, debug, signingSecret)
        {
        }

        public async Task<Analytics[]> Analytics(AnalyticsParams @params = null)
        {
            return JsonConvert.DeserializeObject<Analytics[]>(await Get("analytics", @params));
        }

        public async Task<double> Balance()
        {
            var response = await Get("balance");

            if (Int32.TryParse(response, out int _))
            {
                throw new ApiException("Invalid API-Key or API busy.");
            }

            return Convert.ToDouble(response);
        }

        public async Task<dynamic> Contacts(ContactsParams @params)
        {
            HttpMethod httpMethod = ContactsAction.read == @params.Action ? HttpMethod.Get : HttpMethod.Post;
            string method = Library.Util.ToTitleCase(httpMethod.Method);
            object[] paras = { "contacts", @params };
            var response = await CallDynamicMethod(method, paras);

            if (!@params.Json)
            {
                return response;
            }

            return @params.Action switch
            {
                ContactsAction.write => WriteContact.FromCsv(response),
                ContactsAction.del => DelContact.FromCsv(response),
                _ => JsonConvert.DeserializeObject<Contact[]>(response)
            };
        }

        public async Task<dynamic> Hooks(Library.Hooks.Params @params)
        {
            var httpMethod = Library.Hooks.Action.read == @params.Action ? HttpMethod.Get : HttpMethod.Post;
            var method = Library.Util.ToTitleCase(httpMethod.Method);
            object[] paras = { "hooks", @params };
            var response = await CallDynamicMethod(method, paras);

            return @params.Action switch
            {
                Library.Hooks.Action.subscribe
                    => JsonConvert.DeserializeObject<Library.Hooks.Subscription>(response),
                Library.Hooks.Action.unsubscribe
                    => JsonConvert.DeserializeObject<Library.Hooks.Unsubscription>(response),
                _ => JsonConvert.DeserializeObject<Library.Hooks.Read>(response)
            };
        }

        public async Task<dynamic> Journal(JournalParams @params)
        {
            var dict = Util.ToDictionary(@params, "Type");
            dict.Add("type", Enum.GetName(typeof(JournalType), @params.Type));

            var response = await Get("journal", dict);

            return @params.Type switch {
                JournalType.outbound => JsonConvert.DeserializeObject<List<JournalOutbound>>(response),
                JournalType.voice => JsonConvert.DeserializeObject<List<JournalVoice>>(response),
                _ => JsonConvert.DeserializeObject<List<Journal>>(response)
            };
        }
        
        public async Task<dynamic> Lookup(LookupParams @params) {
           var query = HttpUtility.ParseQueryString("");
           query.Add("json", @params.Json.ToString());
           query.Add("number", @params.Number);
           query.Add("type", Enum.GetName(typeof(LookupType), @params.Type));

            var response = await Get($"lookup", null, query);

            if (LookupType.format == @params.Type)
            {
                return JsonConvert.DeserializeObject<FormatLookup>(response);
            }

            if (LookupType.hlr == @params.Type)
            {
                return JsonConvert.DeserializeObject<HlrLookup>(response);
            }

            if (LookupType.cnam == @params.Type)
            {
                return JsonConvert.DeserializeObject<CnamLookup>(response);
            }

            if (LookupType.mnp == @params.Type && true == @params.Json)
            {
                return JsonConvert.DeserializeObject<MnpLookup>(response);
            }

            return response;
        }

        public async Task<dynamic> Pricing(PricingParams @params = null)
        {
            var pricing = await Get("pricing", @params);

            return null == @params || "csv" == @params.Format
                ? pricing
                : JsonConvert.DeserializeObject<Pricing>(pricing);
        }
        
        public async Task<dynamic> Sms(SmsParams @params)
        {
            var response = await Post("sms", @params);

            return true == @params.Json
                ? JsonConvert.DeserializeObject<Sms>(response)
                : response;
        }

        public async Task<dynamic> Status(StatusParams @params, bool json = false)
        {
            var response = await Get("status", @params);

            return json ? Library.Status.FromString(response) : response;
        }

        public async Task<dynamic> ValidateForVoice(ValidateForVoiceParams @params)
        {
            var validation = await Post("validate_for_voice", @params);

            return JsonConvert.DeserializeObject<ValidateForVoice>(validation);
        }

        public async Task<dynamic> Voice(VoiceParams @params, bool json = false)
        {
            var response = await Post("voice", @params);

            return json ? new Voice(response) : response;
        }

        private async Task<dynamic> CallDynamicMethod(string name, object?[] paras)
        {
            var methodInfo = GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
            return await (Task<dynamic>)methodInfo.Invoke(this, paras);
        }
    }
}