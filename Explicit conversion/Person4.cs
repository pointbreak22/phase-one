using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitConversion
{
    internal class Person4
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //конструкция явного преобразования
        public static explicit operator Person4(string s)
        {
            if (s.Split(" ").Length != 2)
            {
                throw new ArgumentException("Отсутствие имени и фамилии через пробел", nameof(s));
            }
            return new Person4() { FirstName = s.Split(" ")[0], LastName = s.Split(" ")[1] };
        }

        public static implicit operator string(Person4 p2)
        {
            if (p2 == null)
            {
                throw new ArgumentNullException(nameof(p2), "Object is null");
            }
            return p2.FirstName.ToString() + " " + p2.LastName.ToString();
        }
    }
}