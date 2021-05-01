using System;
using System.Linq;

namespace IQurable
{
    internal class Program
    {
        private static readonly Random Random = new Random();
        private static int _arbitraryLineLength;
        private static string _formLine;
        private static int _theChoice;
        private static readonly CustomType[] CustomTypes = new CustomType[100];

        private static void RandomNext()
        {
            for (int i = 0; i < 100; i++)
            {
                _formLine = "";
                _arbitraryLineLength = Random.Next(1, 10);
                for (int j = 0; j < _arbitraryLineLength; j++)
                {
                    _formLine += (char)(Random.Next(65, 91));
                }
                _theChoice = Random.Next(2);
                CustomTypes[i] = new CustomType { Line = _formLine, Number = Random.Next(100), Date = DateTime.FromBinary((long)(Random.Next(100000000, 999999999) * (long)Random.Next(100000000, 999999999))), TrueFalse = (_theChoice == 1) };
                Console.WriteLine("id: " + i + "     | \"" + CustomTypes[i].Line + "\" | " + CustomTypes[i].Number.ToString() + " | " + CustomTypes[i].Date.ToString() + " | " + CustomTypes[i].TrueFalse.ToString());
            }
        }

        private static void Linq1()
        {
            Console.WriteLine("\n Выбрать обьекты где Number больше 50 и сортировать по строкам \n ");
            IOrderedEnumerable<CustomType> filterable = CustomTypes
                .Where(t => t.Number > 50)
                .OrderBy(t => t.Line);
            foreach (CustomType s in filterable)
            {
                Console.WriteLine("Выбрано: " + s.Line + "\" | " + s.Number.ToString() + " | " + s.Date.ToString("d") + " | " + s.TrueFalse);
            }
            Console.WriteLine("\n Группировка истина,ложь \n ");
        }

        private static void Linq2()
        {
            var trueFalse = CustomTypes.GroupBy(p => p.TrueFalse)
                        .Select(g => new
                        {
                            thecHoice = g.Key,
                            Count = g.Count(),
                            output = g.Select(p => p)
                        });

            foreach (var group in trueFalse)
            {
                Console.WriteLine($"{group.thecHoice} : {group.Count}");
                foreach (CustomType сtт in group.output)
                {
                    Console.WriteLine("Выбрано: " + сtт.Line + "\" | " + сtт.Number.ToString("N") + " | " + сtт.Date.ToString("d"));
                }
                Console.WriteLine();
            }
        }

        private static void Linq3()
        {
            Console.WriteLine("\n Есть ли Number 30? \n ");
            Console.WriteLine(CustomTypes.Any(u => u.Number == 30) ? "да" : "нет");
            Console.WriteLine("\n Все коллекции истинны? \n ");
            Console.WriteLine(CustomTypes.All(u => u.TrueFalse == true) ? "да" : "нет");
            Console.WriteLine("\n Cумма чисел=" + CustomTypes.Sum(i => i.Number) + ", Миниум" + CustomTypes.Min(i => i.Number) + ", Максиум" + CustomTypes.Max(i => i.Number) + " \n ");
            Console.ReadLine();
        }

        private static void Main()
        {
            RandomNext();
            Linq1();
            Linq2();
            Linq3();
        }
    }
}