using System;
using System.Collections.Generic;
using System.Text;

namespace IComparableInterfase
{
    class TreugolnikComparer : IComparer<Treugolnik>
    {
        public int Compare(Treugolnik t1, Treugolnik t2)
        {
            if (t1.Katet1 * t1.Katet2 > t2.Katet1 * t2.Katet2)
            {
                return 1;
            }
            else if (t1.Katet1 * t1.Katet2 < t2.Katet1 * t2.Katet2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
