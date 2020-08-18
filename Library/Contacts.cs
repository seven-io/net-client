using System;
using System.Linq;
using System.Text.Json.Serialization;

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

        [JsonPropertyName("ID")] public ulong Id { get; set; }

        [JsonPropertyName("Name")] public string Name { get; set; }

        [JsonPropertyName("Number")] public string Number { get; set; }
    }

    public class DelContact {
        public static DelContact FromCsv(string csv) {
            return new DelContact {Return = Convert.ToUInt16(csv.Trim())};
        }

        [JsonPropertyName("return")] public uint Return { get; set; }
    }

    public class WriteContact {
        public static WriteContact FromCsv(string csv) {
            var lines = Util.SplitByLine(csv);

            return new WriteContact {Id = Convert.ToUInt64(lines[1]), Return = Convert.ToUInt16(lines[0])};
        }

        [JsonPropertyName("id")] public ulong Id { get; set; }

        [JsonPropertyName("return")] public uint Return { get; set; }
    }

    public class ContactsParams {
        [JsonPropertyName("action")] public ContactsAction Action { get; set; }

        [JsonPropertyName("email")] public string Email { get; set; }

        [JsonPropertyName("empfaenger")] public string Empfaenger { get; set; }

        [JsonPropertyName("id")] public ulong? Id { get; set; }

        [JsonPropertyName("json")] public bool Json { get; set; }


        [JsonPropertyName("nick")] public string Nick { get; set; }
    }
}