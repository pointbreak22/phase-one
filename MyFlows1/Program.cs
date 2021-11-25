using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MyFlows1
{
    internal static class Program
    {
        private static readonly EventWaitHandle
            EventWait = new EventWaitHandle(false, EventResetMode.AutoReset); //обьявление синхронизации

        private static void AverageParallel(IReadOnlyList<double> mas, Stopwatch stopwatch, double sum = 0)
        {
            if (stopwatch == null) throw new ArgumentException("Object is null", nameof(stopwatch));

            var o = new object();
            var n = mas.Count;
            stopwatch.Restart();
            while (n >= 0)
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    lock (o)
                    {
                        if (n-- > 0)
                            // ReSharper disable once AccessToModifiedClosure
                            sum += mas[n];
                        else
                            EventWait.Set();
                    }
                });
            lock (o)
            {
                EventWait.WaitOne(); //прерывание
            }

            sum /= mas.Count;
            stopwatch.Stop();
            Console.WriteLine("Время паралельной обработки " + mas.Count.ToString("N") + " переменных: " +
                              stopwatch.ElapsedMilliseconds + " млс\n Среднее:" + sum.ToString("N"));
        }

        private static void AverageSequential(IReadOnlyCollection<double> mas, Stopwatch stopwatch, double sum = 0)
        {
            if (stopwatch == null) throw new ArgumentException("Object is null", nameof(stopwatch));
            stopwatch.Restart();
            sum += mas.Sum();
            sum /= mas.Count;
            stopwatch.Stop();
            Console.WriteLine("Время последовательной обработки " + mas.Count.ToString("N") + " переменных: " +
                              stopwatch.ElapsedMilliseconds + " млс\n Среднее:" + sum);
        }

        private static void Main()
        {
            var random = new Random();
            var mas1 = new double[10000000];
            var mas2 = new double[100000000];
            var stopwatch = new Stopwatch(); //создание тикомера
            for (var i = 0; i < mas1.Length; i++) mas1[i] = random.Next(100);
            AverageParallel(mas1, stopwatch);
            AverageSequential(mas1, stopwatch);
            for (var i = 0; i < mas2.Length; i++) mas2[i] = random.Next(100);
            AverageParallel(mas2, stopwatch);
            AverageSequential(mas2, stopwatch);
            Console.ReadLine();
        }
    }
}