using System;

namespace Generic_type
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Загружаем коллекцию  1, 1, 2");
            UniqueCollection<int> uncool = new UniqueCollection<int>
            {
                1,
                1,
                2
            };
            Console.WriteLine("Выводим коллекцию");
            foreach (int col in uncool)
            {
                Console.Write(col.ToString("N") + " ");
            }
            Console.ReadLine();
        }
    }
}