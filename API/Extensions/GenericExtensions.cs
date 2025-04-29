using System;
using System.Collections.Generic;

namespace DZCP.MapCreator.API.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }
    }}