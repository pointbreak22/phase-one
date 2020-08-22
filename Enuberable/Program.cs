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
            var  whileenum = machines.GetEnumerator();
            while (whileenum.MoveNext())
            {
                Console.WriteLine(whileenum.Current);
            }
            Console.Read();
        }
    } 
}
