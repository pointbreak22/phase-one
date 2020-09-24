using System;
using System.Collections.Generic;
using System.Text;

namespace Expansions
{
    public static class StringExtensions
    {
        public static TimeSpan Seconds(this int k)
        {
            if (k == null)
            {
                throw new ArgumentNullException("Parametr is null", nameof(k));
            }

            return new TimeSpan(0, 0, k);
        }
        public static TimeSpan Hours(this int k)
        {
            if (k == null)
            {
                throw new ArgumentNullException("Parametr is null", nameof(k));
            }

            return new TimeSpan(0, k, 0);
        }
        public static TimeSpan Days(this int k)
        {
            if (k == null)
            {
                throw new ArgumentNullException("Parametr is null", nameof(k));
            }

            return new TimeSpan(k, 0, 0, 0);
        }
    }
}
