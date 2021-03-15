using Explicit_conversion;
using System;

namespace ExplicitConversion
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Введите имя и фамилию в строку через пробел");
            string str = Console.ReadLine();

            Person1 person1;
            Person2 person2;
            Person3 person3;
            Person4 person4;

            // не явное преобразование
            person1 = str;
            string s1 = person1;

            //явное преобразование
            person2 = (Person2)str;
            string s2 = (string)person2;

            person3 = str;
            string s3 = (string)person3;

            person4 = (Person4)str;
            string s4 = person4;

            Console.WriteLine("Строка не явного преобразования: " + s1 + "\n " + (s1 == person1) + " " + s1.Equals(person1).ToString() + " " + person1.Equals(s1).ToString());
            Console.WriteLine();
            Console.WriteLine("Строка явного преобразования: " + s2 + "\n " /*+ (s2==person2).ToString()*/ + s2.Equals(person2).ToString() + " " + person2.Equals(s2).ToString());
            Console.WriteLine();
            Console.WriteLine("Строка не явно/явно преобразования: " + s3 + "\n "/* + (s3 == person3) */+ " " + s3.Equals(person3).ToString() + " " + person3.Equals(s3).ToString());
            Console.WriteLine();
            Console.WriteLine("Строка явно/не явно преобразования: " + s4 + "\n " + (s4 == person4) + " " + s4.Equals(person4).ToString() + " " + person4.Equals(s4).ToString());

            Console.ReadLine();
        }
    }
}