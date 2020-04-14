using System;

namespace Equarls_Gethashcode
{
    class Program
    {
        static void Main(string[] args)
        {

           Person p1 = new Person {Fio = "f1", Date =DateTime.Today, Place_of_birt="d4", Passport_number=5 };
           Person p2 = new Person {Fio = "f1", Date = DateTime.Today, Place_of_birt = "d4"};
           Person p3 = new Person {Fio = "f2", Date = DateTime.Today, Place_of_birt = "d4", Passport_number = 6 };

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
        public string Place_of_birt { get; set; }
        public int Passport_number { get; set; }
     //   public string Place_of_work { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var pr = (Person)obj;

            return pr.Fio == Fio && pr.Date == Date && pr.Place_of_birt == Place_of_birt;
        }
        public override int GetHashCode()
        {
            return (Fio + Date.ToString() + Place_of_birt + Passport_number.ToString()).GetHashCode();
        }
}


 }
