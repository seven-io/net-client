using Seven.Api.Tests;
using seven_library.Api;

namespace Seven.Api.Examples {
    class BaseExample {
        protected static readonly Client Client = new Client(TestHelper.ApiKey);
    }
}