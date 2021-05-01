using System;

namespace ExplicitConversion
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Введите имя и фамилию в строку через пробел");
            string stringLine = Console.ReadLine() ?? throw new ArgumentNullException();

            // не явное преобразование
            Person1 person1 = stringLine;
            Person1 s1 = person1;

            //явное преобразование
            Person2 person2 = (Person2)stringLine;
            string s2 = (string)person2;

            Person3 person3 = stringLine;
            string s3 = (string)person3;

            Person4 person4 = (Person4)stringLine;
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