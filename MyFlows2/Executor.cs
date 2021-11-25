using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyFlows2
{
    internal class Executor : IJobExecutor //////Наследник
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }

        private CancellationToken Token => CancellationTokenSource.Token;

        public ConcurrentQueue<Task> TaskQueue { get; set; }
        public int Amount => TaskQueue.Count();

        public void Start(int maxConcurrent)
        {
            while (!Token.IsCancellationRequested)
            {
                var semaphore = new Semaphore(maxConcurrent, maxConcurrent);
                while (Amount >= maxConcurrent && !Token.IsCancellationRequested)
                {
                    semaphore.WaitOne();

                    if (TaskQueue.TryPeek(out var task))
                    {
                        TaskQueue.TryDequeue(out task);
                        if (task != null) task.Start();
                    }
                }
            }
        }

        public void Stop()
        {
            CancellationTokenSource.Cancel();
        }

        public void Add(Action action)
        {
            TaskQueue.Enqueue(new Task(action));
        }

        public void Clear()
        {
            TaskQueue.Clear();
        }
    }
}