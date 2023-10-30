using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace seven_library.Api {
    public class CustomHttpHandler : DelegatingHandler {
        protected ClientOptions ClientOptions;
        
        public CustomHttpHandler(HttpMessageHandler innerHandler, ClientOptions clientOptions) : base(innerHandler) {
            ClientOptions = clientOptions;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) {
            var signingSecret = ClientOptions.SigningSecret;

            if (signingSecret != null) {
                var url = request.RequestUri;
                var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                var nonce = GenerateNonce();

                var requestBody = "";
                if (request.Content != null) {
                    var formData = await request.Content.ReadAsStringAsync();
                    
                    if (formData != null) {
                        requestBody = formData;
                    }
                }

                var md5 = CreateMD5(requestBody);
                var stringToSign = $"{timestamp}\n{nonce}\n{request.Method}\n{url}\n{md5}";
                var hash = HashHmac(stringToSign, signingSecret);

                request.Headers.Add("X-Signature", hash);
                request.Headers.Add("X-Timestamp", timestamp.ToString());
                request.Headers.Add("X-nonce", nonce);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private static string GenerateNonce(int length = 16) {
            var data = new byte[length];
            new RNGCryptoServiceProvider().GetNonZeroBytes(data);
            var sb = new StringBuilder();
            foreach (var b in data) {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        private static string CreateMD5(string input) {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hashBytes.Length; i++) {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        private static string HashHmac(string message, string secret) {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}