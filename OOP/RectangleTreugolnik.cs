using System;

namespace OOP
{
    public class RectangleTreugolnik : Figure, IAreaOfRectangle
    {
        public void SAreaOfRectangle(double a, double b)
        {
            Console.WriteLine("Площадь прямоугольника =" + (a * b).ToString("N"));
        }
    }
}