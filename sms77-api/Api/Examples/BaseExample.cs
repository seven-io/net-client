using Sms77.Api.Tests;
using sms77_library.Api;

namespace Sms77.Api.Examples {
    class BaseExample {
        protected static readonly Client Client = new Client(TestHelper.ApiKey);
    }
}