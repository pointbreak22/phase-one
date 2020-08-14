using System;
using System.Collections.Generic;
using System.Text;

namespace EquarlsGethashcode
{
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
