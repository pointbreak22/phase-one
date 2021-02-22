using System;
using System.Threading;
using System.Threading.Tasks;

namespace flows2
{
    internal class Program
    {
        private static void Main()
        {
            CancellationTokenSource cancelToken = new CancellationTokenSource();
            CancellationToken token = cancelToken.Token;
            Executor executor = new Executor();
            string str;
            Console.WriteLine("Ввдедите \"start\" чтоб запустить обработку очереди, \"add_actions\" для добавления задач , \"clear\" очистить текущую очередь, \"Amout\" количество задач в очереди, \"stop\" остановить обработку,  \"exit\" выйти  ");
            while (true)
            {
                str = Console.ReadLine();
                switch (str)
                {
                    case "start": Start(executor); break;
                    case "clear": executor.Clear(); break;
                    case "Amout": Console.WriteLine("Количество задач в очереди " + executor.Amount.ToString()); break;
                    case "stop": executor.Stop(); break;
                    case "add_actions": Threading(10, executor, 1, token); Threading(20, executor, 2, token); break;
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

        private static async void Threading(int n, Executor executor, int k, CancellationToken token)
        {
            if (executor == null)
            {
                throw new ArgumentNullException("Object is null", nameof(executor));
            }
            await Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    void action1()
                    {
                        for (int i = 1; i <= 1000; i++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Задача прервана токеном");
                                return;
                            }

                            Console.WriteLine($"Завершена задача {Task.CurrentId}");
                            Thread.Sleep(10);
                        }
                    }
                    executor.Add(action1);
                }
            });
        }

        private static void Start(Executor executor)
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