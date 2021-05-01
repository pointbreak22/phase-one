using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Flows
{
    internal class Program
    {
        private static readonly EventWaitHandle EventWait = new EventWaitHandle(false, EventResetMode.AutoReset); //обьявление синхронизации

        private static void AverageParallel(IReadOnlyList<double> mas, Stopwatch stopwatch, double sum = 0)
        {
            if (stopwatch == null)
            {
                throw new ArgumentException("Object is null", nameof(stopwatch));
            }

            object o = new object();
            int n = mas.Count;
            stopwatch.Restart();
            while (n >= 0)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    lock (o)
                    {
                        if (n-- > 0)
                        {
                            // ReSharper disable once AccessToModifiedClosure
                            sum += mas[n];
                        }
                        else
                        {
                            EventWait.Set();
                        }
                    }
                });
            }
            lock (o)
            {
                EventWait.WaitOne();//прерывание
            }
            sum /= mas.Count;
            stopwatch.Stop();
            Console.WriteLine("Время паралельной обработки " + mas.Count.ToString("N") + " переменных: " + stopwatch.ElapsedMilliseconds.ToString() + " млс\n Среднее:" + sum.ToString("N"));
        }

        private static void AverageSequential(IReadOnlyCollection<double> mas, Stopwatch stopwatch, double sum = 0)
        {
            if (stopwatch == null)
            {
                throw new ArgumentException("Object is null", nameof(stopwatch));
            }
            stopwatch.Restart();
            sum += mas.Sum();
            sum /= mas.Count;
            stopwatch.Stop();
            Console.WriteLine("Время последовательной обработки " + mas.Count.ToString("N") + " переменных: " + stopwatch.ElapsedMilliseconds.ToString() + " млс\n Среднее:" + sum.ToString());
        }

        private static void Main()
        {
            Random random = new Random();
            double[] mas1 = new double[10000000];
            double[] mas2 = new double[100000000];
            const int sum = 0;
            Stopwatch stopwatch = new Stopwatch();  //создание тикомера
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = random.Next(100);
            }
            AverageParallel(mas1, stopwatch, sum);
            AverageSequential(mas1, stopwatch, sum);
            for (int i = 0; i < mas2.Length; i++)
            {
                mas2[i] = random.Next(100);
            }
            AverageParallel(mas2, stopwatch, sum);
            AverageSequential(mas2, stopwatch, sum);
            Console.ReadLine();
        }
    }
}