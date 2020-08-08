using System;
using System.Linq;

namespace IQurable
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int arbitrarylinelength;
         
            string formline;
            int thechoice;
            CustomType[] сt = new CustomType[100];
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
            Console.WriteLine("\n Выбрать обьекты где Number больше 50 и сортировать по строкам \n ");
            var filterandsortquery = сt
                .Where(t => t.Number > 50)
                .OrderBy(t => t.Line);
            foreach (CustomType s in filterandsortquery)
            {
                Console.WriteLine("Выбрано: " + s.Line.ToString() + "\" | " + s.Number.ToString() + " | " + s.Date.ToString() + " | " + s.TrueFalse.ToString());
            }
            Console.WriteLine("\n Группировка истина,ложь \n ");
          
            var TrueFalse = from i in сt
                             group i by i.TrueFalse into g
                             select new
                             {
                                 thechoice = g.Key,
                                 Count = g.Count(),
                                 output = from с in g select с
                             };
            foreach (var group in TrueFalse)
            {
                Console.WriteLine($"{group.thechoice} : {group.Count}");
                foreach (CustomType сtт in group.output)
                {
                    Console.WriteLine("Выбрано: " + сtт.Line.ToString() + "\" | " + сtт.Number.ToString() + " | " + сtт.Date.ToString());
                }
                Console.WriteLine();
            }
          
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
    }
    class CustomType
    {
        public string Line { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public bool TrueFalse { get; set; }

    }
}
