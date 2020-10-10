using System;

namespace Expansions
{
    public static class StringExtensions
    {
        public static TimeSpan Seconds(this int k)
        {
            return new TimeSpan(0, 0, k);
        }

        public static TimeSpan Hours(this int k)
        {
            return new TimeSpan(0, k, 0);
        }

        public static TimeSpan Days(this int k)
        {
            return new TimeSpan(k, 0, 0, 0);
        }
    }
}