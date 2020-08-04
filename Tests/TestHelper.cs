using System;

namespace Sms77Api.Tests {
    internal static class TestHelper {
        internal static readonly string ApiKey = Environment.GetEnvironmentVariable("SMS77_DUMMY_API_KEY");
        internal static readonly long MsgId = 77127422642;
    }
}