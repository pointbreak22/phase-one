using System;
using System.Collections.Generic;
using System.Linq;

namespace LIst
{

    class Person
    {
        public string Fio { get; set; }
        public DateTime Date { get; set; }
        public string Place_of_birt { get; set; }
        public int Passport_number { get; set; }
        public string Place_of_work { get; set; }
        public override bool Equals(object obj) //сравнение по параметрам
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var pr = (Person)obj;

           
            return pr.Fio == Fio && pr.Date == Date && pr.Place_of_birt == Place_of_birt && pr.Passport_number==Passport_number;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Person> persons = new Dictionary<int, Person>();
            persons.Add(1, new Person { Fio = "Петр", Date = DateTime.Parse("Jan 1, 2009"), Place_of_birt = "Западный", Passport_number = 123, Place_of_work="Cтроитель" });

            Console.WriteLine("Введите Fio (Петр) ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите дату рождения (Jan 1, 2009) ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите место жительства (Западный) ");
            string place_of_birth = Console.ReadLine();
            Console.WriteLine("Введите номер пасспорта (123) ");
            int passport_number =Convert.ToInt32(Console.ReadLine());

            Person seach = new Person { Fio = fio, Date = date, Place_of_birt = place_of_birth, Passport_number = passport_number };

            foreach (KeyValuePair<int, Person> dict in persons)
            {

                if (seach.Equals(dict.Value))
                    Console.WriteLine("он " + dict.Value.Place_of_work);
                else Console.WriteLine("Его не существует");
            }
            Console.ReadLine();
        }
    }

}
