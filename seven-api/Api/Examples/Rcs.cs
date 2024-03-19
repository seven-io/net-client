using System;
using seven_library.Api.Library;
using seven_library.Api.Library.Rcs;

namespace Seven.Api.Examples {
    class Rcs : BaseExample {
        public async void Text(string to)
        {
            var dispatchParams = new DispatchParams(to, "HI2U!")
            {
                ForeignId = "MyTestForeignId",
                From = "seven.io",
                Delay = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60}",
                Label = "TestLabel",
                Ttl = 300000,
                PerformanceTracking = true,
            };
            var res = await Client.Rcs.Dispatch(dispatchParams);
            Console.WriteLine(res);
        }
    }
}