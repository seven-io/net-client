using System;

namespace Sms77Api.Tests {
    internal static class TestHelper {
        internal static string ApiKey = Environment.GetEnvironmentVariable("SMS77_DUMMY_API_KEY");

        internal static void CheckEnvironmentVariable() {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SMS77_DUMMY_API_KEY"))) {
                throw new ArgumentNullException("Please set environment variable 'SMS77_DUMMY_API_KEY'!");
            }
        }
    }
}