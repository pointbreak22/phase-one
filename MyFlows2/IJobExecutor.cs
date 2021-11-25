using System;

namespace MyFlows2
{
    public interface IJobExecutor
    {
        /// <summary>
        ///     Кол-во задач в очереди на обработку
        /// </summary>
        public int Amount { get; }

        /// <summary>
        ///     Запустить обработку очереди и установить максимальное кол-во  параллельных задач
        /// </summary>
        public void Start(int maxConcurrent);

        /// <summary>
        ///     Остановить обработку очереди и выполнять задачи
        /// </summary>
        public void Stop();

        /// <summary>
        ///     Добавить задачу в очередь
        /// </summary>
        public void Add(Action action);

        /// <summary>
        ///     Очистить очередь задач
        /// </summary>
        public void Clear();
    }
}