﻿using System;

namespace Reflection
{
    public class User
    {
        private int _type = 10;
        private int _type2 = 15;
        public string NamePeaple { get; set; }
        private string _NamePeaple2 { get; set; }
        public int Age { get; set; }

        public User(string n, int a)
        {
            NamePeaple = n;
            Age = a;
        }

        public void Display()
        {
            Console.WriteLine($"Имя: {NamePeaple}  Возраст: {Age}");
        }

        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}