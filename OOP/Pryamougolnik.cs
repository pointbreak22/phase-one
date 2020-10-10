using System;

namespace OOP
{
    public class Pryamougolnik : Figure, IPloshadpryamougolnika
    {
        public void Spr(double a, double b)
        {
            Console.WriteLine("Площадь прямоугольника =" + (a * b).ToString());
        }
    }
}