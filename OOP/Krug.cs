using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Krug : Figure, Iploshadkruga
    {
        public void Skr(double r)
        {
            Console.WriteLine("Площадь круга =" + (Math.PI * Math.Pow(r, 2)).ToString());
        }
    }
}
