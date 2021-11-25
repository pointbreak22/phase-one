using System.Collections.Generic;
using System.Diagnostics;

namespace IComparableInterface
{
    internal class TriangleComparer : IComparer<Triangle>
    {
        public int Compare(Triangle t1, Triangle t2)
        {
            Debug.Assert(t1 != null, nameof(t1) + " != null");
            Debug.Assert(t2 != null, nameof(t2) + " != null");
            if (t1.Leg1 * t1.Leg2 > t2.Leg1 * t2.Leg2)
                return 1;
            if (t1.Leg1 * t1.Leg2 < t2.Leg1 * t2.Leg2)
                return -1;
            return 0;
        }
    }
}