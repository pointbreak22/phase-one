using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;

namespace Events
{
    public class Program
    {
        public delegate void StopWhile(string str);

        public static event StopWhile Stopping;

        private static void Main()
        {
            // первое задание
            Notify();
            //второе задание
            Stopping += EventStop;
            ConcurrentQueue<MyObject> myObjects = new ConcurrentQueue<MyObject>();
            Console.WriteLine("Введите предел очереди (число n)");
            int n = Convert.ToInt32(Console.ReadLine());
            AddQueue(myObjects, Stopping, n);
            RemoveQueue(myObjects, Stopping);
            Stopping -= EventStop;
            //третье задание
            NumberStreamAnalysis Stream = new NumberStreamAnalysis();
            Stream.MethodStream();
            Console.ReadLine();
        }

        public static void Notify()
        {
            NotifyProperty notifyProperty = new NotifyProperty();
            notifyProperty.PropertyChanged += DisplayMessage;
            notifyProperty.NotifyPropertyChanged("Hello Word!! (сообщение от INotifyPropertyChanged) \n");
            notifyProperty.PropertyChanged -= DisplayMessage;
        }

        public static void DisplayMessage(object sender, PropertyChangedEventArgs e) //"обработчик а  "
        {
            Console.WriteLine(e.PropertyName);
        }

        public static void AddQueue(ConcurrentQueue<MyObject> myObjects, StopWhile stopping, int n)
        {
            if (stopping == null)
            {
                throw new ArgumentNullException(nameof(stopping), "Property cannot be null or empty" + nameof(stopping) + " is null");
            }
            int count = 0;
            while (true) // цикл для добавления
            {
                myObjects.Enqueue(new MyObject() { Info = "Объект" + count.ToString() }); //добавление обьекта в очередь
                if (count + 1 >= n)
                {
                    stopping?.Invoke("Событие активировалось через " + myObjects.Count + " добавлении обьектов в очередь \n"); //вызов событмия с прерыванием цикла
                    break;
                }
                count++;
            }
        }

        public static void RemoveQueue(ConcurrentQueue<MyObject> myObjects, StopWhile stopping)
        {
            if (stopping == null)
            {
                throw new ArgumentNullException(nameof(stopping), "Property cannot be null or empty" + nameof(stopping) + " is null");
            }
            if (myObjects.Count == 0)
            {
                throw new ArgumentException("Queue<MyObject>.Count=0", nameof(myObjects));
            }
            while (myObjects.Count > 0) // цикл для очищения
            {
                myObjects.TryDequeue(out MyObject myObject);
                Console.WriteLine("Удален " + myObject.Info);
                if (myObjects.Count == 0)
                {
                    stopping?.Invoke("Событие-Обьекты удалены из очереди \n"); //вызов событмия с прерыванием цикла
                }
            }
        }

        private static void EventStop(string str)
        {
            Console.WriteLine(str);
        }
    }
}