using System;

namespace OOP
{
    public class SquareQuadratic : Figure, ISquareArea // класс для реальзации вычислении связанные с квадратом
    {
        public void SSquareArea(double a, double b)
        {
            if (a.Equals(b))
                Console.WriteLine("Площадь квадрата =" + (a * b).ToString("N"));
            else
                Console.WriteLine("Данная фигура не квадрат");
        }
    }
}