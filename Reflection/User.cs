﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class User
    {
        private int type = 10;
        private int type2 = 15;
        public string NamePeaple { get; set; }
        private string NamePeaple2 { get; set; }
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