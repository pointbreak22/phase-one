using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Reflection.Metadata;

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
        private Queue<Action> _QueueActions = new Queue<Action>(); //очередь потоков     
        private Semaphore _semaphore;
        private Task _task;
        private CancellationTokenSource _cancellationToken =new CancellationTokenSource();
        private CancellationToken _token;
        private  ManualResetEvent _me= new ManualResetEvent(false);   //прерывание
        public void Start(int maxConcurrent)
        {
            _semaphore = new Semaphore(maxConcurrent, maxConcurrent);    //установка лимита потоков  
            _cancellationToken.Cancel();
            _me.Set(); //игнор остановки
            _task = new Task(method);      
            _task.Start();
        }    
        public void method()
        {
            Console.WriteLine("//Поток для обработки очереди включен//");
            _cancellationToken = new CancellationTokenSource();
            _token = _cancellationToken.Token;
            while (true) //цикл для ожидания задач пока токен активный
            {
                if (_token.IsCancellationRequested)
                {
                    Console.WriteLine("//поток обработки очереди остановлен //");
                    break;
                }
                if (_QueueActions.Count > 0)
                {
                    Task.Factory.StartNew(() =>
                    {
                        _semaphore.WaitOne();
                        if (_QueueActions.Count > 0)
                        {
                            _QueueActions.Dequeue()?.Invoke();
                        }
                        _semaphore.Release();
                    });
                }
                else 
                {
                    Console.WriteLine("//Задачи отсутствуют//");
                    _me.Reset();  //сбрасывание прерывания
                    _me.WaitOne();//остановка
                  
                }
            }
        }
        public int Amount { get { return _QueueActions.Count; } }
        public void Stop()
        {
            _cancellationToken.Cancel();
            _me.Set();        
            Console.WriteLine("//Остановка потока обработки очереди//");
        }
        public void Add(Action action)
        {        
            _QueueActions.Enqueue(action); //добавление в очередь
            Console.WriteLine("Добавлена в очерередь задача №" + _QueueActions.Count);
            _me.Set();             
        }
        public void Clear()
        {
            _QueueActions.Clear(); //очистка
            Console.WriteLine("Текущие адачи очищены");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            Executor executor = new Executor();
            string str;
            Console.WriteLine("Ввдедите \"start\" чтоб запустить обработку очереди, \"add_actions\" для добавления задач , \"clear\" очистить текущую очередь, \"Amout\" количество задач в очереди, \"stop\" остановить обработку,  \"exit\" выйти  ");
            while (true)
            {
                str = Console.ReadLine();
                switch (str)
                {
                    case "start":
                        Console.WriteLine("Введите количество паралельных задач");
                        string s = Console.ReadLine();
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
                    case "clear": executor.Clear(); break;
                    case "Amout": Console.WriteLine("Количество задач в очереди " + executor.Amount.ToString()); break;
                    case "stop": executor.Stop(); break;
                    case "add_actions":
                        Thread thread1 = new Thread(_ =>
                         {
                             for (int i = 0; i < 10; i++)
                             {
                                 Action action1 = () =>
                                 {
                                     Console.WriteLine("Задача из 1го потока id=" + Thread.GetCurrentProcessorId() + " началась");
                                     Thread.Sleep(100);
                                     Console.WriteLine("Задача из 1го потока id=" + Thread.GetCurrentProcessorId() + " завершилась");
                                 };
                                 executor.Add(action1);
                             }
                         });
                        thread1.Start();
                        Thread thread2 = new Thread(_ =>
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                Action action1 = () =>
                                {
                                    Console.WriteLine("Задача из 2го потока id=" + Thread.GetCurrentProcessorId() + " началась");
                                    Thread.Sleep(500);
                                    Console.WriteLine("Задача из 2го потока id=" + Thread.GetCurrentProcessorId() + " завершилась");
                                };
                                executor.Add(action1);
                            }
                        });
                        thread2.Start();
                        break;
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
