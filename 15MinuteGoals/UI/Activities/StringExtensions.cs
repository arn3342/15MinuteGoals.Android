using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _15MinuteGoals.UI.Activities
{
    public static class StringExtensions
    {
        public static bool StringIsAlpha(this string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            var numbersOrCharacters = new Regex(@"[0-9*#+]|[!@#$%^&*(),.?"":{}|<>]");
            if (numbersOrCharacters.IsMatch(str))
            {
                return false;
            }
            return true;
        }

        public static bool StringsAreAlphaNumeric(this string[] str, bool MatchStrings = false)
        {
            bool validated = false;
            for(int i = 0; i < str.Length; i++)
            {
                if (string.IsNullOrEmpty(str[i]) || string.IsNullOrWhiteSpace(str[i]))
                {
                    break;
                }
                else
                {
                    validated = true;
                }
            }
            if (MatchStrings)
            {
                string firstItem = str[0];
                bool allEqual = str.Skip(1)
                  .All(s => string.Equals(firstItem, s, StringComparison.InvariantCultureIgnoreCase));

                validated = allEqual;
            }
            return validated;
        }
    }
}