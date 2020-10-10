using System;

namespace IComparableInterfase
{
    internal class Program
    {
        private static void Main()
        {
            Random random = new Random();
            Treugolnik[] tr = new Treugolnik[10];
            Console.WriteLine("Генерация");
            for (int i = 0; i < tr.Length; i++)
            {
                tr[i] = new Treugolnik { Katet1 = random.Next(100), Katet2 = random.Next(100), Gipotenuza = random.Next(100) };
                Console.WriteLine("Треугольник с сторонами: Катет1=" + tr[i].Katet1 + "  Катет2=" + tr[i].Katet2 + "  Гипоьенуза=" + tr[i].Gipotenuza);
            }
            Console.WriteLine("Сортировка по гипотенузе");
            Array.Sort(tr);
            foreach (Treugolnik t in tr)
            {
                Console.WriteLine("Треугольник с сторонами: Катет1=" + t.Katet1 + "  Катет2=" + t.Katet2 + "  Гипоьенуза=" + t.Gipotenuza);
            }
            Console.WriteLine("Сортировка по площади");
            Array.Sort(tr, new TreugolnikComparer());
            foreach (Treugolnik t in tr)
            {
                Console.WriteLine("Треугольник с сторонами: Катет1=" + t.Katet1 + "  Катет2=" + t.Katet2 + "  Гипоьенуза=" + t.Gipotenuza + "  Площадь=" + t.Katet1 * t.Katet2 / 2);
            }
            Console.ReadLine();
        }
    }
}