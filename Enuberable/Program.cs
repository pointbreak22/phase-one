using System;
using System.Collections;

namespace Enumeration
{
    internal class Program
    {
        private static void Main()
        {
            Machines machines = new Machines();
            for (int i = 1; i < 5; i++)
            {
                machines.FlagMachines = i;
                Console.Write("Модель №:" + i.ToString() + "--");
                foreach (object? m in machines)
                {
                    Console.Write(m + " ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Через while");
            machines.FlagMachines = 1;
            IEnumerator whileEnum = machines.GetEnumerator();
            while (whileEnum.MoveNext())
            {
                Console.WriteLine(whileEnum.Current);
            }
            Console.Read();
        }
    }
}