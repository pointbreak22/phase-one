using System;

namespace ExplicitConversion
{
    public class Person2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //конструкция явного преобразования
        public static explicit operator Person2(string s)
        {
            if (s.Split(" ").Length != 2)
                throw new ArgumentException("Отсутствие имени и фамилии через пробел", nameof(s));
            return new Person2 {FirstName = s.Split(" ")[0], LastName = s.Split(" ")[1]};
        }

        public static explicit operator string(Person2 p2)
        {
            if (p2 == null) throw new ArgumentNullException(nameof(p2), "Object is null");
            return p2.FirstName + " " + p2.LastName;
        }
    }
}