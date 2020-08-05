using System;

namespace Sms77Api.Tests {
    internal static class TestHelper {
        internal static readonly string ApiKey = Environment.GetEnvironmentVariable("SMS77_API_KEY");
        internal static readonly long MsgId = 77127422642;
        internal static readonly string PhoneNumber = "+491771783130";
    }
}