using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flows2
{
    internal class Executor : IJobExecutor              ///Наследник
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public CancellationToken Token { get { return CancellationTokenSource.Token; } set { } }
        public ConcurrentQueue<Task> TaskQueue { get; set; }
        public int Amount { get { return TaskQueue.Count(); } }

        public void Start(int maxConcurrent)
        {
            while (!Token.IsCancellationRequested)
            {
                var semaphore = new Semaphore(maxConcurrent, maxConcurrent);
                while (Amount >= maxConcurrent && !Token.IsCancellationRequested)
                {
                    semaphore.WaitOne();

                    if (TaskQueue.TryPeek(out Task task))
                    {
                        TaskQueue.TryDequeue(out task);
                        task.Start();
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
