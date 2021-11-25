using System;

namespace IComparableInterface
{
    internal class Program
    {
        private static void Main()
        {
            var random = new Random();
            var tr = new Triangle[10];
            Console.WriteLine("Генерация");
            for (var i = 0; i < tr.Length; i++)
            {
                tr[i] = new Triangle {Leg1 = random.Next(100), Leg2 = random.Next(100), Hypotenuse = random.Next(100)};
                Console.WriteLine("Треугольник с сторонами: Катет1=" + tr[i].Leg1 + "  Катет2=" + tr[i].Leg2 +
                                  "  Гипоьенуза=" + tr[i].Hypotenuse);
            }

            Console.WriteLine("Сортировка по гипотенузе");
            Array.Sort(tr);
            foreach (var t in tr)
                Console.WriteLine("Треугольник с сторонами: Катет1=" + t.Leg1 + "  Катет2=" + t.Leg2 + "  Гипоьенуза=" +
                                  t.Hypotenuse);
            Console.WriteLine("Сортировка по площади");
            Array.Sort(tr, new TriangleComparer());
            foreach (var t in tr)
                Console.WriteLine("Треугольник с сторонами: Катет1=" + t.Leg1 + "  Катет2=" + t.Leg2 + "  Гипоьенуза=" +
                                  t.Hypotenuse + "  Площадь=" + t.Leg1 * t.Leg2 / 2);
            Console.ReadLine();
        }
    }
}