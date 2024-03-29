﻿using System;
using System.Text.RegularExpressions;

namespace Regular_expression
{
    internal static class Program
    {
        private static void Main()
        {
            // выделить числа из текста(1, 1000, 1 000 000, 100.23)
            Method1();
            // удалить из выражения повторяющиеся пробелы, между токенами д.б. 1 пробел
            Method2();
            //  проверить что вводимое число -корректный номер телефона(+373 77767852, 77767852, 0 (777) 67852)
            Method3();
        }

        private static void Method1()
        {
            const string stringLine = "1, 1000, 1 000 000, 100.23";
            var regex = new Regex(@"(\d{1,3}\s(\d{3}\s?)*)|(\d+\.\d+)|\d+");
            var matches = regex.Matches(stringLine);
            if (matches.Count > 0)
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            else
                Console.WriteLine("Совпадений не найдено");
        }

        private static void Method2()
        {
            const string s = "Мама  мыла  раму. ";
            var pattern = @"\s+";
            const string target = " ";
            var regex = new Regex(pattern);
            var result = regex.Replace(s, target);
            Console.WriteLine(result);
        }

        private static void Method3()
        {
            Console.WriteLine("Введите номер телефона");
            var number = Console.ReadLine();
            const string reg = @"(\+\d{3}\s\d{8})|(0\s\(\d{3}\)\s\d{5})|\d{8}";
            Console.WriteLine(
                Regex.IsMatch(number ?? string.Empty, reg)
                    ? " Номер:{0}-Существующий номер"
                    : "Номер: {0}-Ошибочный номер", number);
            Console.ReadLine();
        }
    }
}