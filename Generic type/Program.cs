using System;

namespace GenericType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Загружаем коллекцию  1, 1, 2");
            UniqueCollection<int> uncol = new UniqueCollection<int>();
            uncol.Add(1);
            uncol.Add(1);
            uncol.Add(2);
            Console.WriteLine("Выводим коллекцию");
            foreach (int col in uncol)
            {
                Console.Write(col.ToString() + " ");
            }
            Console.ReadLine();
        }
    }
}