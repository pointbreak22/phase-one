using System;
using System.Collections;

namespace Enumeration
{
    public class Machines : IEnumerable
    {
        private readonly string[] _bmv = { "bm_11", "bm_22", "bm_33" };
        private readonly string[] _skoda = { "sh_11", "sh_22", "sh_33", "sh_43" };
        private readonly string[] _ford = { "fr_11", "fr_22", "fr_33", "fr_83" };
        public int FlagMachines { get; set; }

        public IEnumerator GetEnumerator()
        {
            switch (FlagMachines)
            {
                case 1: return _bmv.GetEnumerator();
                case 2: return _skoda.GetEnumerator();
                case 3: return _ford.GetEnumerator();
                default: Console.WriteLine("Даной модели не существует"); return new object[0].GetEnumerator();
            }
        }
    }
}