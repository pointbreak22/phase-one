using System;

namespace OOP
{
    public class Pryamougolnik : Figure, Iploshadpryamougolnika
    {
        public void Spr(double a, double b)
        {
            Console.WriteLine("Площадь прямоугольника =" + (a * b).ToString());
        }
    }
}