using System;
using System.Collections;

namespace Enuberable
{
    public class Machines : IEnumerable
    {
        private string[] _nomerabmv = { "bm_11", "bm_22", "bm_33" };
        private string[] _nomerashkoda = { "sh_11", "sh_22", "sh_33", "sh_43" };
        private string[] _nomeraford = { "fr_11", "fr_22", "fr_33", "fr_83" };

        public int FlagViboraMachines { get; set; }

        public IEnumerator GetEnumerator()
        {
            switch (FlagViboraMachines)
            {
                case 1: return _nomerabmv.GetEnumerator(); break;
                case 2: return _nomerashkoda.GetEnumerator(); break;
                case 3: return _nomeraford.GetEnumerator(); break;
                default: Console.WriteLine("Данной модели не существует"); return new object[0].GetEnumerator(); break;
            }
        }
    }
}