using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MyFlows2
{
    internal class Program
    {
        private static void Main()
        {
            var executor = new Executor
            {
                TaskQueue = new ConcurrentQueue<Task>(),
                CancellationTokenSource = new CancellationTokenSource()
            };
            ThreadPool.QueueUserWorkItem(_ =>
            {
                while (true)
                    if (executor.TaskQueue.Count < 50)
                        executor.Add(() =>
                        {
                            Console.WriteLine("the task has started");
                            Thread.Sleep(1000);
                            Console.WriteLine("the task has stopped");
                        });
            });
            ThreadPool.QueueUserWorkItem(_ => { executor.Start(10); });
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