using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic_type
{
    public class UniqueCollection<T> : ICollection<T>
    {
        private readonly ICollection<T> _items;

        public UniqueCollection()
        {
            // Default to using a List<T>.
            _items = new List<T>();
        }

        public int Count => _items.Count;
        public bool IsReadOnly => false;

        public void Add(T item) //добавление
        {
            try
            {
                if (_items.Contains(item))
                {
                    throw new Exception("Итем: " + item?.ToString() + " повторяется");
                }
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
}