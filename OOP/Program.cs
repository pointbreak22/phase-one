using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберете фигуру:1-квадрат,2-прямоугольник,3-круг,4-треугольник....при выходе введите 0");
                    int vibor = Convert.ToInt32(Console.ReadLine());
                    if (vibor == 0) break;
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
public abstract class Figure // класс с хранением возможных данных о фигуре, стороны, высота, радиус, углы и тд....
{
    private double a, b, r, h;
    public double Storona1 { get { return a; } set { a = value; } } //свойства
    public double Storona2 { get { return b; } set { b = value; } }
    public double Radius { get { return r; } set { r = value; } }
    public double Visota { get { return h; } set { h = value; } }
}
public interface Iploshadkvadrata  //интерфейс с сигнатурой для нахлждения площади
{
    public void Skv(double a, double b);
}
public interface Iploshadpryamougolnika
{
    public void Spr(double a, double b);
}
public interface Iploshadkruga
{
    public void Skr(double r);
}
public interface Iploshadtreugolnika
{
    public void Str(double a, double h);
}
public class Kvadrat : Figure, Iploshadkvadrata  // класс для реальзации вычислении связанные с квадратом
{
    public void Skv(double a, double b)
    {
        if (a == b)
            Console.WriteLine("Площадь квадрата =" + (a * b).ToString());
        else Console.WriteLine("Данная фигура не квадрат");
    }
}
public class Krug : Figure, Iploshadkruga
{
    public void Skr(double r)
    {
        Console.WriteLine("Площадь круга =" + (Math.PI * Math.Pow(r, 2)).ToString());
    }
}
public class Pryamougolnik : Figure, Iploshadpryamougolnika
{
    public void Spr(double a, double b)
    {
        Console.WriteLine("Площадь прямоугольника =" + (a * b).ToString());
    }
}
public class Treugolnik : Figure, Iploshadtreugolnika
{
    public void Str(double a, double h)
    {
        Console.WriteLine("Площадь треугольника =" + ((a * h) / 2.0).ToString());
    }
}

