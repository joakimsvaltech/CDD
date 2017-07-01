using System;
using System.Collections.Generic;
using System.Linq;

namespace CDD.Utility
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
            => items.ToList().ForEach(action);
    }
}
