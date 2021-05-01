using System;
using System.Collections.Generic;

namespace List
{
    internal class Program
    {
        private static void Main()
        {
            Dictionary<int, Person> persons = new Dictionary<int, Person>
            {
                { 1, new Person { Fio = "Петр", Date = DateTime.Parse("Jan 1, 2009"), PlaceOfBirth = "Западный", PassportNumber = 123, PlaceOfWork = "Cтроитель" } }
            };
            Console.WriteLine("Введите Fio (Петр) ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите дату рождения (Jan 1, 2009) ");
            DateTime date = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Введите место жительства (Западный) ");
            string PlaceOfBirth = Console.ReadLine();
            Console.WriteLine("Введите номер пасспорта (123) ");
            int passportNumber = Convert.ToInt32(Console.ReadLine());
            Person seach = new Person { Fio = fio, Date = date, PlaceOfBirth = PlaceOfBirth, PassportNumber = passportNumber };
            foreach (KeyValuePair<int, Person> dict in persons)
            {
                if (seach.Equals(dict.Value))
                {
                    Console.WriteLine("он " + dict.Value.PlaceOfWork);
                }
                else
                {
                    Console.WriteLine("Его не существует");
                }
            }
            Console.ReadLine();
        }
    }
}