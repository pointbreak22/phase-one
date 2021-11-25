using System;

namespace ExplicitConversion
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Введите имя и фамилию в строку через пробел");
            var stringLine = Console.ReadLine() ?? throw new ArgumentNullException();

            // не явное преобразование
            Person1 person1 = stringLine;
            var s1 = person1;

            //явное преобразование
            var person2 = (Person2) stringLine;
            var s2 = (string) person2;

            Person3 person3 = stringLine;
            var s3 = (string) person3;

            var person4 = (Person4) stringLine;
            string s4 = person4;

            Console.WriteLine("Строка не явного преобразования: " + s1 + "\n " + (s1 == person1) + " " +
                              s1.Equals(person1) + " " + person1.Equals(s1));
            Console.WriteLine();
            Console.WriteLine("Строка явного преобразования: " + s2 + "\n " + s2.Equals(person2) + " " +
                              person2.Equals(s2));
            Console.WriteLine();
            Console.WriteLine("Строка не явно/явно преобразования: " + s3 + "\n " + " " + s3.Equals(person3) + " " +
                              person3.Equals(s3));
            Console.WriteLine();
            Console.WriteLine("Строка явно/не явно преобразования: " + s4 + "\n " + (s4 == person4) + " " +
                              s4.Equals(person4) + " " + person4.Equals(s4));

            Console.ReadLine();
        }
    }
}