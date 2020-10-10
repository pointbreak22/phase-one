using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Events
{
    public class Program
    {
        public delegate void StopWhile(string str);

        public static event StopWhile Stoping;

        private static void Main()
        {
            // первое задание
            Notify();
            //второе задание
            Stoping += EventStop;
            Queue<MyObject> obj = new Queue<MyObject>();
            Console.WriteLine("Введите предел очереди (число n)");
            int n = Convert.ToInt32(Console.ReadLine());
            AddQueue(obj, Stoping, n);
            RemoveQueue(obj, Stoping);
            Stoping -= EventStop;
            //третье задание
            NumberStreamAnalysis stream = new NumberStreamAnalysis();
            stream.Methodstream();
            Console.ReadLine();
        }

        public static void Notify()
        {
            Test t = new Test();
            t.PropertyChanged += DisplayMessage;
            t.NotifyPropertyChanged("Hello Word!! (сообщение от INotifyPropertyChanged) \n");
            t.PropertyChanged -= DisplayMessage;
        }

        public static void DisplayMessage(object sender, PropertyChangedEventArgs e) //обработчик а
        {
            Console.WriteLine(e.PropertyName);
        }

        public static void AddQueue(Queue<MyObject> obj, StopWhile Stoping, int n)
        {
            if (Stoping == null)
            {
                throw new ArgumentNullException("Property cannot be null or empty", nameof(Stoping) + " is null");
            }
            int count = 0;
            while (true) // цикл для добавления
            {
                obj.Enqueue(new MyObject() { Info = "Объект" + count.ToString() }); //добавление обьекта в очередь
                if (count + 1 >= n)
                {
                    Stoping("Событие активировалось через " + obj.Count + " добавлении обьектов в очередь \n"); //вызов событмия с прерыванием цикла
                    break;
                }
                count++;
            }
        }

        public static void RemoveQueue(Queue<MyObject> obj, StopWhile Stoping)
        {
            if (Stoping == null)
            {
                throw new ArgumentNullException("Property cannot be null or empty", nameof(Stoping) + " is null");
            }
            if (obj.Count == 0)
            {
                throw new ArgumentException("Queue<MyObject>.Count=0", nameof(obj));
            }
            while (true) // цикл для очищения
            {
                MyObject my = obj.Dequeue();
                Console.WriteLine("Удален " + my.Info);
                if (obj.Count == 0)
                {
                    Stoping("Событие-Обьекты удалены из очереди \n"); //вызов событмия с прерыванием цикла
                    break;
                }
            }
        }

        private static void EventStop(string str)
        {
            Console.WriteLine(str);
        }

        private class Test : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string msg)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(msg));
            }
        }

        public class MyObject
        {
            public string Info { get; set; }
        }
    }
}