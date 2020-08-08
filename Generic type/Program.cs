using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericType
{   
    class UniqueCollection<T> : ICollection<T>
    {
        ICollection<T> items;
        public UniqueCollection()
        {
            // Default to using a List<T>.
            items = new List<T>();
        }
        protected UniqueCollection(ICollection<T> collection)
        {
            // Let derived classes specify the exact type of ICollection<T> to wrap.
            items = collection;
        }
        public int Count => items.Count;
        public bool IsReadOnly => false;
        public void Add(T item) //добавление
        {
            try
            {
                if (items.Contains(item))
                {
                    throw new Exception("Итем: " + item.ToString() + " повторяется");
                }
                else items.Add(item);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString()); }
        }
        public void Clear()
        {
            items.Clear();
        }
        public bool Contains(T item)
        {
            return items.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public bool Remove(T item)
        {
            return items.Remove(item);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
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
