using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CSVTools
{
    internal static class StringExtensions
    {
        internal static string Repeat(this string str, int count)
        {
            if(count < 1) throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0");
            return string.Join("", Enumerable.Repeat(str, count));
        }

        internal static string Repeat(this char c, int count)
        {
            if (count < 1) throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0");
            return new string(c, count);
        }
    }
}
