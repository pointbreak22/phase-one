using System;
using System.Threading.Tasks;
using System.Threading;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace Потоки_2
{
    public interface IJobExecutor
    {
        /// Кол-во задач в очереди на обработку
        int Amount { get; }

        /// Запустить обработку очереди и установить максимальное кол-во  параллельных задач
        void Start(int maxConcurrent);

        /// Остановить обработку очереди и выполнять задачи
        void Stop();

        /// Добавить задачу в очередь
        void Add(Action action);

        /// Очистить очередь задач
        void Clear();
    }
    public class Executor : IJobExecutor
    {


        private Queue<Action> Queue_Actions = new Queue<Action>(); //очередь потоков

       
        public static bool Flag_stop { get; set; } //флаг прерывания потоков
     
      

        public int Amount { get { return Queue_Actions.Count; } }
        public void Start(int maxConcurrent)
        {
            Flag_stop = false;
            
            Semaphore semaphore = new Semaphore(maxConcurrent, maxConcurrent); //установка лимита потоков
            Task.Factory.StartNew(() => //запуск потоков в отдельном потоке
            {
                while (Queue_Actions.Count > 0)
                {
                    if (Flag_stop == false)
                        ThreadPool.QueueUserWorkItem(_ =>  //запуск каждой задачи по очереди
                        {
                            semaphore.WaitOne();
                            if (Queue_Actions.Count > 0) { Queue_Actions.Dequeue().Invoke(); }
                            semaphore.Release();
                        });
                    else return;
                }
            });

        }

       

     
        public void Stop()
        {
            Flag_stop= true;
            Console.WriteLine("//Остановка потоков//");
        }
        public void Add(Action action)
        {

            Queue_Actions.Enqueue(action); //добавление в очередь
            Console.WriteLine("Добавлена в очерередь задача №" + Queue_Actions.Count);


        }

        public void Clear()
        {
            Queue_Actions.Clear(); //очистка
            Console.WriteLine("Задачи очищены");
        }

      
    }
    public class Zadachi //класс с задачами
    {
        public void Zadacha()
        {
           
            Console.WriteLine("начало работы задачи в потоке с ID " + Thread.GetCurrentProcessorId().ToString());
            for (int i = 0; i < 100; i++)
            {
            
                if (Executor.Flag_stop == true)
                {
                    Console.WriteLine("задача ID " + Thread.GetCurrentProcessorId().ToString()+" прервана");
                    return;
                }
               Thread.Sleep(50);


            }


            Console.WriteLine("конец работы задачи в потоке с ID " + Thread.GetCurrentProcessorId().ToString());
        }


    }



    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Введите к-во задачь которые хотите отправить на очередь");
            int K1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите максимальное к-во одновременно выполняющихся задачь");
            int K2 = Convert.ToInt32(Console.ReadLine());
            Executor executor = new Executor();
            Zadachi zadachi = new Zadachi();
            for (int i=0;i<K1;i++)
            executor.Add(zadachi.Zadacha); //добавление задачи в очередь
           
            executor.Start(K2); //Запуск очереди
            Console.WriteLine("-----ввдедите s для остановки потоков или продолжения других действии----");
            string str = Console.ReadLine();

            if (str=="s")
            executor.Stop(); //остановка
            Console.WriteLine("в очереди осталось " + executor.Amount.ToString()+" задача/чи");
            executor.Clear(); //очистка задач

          

            Console.WriteLine("Нажмите любую клавишу для закрытия");
            Console.ReadLine();

        }





    }
}
