using System;
using NUnit.Framework;
using seven_library.Api;

namespace Seven.Api.Tests {
    [SetUpFixture]
    public class BaseTest {
        internal static Client Client;

        [OneTimeSetUp]
        public void Setup() {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SEVEN_API_KEY_SANDBOX"))) {
                throw new MissingEnvironmentVariableException("Please set environment variable SEVEN_API_KEY_SANDBOX");
            }

            var signingSecret = Environment.GetEnvironmentVariable("SEVEN_SIGNING_KEY");

            Client = new Client(TestHelper.ApiKey, "CSharp", true, signingSecret);
        }
    }
}