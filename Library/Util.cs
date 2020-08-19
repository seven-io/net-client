using System;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace Sms77Api {
    public class Util {
        public static string[] SplitByLine(string str) {
            return str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string LcFirst(string str) {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static string ToString(JToken token) {
            if (token.Type == JTokenType.String) {
                return token.ToObject<string>();
            }

            return token.Type == JTokenType.Boolean ? $"{Convert.ToInt32(token.ToObject<bool>())}" : token.ToString();
        }

        public static IDictionary<string, object> ToDictionary(object @params, string exclude = null) {
            var dict = (IDictionary<string, object>) new ExpandoObject();

            foreach (var property in @params.GetType().GetProperties()) {
                var value = property.GetValue(@params);

                if (exclude != property.Name && null != value) {
                    dict.Add(property.Name, value);
                }
            }

            return dict;
        }
    }
}