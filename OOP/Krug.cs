using System;

namespace OOP
{
    public class Krug : Figure, IPloshadkruga
    {
        public void Skr(double r)
        {
            Console.WriteLine("Площадь круга =" + (Math.PI * Math.Pow(r, 2)).ToString());
        }
    }
}