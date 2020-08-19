using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sms77Api {
    class LoggingHandler : DelegatingHandler {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler) {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken) {
            if (null != request.Content) {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (null != response.Content) {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }
}