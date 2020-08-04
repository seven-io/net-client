using System;

namespace Sms77Api {
    public class Util {
        public static string UcFirst(string str) {
            if (String.IsNullOrWhiteSpace(str) || char.IsUpper(str, 0)) {
                return str;
            }

            if (str.Length == 1) {
                return str.ToUpper();
            }

            return char.ToUpper(str[0]).ToString() + str.Substring(1);
        }
    }
}