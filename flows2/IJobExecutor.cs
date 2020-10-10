using System;

namespace flows2
{
    public interface IJobExecutor
    {
        /// Кол-во задач в очереди на обработку
        public int Amount { get; }

        /// Запустить обработку очереди и установить максимальное кол-во  параллельных задач
        public void Start(int maxConcurrent);

        /// Остановить обработку очереди и выполнять задачи
        public void Stop();

        /// Добавить задачу в очередь
        public void Add(Action action);

        /// Очистить очередь задач
        public void Clear();
    }
}