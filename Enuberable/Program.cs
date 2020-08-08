using System;
using System.Collections;

namespace Enuberable
{
    class Program
    {
        static void Main(string[] args)
        {
            Machines machines = new Machines();
            for (int i = 1; i < 5; i++)
            {
                machines.FlagViboraMachines = i;
                Console.Write("Модель №:" + i.ToString() + "--");
                foreach (var m in machines)
                {
                    Console.Write(m + " ");
                }
                Console.WriteLine("\n");


            }
            Console.WriteLine("Через while");
            machines.FlagViboraMachines = 1;
            var whileenum = machines.GetEnumerator();
            while (whileenum.MoveNext())
            {
                Console.WriteLine(whileenum.Current);
            }
            Console.Read();
        }
    }
    class Machines : IEnumerable
    {
        string[] nomerabmv = { "bm_11", "bm_22", "bm_33" };
        string[] nomerashkoda = { "sh_11", "sh_22", "sh_33", "sh_43" };
        string[] nomeraford = { "fr_11", "fr_22", "fr_33", "fr_83" };

        public int FlagViboraMachines { get; set; }

        public IEnumerator GetEnumerator()
        {
            switch (FlagViboraMachines)
            {
                case 1: return nomerabmv.GetEnumerator(); break;
                case 2: return nomerashkoda.GetEnumerator(); break;
                case 3: return nomeraford.GetEnumerator(); break;
                default: Console.WriteLine("Данной модели не существует"); return new object[0].GetEnumerator(); break;
            }
        }
    }


}
