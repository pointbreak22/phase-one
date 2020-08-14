using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    public class Treugolnik : Figure, Iploshadtreugolnika
    {
        public void Str(double a, double h)
        {
            Console.WriteLine("Площадь треугольника =" + ((a * h) / 2.0).ToString());
        }
    }
}
