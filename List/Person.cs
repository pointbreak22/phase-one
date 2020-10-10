using System;

namespace List
{
    internal class Person
    {
        public string Fio { get; set; }
        public DateTime Date { get; set; }
        public string PlaceOfBirt { get; set; }
        public int PassportNumber { get; set; }
        public string PlaceOfWork { get; set; }

        public override bool Equals(object obj) //сравнение по параметрам
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var pr = (Person)obj;
            return pr.Fio == Fio && pr.Date == Date && pr.PlaceOfBirt == PlaceOfBirt && pr.PassportNumber == PassportNumber;
        }
    }
}