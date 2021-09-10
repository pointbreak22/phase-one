using System;
using System.Threading;
using System.Threading.Tasks;

namespace Flows2
{
    internal class Program
    {
        private static void Main()
        {
            Executor executor = new Executor()
            {
                TaskQueue = new System.Collections.Concurrent.ConcurrentQueue<Task>(),
                CancellationTokenSource = new CancellationTokenSource(),
            };
            executor.Token = executor.CancellationTokenSource.Token;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                while (true)
                {
                    if (executor.TaskQueue.Count < 20)
                    {
                        executor.Add(() =>
                        {
                            Console.WriteLine("the task has started");
                            Thread.Sleep(1000);
                            Console.WriteLine("the task has stopped");
                        });
                    }
                }
            });
            ThreadPool.QueueUserWorkItem(_ =>
            {
                executor.Start(10);
            });
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(1000);
                executor.Stop();
                executor.Clear();
                Console.WriteLine("Stop");
            });
            Console.ReadKey();
        }
    }
}