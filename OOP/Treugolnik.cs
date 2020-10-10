using System;

namespace OOP
{
    public class Treugolnik : Figure, IPloshadtreugolnika
    {
        public void Str(double a, double h)
        {
            Console.WriteLine("Площадь треугольника =" + ((a * h) / 2.0).ToString());
        }
    }
}