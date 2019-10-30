using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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
            var numbersOrCharacters = new Regex(@"[0-9*#+]|[!@#$%^&*(),.?"":{ }|<>]");
            if (numbersOrCharacters.IsMatch(str))
            {
                return false;
            }
            return true;
        }
    }
}