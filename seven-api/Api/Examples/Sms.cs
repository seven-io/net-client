using System;
using seven_library.Api.Library;

namespace Seven.Api.Examples {
    class Sms : BaseExample {
        public async void Single(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams {
                Text = "HI2U!",
                To = to,
                Flash = true,
                From = "seven.io",
                Delay = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60}",
                Label = "TestLabel",
                Ttl = 300000,
                NoReload = true,
                PerformanceTracking = true,
                ForeignId = "MyTestForeignId",
            }));
        }

        public async void SingleDetailed(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams
                {Text = "HI2U!", To = to, From = "seven.io", Details = true}));
        }

        public async void SingleReturnMsgId(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams
                {Text = "HI2U!", To = to, From = "seven.io", ReturnMsgId = true}));
        }

        public async void SingleDetailedWithMsgId(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams {
                Text = "HI2U!", To = to, From = "seven.io", ReturnMsgId = true,
                Details = true
            }));
        }

        public async void SingleJson(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams {
                Text = "HI2U!", To = to, From = "seven.io", Json = true
            }));
        }
    }
}