using System;
using System.Collections.Generic;
using System.Linq;

namespace CDD.Utility
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
            => items.ToList().ForEach(action);

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> items, T item)
        {
            return new[] { item }.Concat(items);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> items, T item)
        {
            return items.Concat(new[] { item });
        }

        public static string CamelCaseToWords(this string camel)
        {
            var camelWordIndices = camel.Select((c, i) => new {c, i})
                .Where(ci => ci.i > 0 && char.IsUpper(ci.c))
                .Select(ci => ci.i)
                .ToArray();
            var wordEnds = camelWordIndices.Append(camel.Length).ToArray();
            var firstWord = camel.Substring(0, wordEnds.First());
            var camelWords = wordEnds.Skip(1)
                .Select((end, prevI) => camel.Substring(wordEnds[prevI], end - wordEnds[prevI]))
                .Select(word => word.ToLower());
            return string.Join(" ", camelWords.Prepend(firstWord));
        }
    }
}
