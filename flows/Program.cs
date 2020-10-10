using System;
using System.Diagnostics;
using System.Threading;

namespace flows
{
    internal class Program
    {
        private static EventWaitHandle eventWait = new EventWaitHandle(false, EventResetMode.AutoReset); //обьявление синхронизации

        private static void srpar(double[] mas, Stopwatch stopwatch, double sum = 0)
        {
            if (stopwatch == null)
            {
                throw new ArgumentException("Object is null", nameof(stopwatch));
            }

            object o = new object();
            int n = mas.Length;
            stopwatch.Restart();
            while (n >= 0)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    lock (o)
                    {
                        if (n-- > 0)
                        {
                            sum += mas[n];
                        }
                        else
                        {
                            eventWait.Set();
                        }
                    }
                });
            }
            eventWait.WaitOne();//прерывание
            sum /= mas.Length;
            stopwatch.Stop();
            Console.WriteLine("Время паралельной обработки " + mas.Length.ToString() + " переменных: " + stopwatch.ElapsedMilliseconds.ToString() + " млс\n Среднее:" + sum.ToString());
        }

        private static void srposl(double[] mas, Stopwatch stopwatch, double sum = 0)
        {
            if (stopwatch == null)
            {
                throw new ArgumentException("Object is null", nameof(stopwatch));
            }
            stopwatch.Restart();
            for (int i = 0; i < mas.Length; i++)
            {
                sum += mas[i];
            }
            sum /= mas.Length;
            stopwatch.Stop();
            Console.WriteLine("Время последовательной обработки " + mas.Length.ToString() + " переменных: " + stopwatch.ElapsedMilliseconds.ToString() + " млс\n Среднее:" + sum.ToString());
        }

        private static void Main(string[] args)
        {
            Random random = new Random();
            double[] mas1 = new double[10000000];
            double[] mas2 = new double[100000000];
            double Sum = 0;
            Stopwatch stopwatch = new Stopwatch();  //создание тикомера
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = random.Next(100);
            }
            srpar(mas1, stopwatch, Sum);
            srposl(mas1, stopwatch, Sum);
            for (int i = 0; i < mas2.Length; i++)
            {
                mas2[i] = random.Next(100);
            }
            srpar(mas2, stopwatch, Sum);
            srposl(mas2, stopwatch, Sum);
            Console.ReadLine();
        }
    }
}