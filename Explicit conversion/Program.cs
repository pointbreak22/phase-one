using System;

namespace ExplicitConversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите имя и фамилию в строку через пробел");
            string str = Console.ReadLine();

            Person1 person1;
            Person2 person2;

            // не явное преобразование
            person1 = str;
            string s1 = person1;

            //явное преобразование
            person2 = (Person2)str;
            string s2 = (string)person2;

            Console.WriteLine("Строка не явного преобразования: " + s1 + "\n " + (s1 == person1) + " " + s1.Equals(person1).ToString() + " " + person1.Equals(s1).ToString());
            Console.WriteLine();
            Console.WriteLine("Строка не явного преобразования: " + s2 + "\n " + s2.Equals(person2).ToString() + " " + person2.Equals(s2).ToString());

            Console.ReadLine();
        }
    }
}