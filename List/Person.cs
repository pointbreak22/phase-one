using System;

namespace List
{
    internal class Person
    {
        public string Fio { get; set; }
        public DateTime Date { get; set; }
        public string PlaceOfBirth { get; set; }
        public int PassportNumber { get; set; }
        public string PlaceOfWork { get; set; }

        public override bool Equals(object obj) //сравнение по параметрам
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Person)obj);
        }

        protected bool Equals(Person other)
        {
            return Fio == other.Fio && Date.Equals(other.Date) && PlaceOfBirth == other.PlaceOfBirth && PassportNumber == other.PassportNumber && PlaceOfWork == other.PlaceOfWork;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Fio, Date, PlaceOfBirth, PassportNumber, PlaceOfWork);
        }
    }
}