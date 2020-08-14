using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace flows2
{   
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
