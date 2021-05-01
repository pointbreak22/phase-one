using System;
using System.Threading;

namespace flows2
{
    public interface IJobExecutor
    {
        ///<summary>
        /// Кол-во задач в очереди на обработку
        /// </summary>
        public int Amount { get; }

        /// Запустить обработку очереди и установить максимальное кол-во  параллельных задач
        public void Start(int maxConcurrent, CancellationToken token);

        /// Остановить обработку очереди и выполнять задачи
        public void Stop(CancellationTokenSource cancelToken);

        /// Добавить задачу в очередь
        public void Add(Action action);

        /// Очистить очередь задач
        public void Clear(CancellationTokenSource cancelToken);
    }
}