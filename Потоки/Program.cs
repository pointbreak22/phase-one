using System;
using System.Threading;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace Потоки
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double[] mas1 = new double[10000000];
            double[] mas2 = new double[100000000];
            double Sum1 = 0;
           var locker = new object();
            EventWaitHandle eventWait = new EventWaitHandle(false, EventResetMode.AutoReset); //обьявление синхронизации

            Stopwatch stopwatch = new Stopwatch();  //создание тикомера

            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = random.Next(100);
                //Console.Write(mas1[i]+" ");
            }
            bool acquiredLock = false;
            int n = mas1.Length;

            Console.WriteLine("10М переменных");
            stopwatch.Start();//запуск тикомера
            while (n>=0)
                ThreadPool.QueueUserWorkItem(_ => { if (n-->=0) Sum1 += mas1[n]; else eventWait.Set();  } );

            eventWait.WaitOne();//прерывание
            stopwatch.Stop(); //остановка тикомера
            Console.WriteLine("Cреднее параллельной обработки=" + (Sum1 / mas1.Length).ToString());
            Console.WriteLine("Время 1: " + stopwatch.ElapsedMilliseconds.ToString() + " млс");

            Sum1 = 0;
            stopwatch.Restart();
            for (int i = 0; i < mas1.Length; i++)
                Sum1+= mas1[i];
            stopwatch.Stop();
       
            Console.WriteLine("Cреднее последовательной обработки=" + (Sum1 / mas1.Length).ToString());
            Console.WriteLine("Время 2: " + stopwatch.ElapsedMilliseconds.ToString() + " млс");
          //  stopwatch.Reset();

            //------------------------------------------------------------------
           // eventWait.Reset();   //если мануал
            for (int i = 0; i < mas2.Length; i++)
            {
                mas2[i] = random.Next(100);
                //Console.Write(mas2[i]+" ");
            }
   
            n = mas2.Length;
            Sum1 = 0;
            Console.WriteLine("100М переменных");
            stopwatch.Restart();
            while (n != 0)
                ThreadPool.QueueUserWorkItem(_ => { if (n-- >= 0) Sum1 += mas1[n]; else eventWait.Set(); });

            eventWait.WaitOne();//прерывание
            stopwatch.Stop(); //остановка тикомера
            Console.WriteLine("Cреднее параллельной обработки=" + (Sum1 / mas1.Length).ToString());
            Console.WriteLine("Время 1: " + stopwatch.ElapsedMilliseconds.ToString() + " млс");
            eventWait.WaitOne();
            Sum1 = 0;
            if (!stopwatch.IsRunning) stopwatch.Restart();
            for (int i = 0; i < mas2.Length; i++)
                Sum1 += mas2[i];
            stopwatch.Stop();
          
            Console.WriteLine("Cреднее последовательной обработки=" + (Sum1 / mas2.Length).ToString());
            Console.WriteLine("Время 2: " + stopwatch.ElapsedMilliseconds.ToString() + " млс");

            Console.ReadLine();
        }
    }
}
