using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flows2
{
    internal class Executor : IJobExecutor
    {
        private static Semaphore _sem;
        private int _flagStart = 0;
        private readonly ConcurrentQueue<Action> _ConcurrentQueueActions = new ConcurrentQueue<Action>();

        public int Amount { get { return _ConcurrentQueueActions.Count; } }

        public void Add(Action action)
        {
            _ConcurrentQueueActions.Enqueue(action);
            Console.WriteLine($"Добавлнена задача в очередь");
        }

        public void Clear(CancellationTokenSource cancelToken)
        {
            cancelToken.Cancel();
            _ConcurrentQueueActions.Clear();
            Console.WriteLine("Задачи очищены");
        }

        public async void Start(int maxConcurrent, CancellationToken token)
        {
            if (maxConcurrent < 1)
            {
                throw new Exception("Количество паралельных задач не может быть меньше единицы");
            }
            else if (_flagStart == 0)
            {
                _flagStart = 1;
                _sem = new Semaphore(maxConcurrent, maxConcurrent);
                await Task.Run(() =>
                {
                    while (_ConcurrentQueueActions.Count > 0)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Очередь прервана токеном");
                            return;
                        }

                        TaskAsync();
                    }
                });
                _flagStart = 0;
            }
            else
            {
                Console.WriteLine("Подождите пока выполнятся задачи");
            }
        }

        private async void TaskAsync()
        {
            _sem.WaitOne();
            if (!_ConcurrentQueueActions.IsEmpty)
            {
                await Task.Run(() =>
                {
                    _ConcurrentQueueActions.TryDequeue(out Action action); action();
                });
                _sem.Release();
            }
        }

        public void Stop(CancellationTokenSource cancelToken)
        {
            cancelToken.Cancel();
            Console.WriteLine("Потоки становленны");
        }
    }
}