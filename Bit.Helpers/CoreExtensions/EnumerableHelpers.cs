using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Helpers.CoreExtensions
{
    public static class EnumerableHelpers
    {
        public static string ToSingleString<T>(this IEnumerable<T> enumerable, string separator = "")
        {
            return string.Join(separator, enumerable.Select(x => x == null ? "" : x.ToString()));
        }
    }
}
