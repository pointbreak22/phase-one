using System;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace Events
{
    public static class Program
    {
        public delegate void StopWhile(string str);

        public static event StopWhile Stopping;

        private static void Main()
        {
            // первое задание
            Notify();
            //второе задание
            Stopping += EventStop;
            var myObjects = new ConcurrentQueue<MyObject>();
            Console.WriteLine("Введите предел очереди (число n)");
            var n = Convert.ToInt32(Console.ReadLine());
            AddQueue(myObjects, Stopping, n);
            RemoveQueue(myObjects, Stopping);
            Stopping -= EventStop;
            //третье задание
            var stream = new NumberStreamAnalysis();
            stream.MethodStream();
            Console.ReadLine();
        }

        private static void Notify()
        {
            var notifyProperty = new NotifyProperty();
            notifyProperty.PropertyChanged += DisplayMessage;
            notifyProperty.NotifyPropertyChanged("Hello Word!! (сообщение от INotifyPropertyChanged) \n");
            notifyProperty.PropertyChanged -= DisplayMessage;
        }

        private static void DisplayMessage(object sender, PropertyChangedEventArgs e) //"обработчик а  "
        {
            Console.WriteLine(e.PropertyName);
        }

        private static void AddQueue(ConcurrentQueue<MyObject> myObjects, StopWhile stopping, int n)
        {
            if (stopping == null)
                throw new ArgumentNullException(nameof(stopping),
                    "Property cannot be null or empty" + nameof(stopping) + " is null");
            var count = 0;
            while (true) // цикл для добавления
            {
                myObjects.Enqueue(new MyObject {Info = "Объект" + count}); //добавление обьекта в очередь
                if (count + 1 >= n)
                {
                    stopping?.Invoke("Событие активировалось через " + myObjects.Count +
                                     " добавлении обьектов в очередь \n"); //вызов событмия с прерыванием цикла
                    break;
                }

                count++;
            }
        }

        private static void RemoveQueue(ConcurrentQueue<MyObject> myObjects, StopWhile stopping)
        {
            if (stopping == null)
                throw new ArgumentNullException(nameof(stopping),
                    "Property cannot be null or empty" + nameof(stopping) + " is null");
            if (myObjects.Count == 0) throw new ArgumentException("Queue<MyObject>.Count=0", nameof(myObjects));
            while (myObjects.Count > 0) // цикл для очищения
            {
                myObjects.TryDequeue(out var myObject);
                if (myObject != null) Console.WriteLine("Удален " + myObject.Info);
                if (myObjects.Count == 0)
                    stopping?.Invoke("Событие-Обьекты удалены из очереди \n"); //вызов событмия с прерыванием цикла
            }
        }

        private static void EventStop(string str)
        {
            Console.WriteLine(str);
        }
    }
}