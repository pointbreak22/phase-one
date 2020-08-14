﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flows2
{
    public class Executor : IJobExecutor
    {
        private Queue<Action> _QueueActions = new Queue<Action>(); //очередь потоков     
        private Semaphore _semaphore;
        private Task _task;
        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private CancellationToken _token;
        private ManualResetEvent _me = new ManualResetEvent(false);   //прерывание
        public void Start(int maxConcurrent)
        {
            _semaphore = new Semaphore(maxConcurrent, maxConcurrent);    //установка лимита потоков  
            _cancellationToken.Cancel();
            _me.Set(); //игнор остановки
            _task = new Task(method);
            _task.Start();
        }
        public void method()
        {
            Console.WriteLine("//Поток для обработки очереди включен//");
            _cancellationToken = new CancellationTokenSource();
            _token = _cancellationToken.Token;
            while (true) //цикл для ожидания задач пока токен активный
            {
                if (_token.IsCancellationRequested)
                {
                    Console.WriteLine("//поток обработки очереди остановлен //");
                    break;
                }
                if (_QueueActions.Count > 0)
                {
                    Task.Factory.StartNew(() =>
                    {
                        _semaphore.WaitOne();
                        if (_QueueActions.Count > 0)
                        {
                            _QueueActions.Dequeue()?.Invoke();
                        }
                        _semaphore.Release();
                    });
                }
                else
                {
                    Console.WriteLine("//Задачи отсутствуют//");
                    _me.Reset();  //сбрасывание прерывания
                    _me.WaitOne();//остановка

                }
            }
        }
        public int Amount { get { return _QueueActions.Count; } }
        public void Stop()
        {
            _cancellationToken.Cancel();
            _me.Set();
            Console.WriteLine("//Остановка потока обработки очереди//");
        }
        public void Add(Action action)
        {
            _QueueActions.Enqueue(action); //добавление в очередь
            Console.WriteLine("Добавлена в очерередь задача №" + _QueueActions.Count);
            _me.Set();
        }
        public void Clear()
        {
            _QueueActions.Clear(); //очистка
            Console.WriteLine("Текущие адачи очищены");
        }
    }
}