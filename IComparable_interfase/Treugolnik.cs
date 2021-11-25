using System;

namespace IComparableInterface
{
    internal class Triangle : IComparable
    {
        public int Leg1 { get; set; }
        public int Leg2 { get; set; }
        public int Hypotenuse { get; set; }

        public int CompareTo(object o)
        {
            if (o is Triangle t)
                return Hypotenuse.CompareTo(t.Hypotenuse);
            throw new Exception("Невозможно сравнить два объекта");
        }
    }
}