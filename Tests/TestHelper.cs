using System;

namespace Sms77Api.Tests {
    internal static class TestHelper {
        private static readonly string DummyApiKey = Environment.GetEnvironmentVariable("SMS77_DUMMY_API_KEY");
        internal static readonly string MyApiKey = Environment.GetEnvironmentVariable("SMS77_API_KEY");
        internal static readonly string ApiKey = DummyApiKey;
        internal static readonly string PhoneNumber = "+491771783130";
        internal static readonly string MyPhoneNumber = Environment.GetEnvironmentVariable("SMS77_TO");
    }
}