using System;
using System.Collections.Generic;
using System.Linq;

namespace LIst
{
    class Person
    {
        public string Fio { get; set; }
        public DateTime Date { get; set; }
        public string PlaceOfBirt { get; set; }
        public int PassportNumber { get; set; }
        public string PlaceOfWork { get; set; }
        public override bool Equals(object obj) //сравнение по параметрам
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var pr = (Person)obj;
            return pr.Fio == Fio && pr.Date == Date && pr.PlaceOfBirt == PlaceOfBirt && pr.PassportNumber == PassportNumber;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Person> persons = new Dictionary<int, Person>();
            persons.Add(1, new Person { Fio = "Петр", Date = DateTime.Parse("Jan 1, 2009"), PlaceOfBirt = "Западный", PassportNumber = 123, PlaceOfWork = "Cтроитель" });
            Console.WriteLine("Введите Fio (Петр) ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите дату рождения (Jan 1, 2009) ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите место жительства (Западный) ");
            string PlaceOfBirth = Console.ReadLine();
            Console.WriteLine("Введите номер пасспорта (123) ");
            int PassportNumber = Convert.ToInt32(Console.ReadLine());
            Person seach = new Person { Fio = fio, Date = date, PlaceOfBirt = PlaceOfBirth, PassportNumber = PassportNumber };
            foreach (KeyValuePair<int, Person> dict in persons)
            {

                if (seach.Equals(dict.Value))
                    Console.WriteLine("он " + dict.Value.PlaceOfWork);
                else Console.WriteLine("Его не существует");
            }
            Console.ReadLine();
        }
    }

}
