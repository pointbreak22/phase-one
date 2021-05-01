using System;

namespace OOP
{
    public class Circle : Figure, IAreaOfCircle
    {
        public void SAreaOfCircle(double r)
        {
            Console.WriteLine("Площадь круга =" + (Math.PI * Math.Pow(r, 2)).ToString("N"));
        }
    }
}