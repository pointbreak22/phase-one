using System;

namespace ExplicitConversion
{
    public class Person1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //конструкция не явного преобразования
        public static implicit operator Person1(string s)
        {
            if (s.Split(" ").Length != 2)
            {
                throw new ArgumentException("Отсутствие имени и фамилии через пробел", nameof(s));
            }

            return new Person1() { FirstName = s.Split(" ")[0], LastName = s.Split(" ")[1] };
        }

        public static implicit operator string(Person1 p2)
        {
            if (p2 == null)
            {
                throw new ArgumentNullException("Object is null", nameof(p2));
            }

            return p2.FirstName.ToString() + " " + p2.LastName.ToString();
        }
    }
}