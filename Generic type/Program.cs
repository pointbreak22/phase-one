using System;

namespace GenericType
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Загружаем коллекцию  1, 1, 2");
            UniqueCollection<int> uncol = new UniqueCollection<int>
            {
                1,
                1,
                2
            };
            Console.WriteLine("Выводим коллекцию");
            foreach (int col in uncol)
            {
                Console.Write(col.ToString() + " ");
            }
            Console.ReadLine();
        }
    }
}