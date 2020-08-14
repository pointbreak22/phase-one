using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitConversion
{
  public class Person2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //конструкция явного преобразования
        public static explicit operator Person2(string s)
        {
            return new Person2() { FirstName = s.Split(" ")[0], LastName = s.Split(" ")[1] };
        }
        public static explicit operator string(Person2 p2)
        {
            return p2.FirstName.ToString() + " " + p2.LastName.ToString();
        }
    }
}
