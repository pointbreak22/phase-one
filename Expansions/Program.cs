﻿using System;

namespace Expansions
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Вывод 5 секунд: " + 5.Seconds());
            Console.WriteLine("Вывод 5 минут: " + 5.Hours());
            Console.WriteLine("Вывод 5 дней: " + 5.Days());
            Console.ReadLine();
        }
    }
}