using System;
using System.Text.RegularExpressions;

namespace Regular_Expression
{
    internal class Program
    {
        private static void Main(string[] args)
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
            string str = "1, 1000, 1 000 000, 100.23";
            Regex regex = new Regex(@"(\d{1,3}\s(\d{3}\s?)*)|(\d+\.\d+)|\d+");
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
        }

        private static void Method2()
        {
            string s = "Мама  мыла  раму. ";
            string pattern = @"\s+";
            string target = " ";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(s, target);
            Console.WriteLine(result);
        }

        private static void Method3()
        {
            Console.WriteLine("Введите номер телефона");
            string number = Console.ReadLine();
            string reg = @"(\+\d{3}\s\d{8})|(0\s\(\d{3}\)\s\d{5})|\d{8}";
            if (Regex.IsMatch(number, reg))
            {
                Console.WriteLine(" Номер:{0}-Существующий номер", number);
            }
            else
            {
                Console.WriteLine("Номер: {0}-Ошибочный номер", number);
            }
            Console.ReadLine();
        }
    }
}