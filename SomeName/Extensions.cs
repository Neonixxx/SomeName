﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public static class Extensions
    {
        public static int ToInt32(this string word)
            => Int32.Parse(word);

        public static int ToInt32(this double value)
            => Convert.ToInt32(value);

        public static int ToInt32(this long value)
            => Convert.ToInt32(value);

        public static long ToInt64(this string word)
            => Int64.Parse(word);

        public static double ToDouble(this long value)
            => Convert.ToDouble(value);

        public static string ToPercentString(this double value)
            => value.ToString("F2") + "%";

        public static bool ContainsOnly<T>(this IEnumerable<T> enumerable, params T[] items)
            => enumerable.Count() == enumerable.Intersect(items).Count();
    }
}
