using System;
using System.Threading;

namespace flows2
{
    internal class Program
    {
        private static void Main(string[] args)
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
                    case "start": start(executor); break;
                    case "clear": executor.Clear(); break;
                    case "Amout": Console.WriteLine("Количество задач в очереди " + executor.Amount.ToString()); break;
                    case "stop": executor.Stop(); break;
                    case "add_actions": threading(10, executor, 1); threading(20, executor, 2); break;
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

        private static void threading(int n, Executor executor, int k)
        {
            if (executor == null)
            {
                throw new ArgumentNullException("Object is null", nameof(executor));
            }
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

        private static void start(Executor executor)
        {
            if (executor == null)
            {
                throw new ArgumentNullException("Object is null", nameof(executor));
            }
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