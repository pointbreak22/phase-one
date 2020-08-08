using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;


namespace flows2
{
    public interface IJobExecutor
    {
        /// Кол-во задач в очереди на обработку
         public int Amount { get; }

        /// Запустить обработку очереди и установить максимальное кол-во  параллельных задач
        public void Start(int maxConcurrent);

        /// Остановить обработку очереди и выполнять задачи
        public void Stop();

        /// Добавить задачу в очередь
        public void Add(Action action);

        /// Очистить очередь задач
        public void Clear();
    }
    public class Executor : IJobExecutor
    {
        private static Queue<Action> QueueActions = new Queue<Action>(); //очередь потоков
        private  static  CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private   CancellationToken token = cancelTokenSource.Token;     
        public int Amount { get { return QueueActions.Count; } }
        public void Start(int maxConcurrent)
        {

            Semaphore semaphore = new Semaphore(maxConcurrent, maxConcurrent); //установка лимита потоков          
            cancelTokenSource.Cancel();
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            Task.Factory.StartNew(() => //запуск отдельного потока для выполнения задач
            {             
                Console.WriteLine("//Поток для обработки очереди включен//");
                while (true) //цикл для ожидания задач пока токен активный
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("//поток обработки очереди остановлен //");                
                      
                        break;
                    }
                    if (QueueActions.Count>0)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            semaphore.WaitOne();
                            if (QueueActions.Count > 0)
                            {
                                QueueActions.Dequeue()?.Invoke();
                            }
                            semaphore.Release();
                        });
                    }                                    
                }
            });
        }                           
        public void Stop()
        {
            cancelTokenSource.Cancel();
            Console.WriteLine("//Остановка потока обработки очереди//");
        }
        public void Add(Action action)
        {
            QueueActions.Enqueue(action); //добавление в очередь
            Console.WriteLine("Добавлена в очерередь задача №" + QueueActions.Count);
        }
        public void Clear()
        {
            QueueActions.Clear(); //очистка
            Console.WriteLine("Текущие адачи очищены");
        }
    }
    public class Zadachi //класс с задачами
    {
        Executor executor = new Executor();
        public void add1()
        {
            Task.Factory.StartNew(() =>
            { 
                for (int i=0; i<10;i++)
                {
                      Action action1 = () =>
                      {
                        
                          Console.WriteLine("Задача из 1го потока id=" + Thread.GetCurrentProcessorId() + " началась");
                          Thread.Sleep(200);
                          Console.WriteLine("Задача из 1го потока id=" + Thread.GetCurrentProcessorId() + " завершилась");
                      };
                     executor.Add(action1);             
                                }
            });
        }
        public void add2()
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Action action2 = () =>
                    {                       
                        Console.WriteLine("Задача из 2го потока id=" + Thread.GetCurrentProcessorId() + " началась");
                        Thread.Sleep(1000);
                        Console.WriteLine("Задача из 2го потока id=" + Thread.GetCurrentProcessorId() + " завершилась");
                    };
                    executor.Add(action2);
                }
            });

        }
        public void add3()
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Action action3 = () =>
                    {
                    
                        Console.WriteLine("Задача из 3го потока id=" + Thread.GetCurrentProcessorId() + " началась");
                        Thread.Sleep(2000);
                        Console.WriteLine("Задача из 3го потока id=" + Thread.GetCurrentProcessorId() + " завершилась");
                    };
                    executor.Add(action3);

                }
            });

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
          
         
            Executor executor = new Executor();
            Zadachi zadachi = new Zadachi();
            string str;
            Console.WriteLine("Ввдедите \"start\" чтоб запустить обработку очереди, \"add1\" для добавления задач c первого потока, \"add2\" со второго потока,\"add3\" с третьего, \"clear\" очистить текущую очередь, \"Amout\" количество задач в очереди, \"stop\" остановить обработку,  \"exit\" выйти  ");

            while (true)
            {
                
                str = Console.ReadLine();
                switch (str)
                {
                    case "start":
                        Console.WriteLine("Введите количество паралельных задач");
                        string s =Console.ReadLine();
                        if (int.TryParse(s, out int n))
                        {
                            executor.Start(n);
                            Console.WriteLine("Запуcк обработки очереди с " + n + " паралельных задач");
                        }
                        else
                        {
                            Console.WriteLine("ввели не число, введите команду заново");
                        }
                        break;
                    case "clear": executor.Clear();break;
                    case "Amout": Console.WriteLine("Количество задач в очереди " + executor.Amount.ToString());break;
                    case "stop":executor.Stop(); break;
                    case "add1":zadachi.add1();break;
                    case "add2": zadachi.add2(); break;
                    case "add3": zadachi.add3(); break;
                    default: Console.WriteLine("Команды не существует "); break;

                }                                
                if (str == "exit")
                {
                    break;
                }
            }    
                
            Console.WriteLine("Нажмите любую клавишу для закрытия");
            Console.ReadLine();
        }
    }
}
