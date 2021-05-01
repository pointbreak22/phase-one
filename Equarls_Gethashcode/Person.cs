using System;

namespace EqualsGetHashCode
{
    public class Person
    {
        public string Fio { get; set; }
        public DateTime Date { get; set; }
        public string PlaceOfBirth { get; set; }
        public int PassportNumber { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Person person))
            {
                return false;
            }

            return person.Fio == Fio && person.Date == Date && person.PlaceOfBirth == PlaceOfBirth;
        }

        public override int GetHashCode()
        {
            return (Fio + Date + PlaceOfBirth + PassportNumber).GetHashCode();
        }
    }
}