using System;
using System.Threading.Tasks;
using Seven.Api.Tests;
using seven_library.Api.Library;

namespace Seven.Api.Examples {
    class ValidateForVoice : BaseExample {
        static async Task Retrieve() {
            var paras = new ValidateForVoiceParams {Number = TestHelper.PhoneNumber, Callback = "doma.in/cb.php"};

            Console.WriteLine(await Client.ValidateForVoice(paras));
        }
    }
}