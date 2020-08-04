using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sms77Api {
    class Client : BaseClient {
        public Client(string apiKey, string sentWith = "CSharp") : base(apiKey, sentWith) {
        }

        public async Task<double> Balance() {
            var response = await Get("balance");

            if (Int32.TryParse(response, out int _)) {
                throw new ApiException("Invalid API-Key or API busy.");
            }

            return Convert.ToDouble(response);
        }

        public async Task<dynamic> Status(long msgId) {
            var response = await Get("status", new Dictionary<string, dynamic> {
                {"msg_id", msgId},
            });

            string[] lines = response.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            return new Status {
                Code = lines[0],
                Timestamp = lines[1],
            };
        }

        public async Task<dynamic> Pricing(ResponseFormat format = ResponseFormat.Csv, string country = null) {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic> {
                {"country", country},
                {"format", Enum.GetName(typeof(ResponseFormat), format)!.ToLower()},
            };


            var pricing = await Get("pricing", parameters);

            if (ResponseFormat.Csv == format) {
                return pricing;
            }

            return JsonSerializer.Deserialize<Pricing>(pricing);
        }
    }
}