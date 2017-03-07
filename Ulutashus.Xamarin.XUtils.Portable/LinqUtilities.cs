using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulutashus.Xamarin.XUtils.Portable
{
    public class LinqUtilities
    {
        public static IEnumerable<T> ConcatAll<T>(params IEnumerable<T>[] enumerables)
        {
            IEnumerable<T> result = new List<T>();
            foreach(var enumerable in enumerables)
            {
                if(enumerable != null)
                {
                    result = result.Concat(enumerable);
                }
            }
            return result;
        }

        public static R MinInAll<T,R>(Func<T,R> selector, params IEnumerable<T>[] enumerables)
        {
            var mins = new List<R>();
            foreach (var enumerable in enumerables)
            {
                if (enumerable != null && enumerable.Any())
                {
                    mins.Add(enumerable.Min(selector));
                }
            }
            return mins.Any() ? mins.Min() : default(R);
        }

        public static R MaxInAll<T, R>(Func<T, R> selector, params IEnumerable<T>[] enumerables)
        {
            var mins = new List<R>();
            foreach (var enumerable in enumerables)
            {
                if (enumerable != null && enumerable.Any())
                {
                    mins.Add(enumerable.Max(selector));
                }
            }
            return mins.Any() ? mins.Max() : default(R);
        }

        public static IEnumerable<IEnumerable<T>> SplitSets<T>(IEnumerable<T> source, int setSize)
        {
            if (source == null)
                return null;

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / setSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
