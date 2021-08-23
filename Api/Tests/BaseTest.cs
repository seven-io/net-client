using System;
using NUnit.Framework;
using sms77_library.Api;

namespace Sms77.Api.Tests {
    [SetUpFixture]
    public class BaseTest {
        internal static Client Client;

        [OneTimeSetUp]
        public void Setup() {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SMS77_DUMMY_API_KEY"))) {
                throw new MissingEnvironmentVariableException("Please set environment variable SMS77_DUMMY_API_KEY");
            }

            Client = new Client(TestHelper.ApiKey, "CSharp", true);
        }
    }
}