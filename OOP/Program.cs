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
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 0)
                    {
                        break;
                    }
                    switch (choice)
                    {
                        case 1:
                            SquareQuadratic squareQuadratic = new SquareQuadratic(); // подключение к классу "квадрат"
                            Console.WriteLine("Введите длину первой стороны:"); squareQuadratic.SideStorefront1 = Convert.ToDouble(Console.ReadLine()); //ввод данных связанные с ним
                            Console.WriteLine("Введите длину второй стороны:"); squareQuadratic.SideStorefront2 = Convert.ToDouble(Console.ReadLine());
                            squareQuadratic.SSquareArea(squareQuadratic.SideStorefront1, squareQuadratic.SideStorefront2); //обращение к методу в квадрате для нахождения площади
                            break;

                        case 2:
                            RectangleTreugolnik rectangleTreugolnik = new RectangleTreugolnik();
                            Console.WriteLine("Введите длину первой стороны:"); rectangleTreugolnik.SideStorefront1 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите длину второй стороны:"); rectangleTreugolnik.SideStorefront2 = Convert.ToDouble(Console.ReadLine());
                            rectangleTreugolnik.SAreaOfRectangle(rectangleTreugolnik.SideStorefront1, rectangleTreugolnik.SideStorefront2);
                            break;

                        case 3:
                            Circle circle = new Circle();
                            Console.WriteLine("Введите длину радиуса:"); circle.Radius = Convert.ToDouble(Console.ReadLine());
                            circle.SAreaOfCircle(circle.Radius);
                            break;

                        case 4:
                            Treugolnik treugolnik = new Treugolnik();
                            Console.WriteLine("Введите длину основания:"); treugolnik.SideStorefront1 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите длину высоты:"); treugolnik.HeightVista = Convert.ToDouble(Console.ReadLine());
                            treugolnik.SAreaOfTriangle(treugolnik.SideStorefront1, treugolnik.HeightVista);
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
        }
    }
}