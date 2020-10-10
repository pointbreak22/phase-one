using System;

namespace IComparableInterfase
{
    internal class Treugolnik : IComparable
    {
        public int Katet1 { get; set; }
        public int Katet2 { get; set; }
        public int Gipotenuza { get; set; }

        public int CompareTo(object o)
        {
            Treugolnik t = o as Treugolnik;
            if (t != null)
            {
                return this.Gipotenuza.CompareTo(t.Gipotenuza);
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }
        }
    }
}