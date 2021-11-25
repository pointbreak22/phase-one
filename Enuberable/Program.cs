using System;

namespace Enumeration
{
    internal static class Program
    {
        private static void Main()
        {
            var machines = new Machines();
            for (var i = 1; i < 5; i++)
            {
                machines.FlagMachines = i;
                Console.Write("Модель №:" + i + "--");
                foreach (var m in machines) Console.Write(m + " ");
                Console.WriteLine("\n");
            }

            Console.WriteLine("Через while");
            machines.FlagMachines = 1;
            var whileEnum = machines.GetEnumerator();
            while (whileEnum.MoveNext()) Console.WriteLine(whileEnum.Current);
            Console.Read();
        }
    }
}