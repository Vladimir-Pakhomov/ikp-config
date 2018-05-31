using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Extensions
    {
        public static void ForAll<TSource>(this IEnumerable<TSource> source, Action<TSource> action) where TSource: class
        {
            foreach (var item in source)
                action(item);
        }
    }
}
