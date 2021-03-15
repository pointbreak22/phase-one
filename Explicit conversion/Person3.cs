using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_conversion
{
    internal class Person3
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //конструкция явного преобразования
        public static implicit operator Person3(string s)
        {
            if (s.Split(" ").Length != 2)
            {
                throw new ArgumentException("Отсутствие имени и фамилии через пробел", nameof(s));
            }
            return new Person3() { FirstName = s.Split(" ")[0], LastName = s.Split(" ")[1] };
        }

        public static explicit operator string(Person3 p2)
        {
            if (p2 == null)
            {
                throw new ArgumentNullException("Object is null", nameof(p2));
            }
            return p2.FirstName.ToString() + " " + p2.LastName.ToString();
        }
    }
}