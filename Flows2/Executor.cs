using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Flows2
{
    internal class Executor : IJobExecutor              //Наследник
    {
        private Semaphore _sem;
        private int _flagStart = 0;
        private readonly Mutex _mutexObj = new Mutex();
        private ConcurrentQueue<Action> _concurrentQueueActions = new ConcurrentQueue<Action>();
        private ConcurrentQueue<Action> _concurrentQueueActions2 = new ConcurrentQueue<Action>();

        public int Amount { get { return _concurrentQueueActions.Count; } }

        public void Add(Action action)
        {
            if (_flagStart == 0)      //если старт не активен то задачи добавляются в основную очередь
            {
                _concurrentQueueActions.Enqueue(action);
                Console.WriteLine($"Добавлнена задача в ооновную очередь");
            }
            else
            {
                _concurrentQueueActions2.Enqueue(action);    //иначе добавляются в дополнительную очередь
                Console.WriteLine($"Добавлена задача в ожидании");
            }
        }

        private async Task TaskAsync()
        {
            _sem.WaitOne();
            if (_concurrentQueueActions.IsEmpty)
            {
                return;
            }

            await Task.Run(() =>
            {
                _mutexObj.WaitOne();
                _concurrentQueueActions.TryDequeue(out Action action); //общий ресурс
                _mutexObj.ReleaseMutex();
                action?.Invoke();
            });

            _sem.Release();
        }

        public async void RunAsync(CancellationToken token)
        {
            await Task.Run(() =>
            {
                while (_concurrentQueueActions.Count > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Очередь прервана токеном");
                        return;
                    }

                    TaskAsync(); //метод где извлекается задача из очереди и выполняется
                }
            }, token);

            //выполняется после того как обработается основная очередь
            _flagStart = 0;
            _concurrentQueueActions = _concurrentQueueActions2;  //после окончания очереди добовляются задачи из ожидания
            _concurrentQueueActions2.Clear();  //очищается дополнительная очередь
        }

        public void Start(int maxConcurrent, CancellationToken token)
        {
            if (maxConcurrent < 1)
            {
                throw new Exception("Количество паралельных задач не может быть меньше единицы");
            }

            if (_flagStart == 0)
            {
                _flagStart = 1;
                _sem = new Semaphore(maxConcurrent, maxConcurrent);
                RunAsync(token);
            }
            else
            {
                Console.WriteLine("Подождите пока выполнятся задачи");
            }
        }

        public void Stop(CancellationTokenSource cancelToken)
        {
            cancelToken.Cancel();
            Console.WriteLine("Потоки становленны");
        }

        public void Clear(CancellationTokenSource cancelToken)
        {
            cancelToken.Cancel();
            _concurrentQueueActions2.Clear();
            _concurrentQueueActions.Clear();
            Console.WriteLine("Задачи очищены");
        }
    }
}