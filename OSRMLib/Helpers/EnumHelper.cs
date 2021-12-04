using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSRMLib.Helpers
{
    public static class EnumHelper
    {
        public static T ParseStringToEnum<T>(string typeString)
        {
            if (string.IsNullOrEmpty(typeString))
            {
                return default(T);
            }

            typeString = typeString.Replace(" ", "");
            var names = Enum.GetNames(typeof(T)).ToList().Select(x => x.ToLower());
            if (names.Contains(typeString))
                return (T)Enum.Parse(typeof(T), names.Where(x => x == typeString).First());
            else
                return default(T);
        }

        public static IEnumerable<T> ParseStringArrayToEnum<T>(IEnumerable<string> typeString)
        {
            return typeString.Select(x => ParseStringToEnum<T>(x));
        }

        public static string ParseEnumToString<T>(T enumToParse)
        {
            return Enum.GetName(typeof(T), enumToParse).ToLower();
        }
    }
}
