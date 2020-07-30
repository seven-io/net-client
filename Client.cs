using System;
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
    }
}