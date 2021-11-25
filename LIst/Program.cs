using System;
using System.Collections.Generic;

namespace List
{
    internal static class Program
    {
        private static void Main()
        {
            var persons = new Dictionary<int, Person>
            {
                {
                    1,
                    new Person
                    {
                        Fio = "Петр", Date = DateTime.Parse("Jan 1, 2009"), PlaceOfBirth = "Западный",
                        PassportNumber = 123, PlaceOfWork = "Cтроитель"
                    }
                }
            };
            Console.WriteLine("Введите Fio (Петр) ");
            var fio = Console.ReadLine();
            Console.WriteLine("Введите дату рождения (Jan 1, 2009) ");
            var date = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Введите место жительства (Западный) ");
            var placeOfBirth = Console.ReadLine();
            Console.WriteLine("Введите номер пасспорта (123) ");
            var passportNumber = Convert.ToInt32(Console.ReadLine());
            var search = new Person
                {Fio = fio, Date = date, PlaceOfBirth = placeOfBirth, PassportNumber = passportNumber};
            foreach (var dict in persons)
                if (search.Equals(dict.Value))
                    Console.WriteLine("он " + dict.Value.PlaceOfWork);
                else
                    Console.WriteLine("Его не существует");
            Console.ReadLine();
        }
    }
}