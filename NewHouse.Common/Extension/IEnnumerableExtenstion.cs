using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewHouse.Common.Extension
{
    public static class IEnnumerableExtenstion
    {
        public static T MinOrDefault<T>(this IEnumerable<T> list) where T : IComparable
        {
            if (list is null || list.Count() == 0)
            {
                return default(T);
            }
            return list.Min();
        }

        public static T MaxOrDefault<T>(this IEnumerable<T> list) where T : IComparable
        {
            if (list is null || list.Count() == 0)
            {
                return default(T);
            }
            return list.Max();
        }
    }
}