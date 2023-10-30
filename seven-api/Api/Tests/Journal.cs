#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using seven_library.Api.Library;

namespace Seven.Api.Tests {
    [TestFixture]
    public class Journal {
        private static seven_library.Api.Library.Journal? AssertFirstListItem(IReadOnlyCollection<seven_library.Api.Library.Journal> journal) {
            if (0 == journal.Count) {
                Assert.That(journal.Count, Is.Zero);
                return null;
            }
   
            Console.WriteLine("Yes we have an entry");
            var first = journal.First();

            Assert.That(first, Is.InstanceOf(typeof(seven_library.Api.Library.Journal)));
            Assert.That(first.From, Is.Not.Empty);
            Assert.That(first.Id, Is.Not.Empty);
            Assert.That(first.Inbound, Is.Not.Empty);
            Assert.That(first.Price, Is.Not.Empty);
            Assert.That(first.Text, Is.Not.Empty);
            Assert.That(first.Timestamp, Is.Not.Empty);
            Assert.That(first.Inbound, Is.Not.Empty);

            return first;
        }

        [Test]
        public async Task Inbound() {
            var journalParams = new JournalParams {Type = JournalType.inbound};
            var list = await BaseTest.Client.Journal(journalParams);
            AssertFirstListItem(list);
        }
        
        [Test]
        public async Task Outbound() {
            var journalParams = new JournalParams {Type = JournalType.outbound};
            var list = await BaseTest.Client.Journal(journalParams);

            if (AssertFirstListItem(list) is JournalOutbound item) {
                Assert.That(item.Connection, Is.Not.Empty);
                Assert.That(item, Has.Property("Dlr"));
                Assert.That(item, Has.Property("DlrTimestamp"));
                Assert.That(item, Has.Property("ForeignId"));
                Assert.That(item, Has.Property("Label"));
                Assert.That(item, Has.Property("Latency"));
                Assert.That(item, Has.Property("MccMnc"));
                Assert.That(item.Type, Is.Not.Empty);
            }
        }
        
        [Test]
        public async Task Replies() {
            var journalParams = new JournalParams {Type = JournalType.replies};
            var list = await BaseTest.Client.Journal(journalParams);
            AssertFirstListItem(list);
        }
        
        [Test]
        public async Task Voice() {
            var journalParams = new JournalParams {Type = JournalType.voice};
            var list = await BaseTest.Client.Journal(journalParams);

            if (AssertFirstListItem(list) is JournalVoice item) {
                Assert.That(item.Duration, Is.Not.Empty);
                Assert.That(item, Has.Property("Error"));
                Assert.That(item.Status, Is.Not.Empty);
                Assert.That(item.Text, Is.Not.Empty);
                Assert.That(item, Has.Property("Xml"));
            }
        }
    }
}