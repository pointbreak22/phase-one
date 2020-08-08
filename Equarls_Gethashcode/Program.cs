using System;

namespace EquarlsGethashcode
{
    class Program
    {
        static void Main(string[] args)
        {

            Person p1 = new Person { Fio = "f1", Date = DateTime.Today, Placeofbirt = "d4", PassportNumber = 5 };
            Person p2 = new Person { Fio = "f1", Date = DateTime.Today, Placeofbirt = "d4" };
            Person p3 = new Person { Fio = "f2", Date = DateTime.Today, Placeofbirt = "d4", PassportNumber = 6 };

            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.Equals(p3));
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p3.GetHashCode());
            Console.ReadLine();
        }
    }

    public class Person
    {
        public string Fio { get; set; }
        public DateTime Date { get; set; }
        public string Placeofbirt { get; set; }
        public int PassportNumber { get; set; }  


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var pr = (Person)obj;

            return pr.Fio == Fio && pr.Date == Date && pr.Placeofbirt == Placeofbirt;
        }
        public override int GetHashCode()
        {
            return (Fio + Date.ToString() + Placeofbirt + PassportNumber.ToString()).GetHashCode();
        }
    }


}
