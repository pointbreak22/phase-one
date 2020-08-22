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
                    case "start":start(executor);  break;
                    case "clear": executor.Clear(); break;
                    case "Amout": Console.WriteLine("Количество задач в очереди " + executor.Amount.ToString()); break;
                    case "stop": executor.Stop(); break;
                    case "add_actions":  threading(10, executor, 1); threading(20, executor, 2); break;              
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

        static void threading(int n, Executor executor, int k)
        {
            Thread thread = new Thread(_ =>
            {
                for (int i = 0; i < n; i++)
                {
                    Action action1 = () =>
                    {
                        Console.WriteLine("Задача потока id=" + k.ToString() + " началась");
                        Thread.Sleep(100);
                        Console.WriteLine("Задача потока id=" + k.ToString() + " завершилась");
                    };
                    executor.Add(action1);
                }
            });
            thread.Start();

        }
        static void start(Executor executor)
        {
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

        }
    }
}
