using System;
using System.Linq;

namespace IQurable
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int arbitrary_line_length;
            int character_id;
            string form_line;
            int the_choice;       



           Custom_type[] сt = new Custom_type[100];

            for (int i = 0; i < 100; i++)
            {
                form_line = "";
                arbitrary_line_length = random.Next(1,10);
                for (int j = 0; j < arbitrary_line_length; j++)
                    form_line += (char)(random.Next(65, 91));
                the_choice = random.Next(2);
                сt[i] = new Custom_type { Line = form_line, Number = random.Next(100), Date = DateTime.FromBinary((long)(random.Next(100000000, 999999999)* (long)random.Next(100000000, 999999999))), True_false = (the_choice == 1) ? true : false };
                    Console.WriteLine("id: "+i+"     | \""+ сt[i].Line.ToString()+"\" | "+ сt[i].Number.ToString() + " | " + сt[i].Date.ToString() + " | " + сt[i].True_false.ToString());

            }

            Console.WriteLine("\n Выбрать обьекты где Number больше 50 и сортировать по строкам \n ");
            var filter_and_sort_query =  сt.Where(t => t.Number>50).OrderBy(t => t.Line);
            foreach (Custom_type s in filter_and_sort_query)
                Console.WriteLine("Выбрано: " + s.Line.ToString() + "\" | " + s.Number.ToString() + " | " + s.Date.ToString() + " | " + s.True_false.ToString());


            Console.WriteLine("\n Группировка истина,ложь \n ");
            var true_false = from i in сt
                               group i by i.True_false into g
                               select new
                               {
                                   the_choice = g.Key,
                                   Count = g.Count(),
                                   output = from с in g select с
                                   
                               };
            foreach (var group in true_false)
            {
                Console.WriteLine($"{group.the_choice} : {group.Count}");
                foreach (Custom_type сtт in group.output)
                    Console.WriteLine("Выбрано: " + сtт.Line.ToString() + "\" | " + сtт.Number.ToString() + " | " + сtт.Date.ToString());
                Console.WriteLine();
            }

            Console.WriteLine("\n Есть ли Number 30? \n ");
            if (сt.Any(u => u.Number == 30))
                Console.WriteLine("да");
            else
                Console.WriteLine("нет");

            Console.WriteLine("\n Все коллекции истинны? \n ");
            if (сt.All(u => u.True_false==true))
                Console.WriteLine("да");
            else
                Console.WriteLine("нет");


            Console.WriteLine("\n Cумма чисел="+сt.Sum(i=>i.Number) +", Миниум"+сt.Min(i => i.Number) + ", Максиум"+ сt.Max(i => i.Number )+ " \n ");

            Console.ReadLine();
        }
    }

    class Custom_type
    {
        public string Line { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public bool True_false { get; set; }

    }
}
