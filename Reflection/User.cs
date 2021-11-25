using System;

namespace Reflection
{
    public class User
    {
        public User(string n, int a)
        {
            PeopleName = n;
            Age = a;
        }

        private string PeopleName { get; set; }
        public int Age { get; set; }

        public void Display()
        {
            Console.WriteLine($"Имя: {PeopleName}  Возраст: {Age}");
        }

        public int Payment(int hours, int perHour)
        {
            return hours * perHour;
        }
    }
}