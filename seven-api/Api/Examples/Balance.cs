using System;
using System.Threading.Tasks;

namespace Seven.Api.Examples {
    class Balance : BaseExample {
        static async Task Retrieve() {
            Console.WriteLine(await Client.Balance());
        }
    }
}