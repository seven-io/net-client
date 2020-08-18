using System;

namespace Sms77Api {
    public class Util {
        public static string[] SplitByLine(string str) {
            return str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string LcFirst(string str) {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static string ToString(dynamic value) {
            if (value is string) {
                return value;
            }

            return value is bool ? Convert.ToInt32(value).ToString() : value.ToString();
        }
    }
}