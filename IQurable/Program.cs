using System;
using System.Linq;

namespace IQurable
{
    internal class Program
    {
        private static Random random = new Random();
        private static int arbitrarylinelength;
        private static string formline;
        private static int thechoice;
        private static CustomType[] сt = new CustomType[100];

        private static void randomnext()
        {
            for (int i = 0; i < 100; i++)
            {
                formline = "";
                arbitrarylinelength = random.Next(1, 10);
                for (int j = 0; j < arbitrarylinelength; j++)
                {
                    formline += (char)(random.Next(65, 91));
                }
                thechoice = random.Next(2);
                сt[i] = new CustomType { Line = formline, Number = random.Next(100), Date = DateTime.FromBinary((long)(random.Next(100000000, 999999999) * (long)random.Next(100000000, 999999999))), TrueFalse = (thechoice == 1) ? true : false };
                Console.WriteLine("id: " + i + "     | \"" + сt[i].Line.ToString() + "\" | " + сt[i].Number.ToString() + " | " + сt[i].Date.ToString() + " | " + сt[i].TrueFalse.ToString());
            }
        }

        private static void linq1()
        {
            Console.WriteLine("\n Выбрать обьекты где Number больше 50 и сортировать по строкам \n ");
            var filterandsortquery = сt
                .Where(t => t.Number > 50)
                .OrderBy(t => t.Line);
            foreach (CustomType s in filterandsortquery)
            {
                Console.WriteLine("Выбрано: " + s.Line.ToString() + "\" | " + s.Number.ToString() + " | " + s.Date.ToString() + " | " + s.TrueFalse.ToString());
            }
            Console.WriteLine("\n Группировка истина,ложь \n ");
        }

        private static void linq2()
        {
            var TrueFalse = сt.GroupBy(p => p.TrueFalse)
                        .Select(g => new
                        {
                            thechoice = g.Key,
                            Count = g.Count(),
                            output = g.Select(p => p)
                        });

            foreach (var group in TrueFalse)
            {
                Console.WriteLine($"{group.thechoice} : {group.Count}");
                foreach (CustomType сtт in group.output)
                {
                    Console.WriteLine("Выбрано: " + сtт.Line.ToString() + "\" | " + сtт.Number.ToString() + " | " + сtт.Date.ToString());
                }
                Console.WriteLine();
            }
        }

        private static void linq3()
        {
            Console.WriteLine("\n Есть ли Number 30? \n ");
            if (сt.Any(u => u.Number == 30))
            {
                Console.WriteLine("да");
            }
            else
            {
                Console.WriteLine("нет");
            }
            Console.WriteLine("\n Все коллекции истинны? \n ");
            if (сt.All(u => u.TrueFalse == true))
            {
                Console.WriteLine("да");
            }
            else
            {
                Console.WriteLine("нет");
            }
            Console.WriteLine("\n Cумма чисел=" + сt.Sum(i => i.Number) + ", Миниум" + сt.Min(i => i.Number) + ", Максиум" + сt.Max(i => i.Number) + " \n ");
            Console.ReadLine();
        }

        private static void Main(string[] args)
        {
            randomnext();
            linq1();
            linq2();
            linq3();
        }
    }

    internal class CustomType
    {
        public string Line { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public bool TrueFalse { get; set; }
    }
}