using System;
using System.Threading;

namespace Flows2
{
    public interface IJobExecutor
    {
        ///<summary>
        /// Кол-во задач в очереди на обработку
        /// </summary>
        public int Amount { get; }

        ///<summary>
        /// Запустить обработку очереди и установить максимальное кол-во  параллельных задач
        /// </summary>
        public void Start(int maxConcurrent);

        /// Остановить обработку очереди и выполнять задачи
        public void Stop();

        /// Добавить задачу в очередь
        public void Add(Action action);

        /// Очистить очередь задач
        public void Clear();
    }
}