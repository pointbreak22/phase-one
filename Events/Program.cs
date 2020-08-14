using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Events
{
    class Program
    {
        public delegate int StopWhile(string str);
        public static event StopWhile Stoping;
        static void Main(string[] args)
        {
            // первое задание
            Test t = new Test();
            t.PropertyChanged += DisplayMessage;
            t.NotifyPropertyChanged("Hello Word!! (сообщение от INotifyPropertyChanged) \n");
            t.PropertyChanged -= DisplayMessage;

            //второе задание
            Stoping += EventStop;
            int count = 0, flagwhile = 1;
            Queue<MyObject> obj = new Queue<MyObject>();
            Console.WriteLine("Введите предел очереди (число n)");
            int n = Convert.ToInt32(Console.ReadLine());
            while (flagwhile == 1) // цикл для добавления
            {
                obj.Enqueue(new MyObject() { Info = "Объект" + count.ToString() }); //добавление обьекта в очередь   
                if (count + 1 >= n)
                {
                    if (Stoping != null)
                        flagwhile = Stoping("Событие активировалось через " + obj.Count + " добавлении обьектов в очередь \n"); //вызов событмия с прерыванием цикла
                    else Console.WriteLine("нет обработчика");
                }

                count++;
            }
            flagwhile = 1;
            while (flagwhile == 1) // цикл для очищения
            {
                MyObject my = obj.Dequeue();
                Console.WriteLine("Удален " + my.Info);
                if (obj.Count == 0)
                {
                    if (Stoping != null)
                        flagwhile = Stoping("Событие-Обьекты удалены из очереди \n"); //вызов событмия с прерыванием цикла
                    else Console.WriteLine("нет обработчика");
                }

            }
            Stoping -= EventStop;

            //третье задание
            NumberStreamAnalysis stream = new NumberStreamAnalysis();
            stream.methodstream();

            Console.ReadLine();
        }
        public static void DisplayMessage(object sender, PropertyChangedEventArgs e) //обработчик а
        {
            Console.WriteLine(e.PropertyName);
        }

        private static int EventStop(string str)
        {

            Console.WriteLine(str);
            return 0;

        }

        class Test : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string msg)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(msg));
            }

        }

        class MyObject
        {
            public string Info { get; set; }
        }
     
    }
}
