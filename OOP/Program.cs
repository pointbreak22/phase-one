using System;

namespace OOP
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберете фигуру:1-квадрат,2-прямоугольник,3-круг,4-треугольник....при выходе введите 0");
                    int vibor = Convert.ToInt32(Console.ReadLine());
                    if (vibor == 0)
                    {
                        break;
                    }
                    switch (vibor)
                    {
                        case 1:
                            Kvadrat kvadrat = new Kvadrat(); // подключение к классу "квадрат"
                            Console.WriteLine("Введите длину первой стороны:"); kvadrat.Storona1 = Convert.ToDouble(Console.ReadLine()); //ввод данных связанные с ним
                            Console.WriteLine("Введите длину второй стороны:"); kvadrat.Storona2 = Convert.ToDouble(Console.ReadLine());
                            kvadrat.Skv(kvadrat.Storona1, kvadrat.Storona2); //обращение к методу в квадрате для нахождения площади
                            break;

                        case 2:
                            Pryamougolnik pryamougolnik = new Pryamougolnik();
                            Console.WriteLine("Введите длину первой стороны:"); pryamougolnik.Storona1 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите длину второй стороны:"); pryamougolnik.Storona2 = Convert.ToDouble(Console.ReadLine());
                            pryamougolnik.Spr(pryamougolnik.Storona1, pryamougolnik.Storona2);
                            break;

                        case 3:
                            Krug krug = new Krug();
                            Console.WriteLine("Введите длину радиуса:"); krug.Radius = Convert.ToDouble(Console.ReadLine());
                            krug.Skr(krug.Radius);
                            break;

                        case 4:
                            Treugolnik treugolnik = new Treugolnik();
                            Console.WriteLine("Введите длину основания:"); treugolnik.Storona1 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите длину высоты:"); treugolnik.Visota = Convert.ToDouble(Console.ReadLine());
                            treugolnik.Str(treugolnik.Storona1, treugolnik.Visota);
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
        }
    }
}