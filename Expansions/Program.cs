using System;

namespace Expansions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод 5 секунд: " + 5.Seconds());
            Console.WriteLine("Вывод 5 минут: " + 5.Hours());
            Console.WriteLine("Вывод 5 дней: " + 5.Days());
            Console.ReadLine();
        }
    }  
}
