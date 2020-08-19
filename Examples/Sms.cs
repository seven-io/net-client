using System;

namespace Sms77Api.Examples {
    class Sms : Base {
        public async void Single(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams {
                Text = "HI2U!",
                To = to,
                Flash = true,
                From = "Sms77.io",
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
                {Text = "HI2U!", To = to, From = "Sms77.io", Details = true}));
        }

        public async void SingleReturnMsgId(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams
                {Text = "HI2U!", To = to, From = "Sms77.io", ReturnMsgId = true}));
        }

        public async void SingleDetailedWithMsgId(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams {
                Text = "HI2U!", To = to, From = "Sms77.io", ReturnMsgId = true,
                Details = true
            }));
        }

        public async void SingleJson(string to) {
            Console.WriteLine(await Client.Sms(new SmsParams {
                Text = "HI2U!", To = to, From = "Sms77.io", Json = true
            }));
        }
    }
}