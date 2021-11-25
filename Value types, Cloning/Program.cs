using System;

namespace Value_types__Cloning
{
    internal static class Program
    {
        private static void Main()
        {
            var p1 = new Person {Name = "Tom", Age = 23, Work = new Company {Name = "Microsoft"}};
            var p2 = (Person) p1.Clone(); //клонирование
            p2.Work.Name = "Google";
            p2.Name = "Alice";
            Console.WriteLine(p1.Name); // Tom
            Console.WriteLine(p1.Work.Name); // Microsoft
            Console.WriteLine(p2.Name); // Alice
            Console.WriteLine(p2.Work.Name); // Google
            Console.Read();
        }
    }
}