using System;

namespace OOP
{
    public class Treugolnik : Figure, IAreaOfTriangle
    {
        public void SAreaOfTriangle(double a, double h)
        {
            Console.WriteLine("Площадь треугольника =" + (a * h / 2.0).ToString("N"));
        }
    }
}