using System;

namespace Seven.Api.Tests {
    internal static class TestHelper {
        private static readonly string DummyApiKey = Environment.GetEnvironmentVariable("SEVEN_API_KEY_SANDBOX");
        internal static readonly string MyApiKey = Environment.GetEnvironmentVariable("SEVEN_API_KEY");
        internal static readonly string ApiKey = DummyApiKey;
        internal static readonly string PhoneNumber = "+491771783130";
        internal static readonly string MyPhoneNumber = Environment.GetEnvironmentVariable("SEVEN_TO");

        internal static string CreateRandomUrl() {
            return $"http://my.tld/{Guid.NewGuid()}";
        }
    }
}