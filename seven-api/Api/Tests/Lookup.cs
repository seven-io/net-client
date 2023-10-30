using System.Threading.Tasks;
using NUnit.Framework;
using seven_library.Api.Library;

namespace Seven.Api.Tests {
    [TestFixture]
    public class Lookup {
        private void AssertCarrier(Carrier actual, Carrier expected) {
            Assert.That(actual.Country, Is.EqualTo(expected.Country));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.NetworkCode, Is.EqualTo(expected.NetworkCode));
            Assert.That(actual.NetworkType, Is.EqualTo(expected.NetworkType));
        }

        [Test]
        public async Task Cnam() {
            CnamLookup cnam = await BaseTest.Client.Lookup(
                new LookupParams {Type = LookupType.cnam, Number = TestHelper.PhoneNumber});

            Assert.That(cnam.Code, Is.EqualTo("100"));
            Assert.That(cnam.Name, Is.EqualTo("GERMANY"));
            Assert.That(cnam.Number, Is.EqualTo(TestHelper.PhoneNumber));
            Assert.That(cnam.Success, Is.EqualTo("true"));
        }

        [Test]
        public async Task Format() {
            FormatLookup format = await BaseTest.Client.Lookup(
                new LookupParams {Type = LookupType.format, Number = TestHelper.PhoneNumber});

            Assert.That(format.Carrier, Is.Not.Empty);
            Assert.That(format.International, Is.Not.Empty);
            Assert.That(format.National, Is.Not.Empty);
            Assert.That(format.Success, Is.True);
            Assert.That(format.CountryCode, Is.Not.Empty);
            Assert.That(format.CountryIso, Is.Not.Empty);
            Assert.That(format.CountryName, Is.Not.Empty);
            Assert.That(format.InternationalFormatted, Is.Not.Empty);
            Assert.That(format.NetworkType, Is.Not.Empty);
        }

        [Test]
        public async Task Hlr() {
            HlrLookup hlr = await BaseTest.Client.Lookup(
                new LookupParams {Type = LookupType.hlr, Number = TestHelper.PhoneNumber});

            Carrier carrier = new Carrier {
                NetworkCode = "26203",
                Name = "Telefónica Germany GmbH & Co. oHG (O2)",
                Country = "DE",
                NetworkType = "mobile"
            };

            HlrLookup dummy = new HlrLookup {
                Status = true,
                StatusMessage = "success",
                LookupOutcome = true,
                LookupOutcomeMessage = "success",
                InternationalFormatNumber = "491771783130",
                InternationalFormatted = "+49 177 1783130",
                NationalFormatNumber = "0177 1783130",
                CountryCode = "DE",
                CountryName = "Germany",
                CountryPrefix = "49",
                CurrentCarrier = carrier,
                OriginalCarrier = carrier,
                ValidNumber = "valid",
                Reachable = "reachable",
                Ported = "assumed_not_ported",
                Roaming = "not_roaming",
                GsmCode = "0",
                GsmMessage = "No error"
            };

            Assert.That(hlr.Status, Is.EqualTo(dummy.Status));
            Assert.That(hlr.StatusMessage, Is.EqualTo(dummy.StatusMessage));
            Assert.That(hlr.LookupOutcome, Is.EqualTo(dummy.LookupOutcome));
            Assert.That(hlr.LookupOutcomeMessage, Is.EqualTo(dummy.LookupOutcomeMessage));
            Assert.That(hlr.InternationalFormatNumber, Is.EqualTo(dummy.InternationalFormatNumber));
            Assert.That(hlr.InternationalFormatted, Is.EqualTo(dummy.InternationalFormatted));
            Assert.That(hlr.NationalFormatNumber, Is.EqualTo(dummy.NationalFormatNumber));
            Assert.That(hlr.CountryCode, Is.EqualTo(dummy.CountryCode));
            Assert.That(hlr.CountryName, Is.EqualTo(dummy.CountryName));
            Assert.That(hlr.CountryPrefix, Is.EqualTo(dummy.CountryPrefix));
            AssertCarrier(hlr.CurrentCarrier, carrier);
            AssertCarrier(hlr.OriginalCarrier, carrier);
            Assert.That(hlr.ValidNumber, Is.EqualTo(dummy.ValidNumber));
            Assert.That(hlr.Reachable, Is.EqualTo(dummy.Reachable));
            Assert.That(hlr.Ported, Is.EqualTo(dummy.Ported));
            Assert.That(hlr.Roaming, Is.EqualTo(dummy.Roaming));
            Assert.That(hlr.GsmCode, Is.EqualTo(dummy.GsmCode));
            Assert.That(hlr.GsmMessage, Is.EqualTo(dummy.GsmMessage));
        }

        [Test]
        public async Task MnpAsJson() {
            MnpLookup mnp = await BaseTest.Client.Lookup(
                new LookupParams {Type = LookupType.mnp, Number = TestHelper.PhoneNumber, Json = true});

            Assert.That(mnp.Code, Is.EqualTo(100));
            Assert.That(mnp.Success, Is.True);
            Assert.That(mnp.Mnp.Country, Is.Not.Empty);
            Assert.That(mnp.Mnp.Number, Is.Not.Empty);
            Assert.That(mnp.Mnp.InternationalFormatted, Is.Not.Empty);
            Assert.That(mnp.Mnp.NationalFormat, Is.Not.Empty);
            Assert.That(mnp.Mnp.Network, Is.Not.Empty);
            Assert.That(mnp.Mnp.MccMnc, Is.Not.Empty);
            Assert.That(mnp.Mnp.IsPorted, Is.False);
        }

        [Test]
        public async Task MnpAsText() {
            Assert.That(await BaseTest.Client.Lookup(
                new LookupParams {Type = LookupType.mnp, Number = TestHelper.PhoneNumber}), Is.EqualTo("eplus"));
        }
    }
}