using System;
using System.Threading.Tasks;

namespace Sms77Api.Examples {
    class Balance : Base {
        static async Task Retrieve() {
            Console.WriteLine(await Client.Balance());
        }
    }
}