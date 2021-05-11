using System;
using System.Threading;
using System.Threading.Tasks;

namespace Flows2
{
    internal class Program
    {
        private static void Main()
        {
            CancellationTokenSource cancelToken = new CancellationTokenSource();
            CancellationToken token = cancelToken.Token;
            Executor executor = new Executor();
            for (int i = 1; i <= 20; i++)
            {
                void Action1()
                {
                    Console.WriteLine($"Работает задача{Task.CurrentId}");
                    for (int i = 1; i <= 100; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine($"Задача {Task.CurrentId} прервана токеном");
                            return;
                        }
                        Thread.Sleep(10);
                    }
                    Console.WriteLine($"Задача  {Task.CurrentId} завершена");
                }
                executor.Add(Action1);
            }
            Console.WriteLine($"Загружено количество задач {executor.Amount} ");
            Console.WriteLine($"Нажмите на любую клавишу чтоб активировать метод Start() ");
            Console.ReadLine();
            executor.Start(3, token);
            Console.WriteLine($"Нажмите на любую клавишу чтоб остановить задачи ");
            Console.ReadLine();
            executor.Stop(cancelToken);
            Console.WriteLine($"Осталось количество задач {executor.Amount} ");
            Console.WriteLine($"Нажмите на любую клавишу чтоб очистить задачи ");
            Console.ReadLine();
            executor.Clear(cancelToken);
            Console.WriteLine($"Осталось количество задач {executor.Amount} ");
            Console.ReadLine();
        }
    }
}