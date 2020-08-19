using System;
using System.Linq;
using Newtonsoft.Json;

namespace Sms77Api {
    public enum ContactsAction {
        read,
        write,
        del
    }

    public class Contact {
        public static Contact FromCsv(string csv) {
            var values = csv.Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < values.Length; i++) {
                values[i] = values[i].Trim();

                string first = values[i].First().ToString();
                string last = values[i].Last().ToString();

                if ("\"" == first && "\"" == last) {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
            }

            return new Contact {Id = Convert.ToUInt64(values[0]), Name = values[1], Number = values[2]};
        }

        [JsonProperty("ID")] public ulong Id { get; set; }
        [JsonProperty("Name")] public string Name { get; set; }
        [JsonProperty("Number")] public string Number { get; set; }
    }

    public class DelContact {
        public static DelContact FromCsv(string csv) {
            return new DelContact {Return = Convert.ToUInt16(csv.Trim())};
        }

        [JsonProperty("return")] public uint Return { get; set; }
    }

    public class WriteContact {
        public static WriteContact FromCsv(string csv) {
            var lines = Util.SplitByLine(csv);

            return new WriteContact {Id = Convert.ToUInt64(lines[1]), Return = Convert.ToUInt16(lines[0])};
        }

        [JsonProperty("id")] public ulong Id { get; set; }
        [JsonProperty("return")] public uint Return { get; set; }
    }

    public class ContactsParams {
        [JsonProperty("action")] public ContactsAction Action { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("empfaenger")] public string Empfaenger { get; set; }
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("json")] public bool Json { get; set; }
        [JsonProperty("nick")] public string Nick { get; set; }
    }
}