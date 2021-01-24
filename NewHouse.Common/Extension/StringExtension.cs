using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NewHouse.Common.Extension
{
    /// <summary>
    /// string的擴充方法
    /// </summary>
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return s is null || s.Equals(string.Empty);
        }

        public static List<int> ToIntList(this string s)
        {
            var intList = new List<int>();
            if (s.IsNullOrEmpty())
            {
                return intList;
            }

            var matches = Regex.Split(s, @"\D+");
            foreach (var match in matches)
            {
                if (int.TryParse(match, out var number))
                {
                    intList.Add(number);
                }
            }

            return intList;
        }
    }
}