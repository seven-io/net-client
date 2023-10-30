using System;
using System.Threading.Tasks;
using Seven.Api.Tests;
using seven_library.Api.Library;

namespace Seven.Api.Examples {
    class Lookup : BaseExample {
        public async Task Cnam() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.cnam, Number = TestHelper.PhoneNumber}));
        }

        public async Task Format() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.format, Number = TestHelper.PhoneNumber}));
        }

        public async Task Hlr() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.hlr, Number = TestHelper.PhoneNumber}));
        }

        public async Task MnpAsJson() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.mnp, Number = TestHelper.PhoneNumber, Json = true}));
        }

        public async Task MnpAsText() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.mnp, Number = TestHelper.PhoneNumber}));
        }
    }
}