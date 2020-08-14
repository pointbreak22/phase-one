using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Kvadrat : Figure, Iploshadkvadrata  // класс для реальзации вычислении связанные с квадратом
    {
        public void Skv(double a, double b)
        {
            if (a == b)
                Console.WriteLine("Площадь квадрата =" + (a * b).ToString());
            else Console.WriteLine("Данная фигура не квадрат");
        }
    }
}
