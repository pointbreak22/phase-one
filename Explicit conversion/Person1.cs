using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitConversion
{
  public class Person1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //конструкция не явного преобразования
        public static implicit operator Person1(string s)
        {
            return new Person1() { FirstName = s.Split(" ")[0], LastName = s.Split(" ")[1] };
        }
        public static implicit operator string(Person1 p2)
        {
            return p2.FirstName.ToString() + " " + p2.LastName.ToString();
        }
    }
}
