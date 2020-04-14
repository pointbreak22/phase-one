using System;
using System.Collections.Generic;
using System.Collections;

namespace Обобщенный_тип
{
    // type parameter T in angle brackets
    //public class GenericList<T>
    //{
    //    // The nested class is also generic on T.
    //    private class Node
    //    {
    //        // T used in non-generic constructor.
    //        public Node(T t)
    //        {
    //            next = null;
    //            data = t;
    //        }

    //        private Node next;
    //        public Node Next
    //        {
    //            get { return next; }
    //            set { next = value; }
    //        }

    //        // T as private member data type.
    //        private T data;

    //        // T as return type of property.
    //        public T Data
    //        {
    //            get { return data; }
    //            set { data = value; }
    //        }
    //    }

    //    private Node head;

    //    // constructor
    //    public GenericList()
    //    {
    //        head = null;
    //    }

    //    // T as method parameter type:
    //    public void AddHead(T t)
    //    {
    //        try
    //        {
    //            int k = 0;
    //            Node seach = head;


    //            Node n = new Node(t);
    //            n.Next = head;
    //            head = n;
    //        }
    //        catch (Exception ex){ Console.WriteLine(ex.ToString()); }

    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        Node current = head;

    //        while (current != null)
    //        {
    //            yield return current.Data;
    //            current = current.Next;
    //        }
    //    }
    //}

    class UniqueCollection<T> : ICollection<T>
    {
        ICollection<T> _items;
        public UniqueCollection()
        {
            // Default to using a List<T>.
            _items = new List<T>();
        }
        protected UniqueCollection(ICollection<T> collection)
        {
            // Let derived classes specify the exact type of ICollection<T> to wrap.
            _items = collection;
        }
        public int Count => _items.Count; 

        public bool IsReadOnly =>false;

        public void Add(T item) //добавление
        {
            try
            {
                if (_items.Contains(item))
                    throw new Exception("Итем: " + item.ToString() + " повторяется");
                 else _items.Add(item);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString()); }

        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Загружаем коллекцию  1, 1, 2");
            UniqueCollection<int> uncol= new UniqueCollection<int>();
            uncol.Add(1);
            uncol.Add(1);
            uncol.Add(2);

            Console.WriteLine("Выводим коллекцию");
            foreach (int col in uncol)
            {
                Console.Write(col.ToString()+" ");
            }
            Console.ReadLine();
        }
    }
}
