using System;
using System.Collections.Generic;
using System.Text;

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
    }
}