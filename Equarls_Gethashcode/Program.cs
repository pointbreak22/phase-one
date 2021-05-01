using System;

namespace EqualsGetHashCode
{
    internal class Program
    {
        private static void Main()
        {
            Person p1 = new Person { Fio = "f1", Date = DateTime.Today, PlaceOfBirth = "d4", PassportNumber = 5 };
            Person p2 = new Person { Fio = "f1", Date = DateTime.Today, PlaceOfBirth = "d4" };
            Person p3 = new Person { Fio = "f2", Date = DateTime.Today, PlaceOfBirth = "d4", PassportNumber = 6 };
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.Equals(p3));
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p3.GetHashCode());
            Console.ReadLine();
        }
    }
}