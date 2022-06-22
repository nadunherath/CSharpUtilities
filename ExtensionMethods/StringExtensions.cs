using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtilities.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool ContainsString(this string str, string value)
        {
            bool result = ContainsString(str, value, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        public static bool ContainsString(this string str, string value, StringComparison comparisonType)
        {
            return str.IndexOf(value, comparisonType) != -1;
        }

        public static string Truncate(this string str, int maxLength)
        {
            return str?.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string Repeat(this string str, int count)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return new StringBuilder(str.Length * count).Insert(0, str, count).ToString();
        }
    }
}
