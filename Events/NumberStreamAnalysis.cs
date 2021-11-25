using System;

namespace Events
{
    internal class NumberStreamAnalysis
    {
        private readonly Random _random = new Random();
        private double _number1, _number2, _average, _deviation;

        private event StreamAnalysis Stream;

        public void MethodStream()
        {
            Stream += EventStream;
            Console.WriteLine("введите предел отклонения (x)");
            var x = Convert.ToDouble(Console.ReadLine());
            _number1 = _random.Next(100);
            Console.Write(_number1.ToString("N") + " ");
            var k = 0;
            for (var i = 0; i < 10; i++)
            {
                _number2 = _random.Next(100);
                Console.Write(_number2.ToString("N") + " ");
                _average = (_number2 + _number1) / 2; //среднее
                _deviation =
                    Math.Sqrt((Math.Pow(_average - _number1, 2) + Math.Pow(_average - _number2, 2)) /
                              2); //стандартное отклонение
                if (_deviation > x)
                    Stream?.Invoke(i + 1, _number1, _number2, _average, _deviation);
                else
                    k++;
                _number1 = _number2;
            }

            if (k == 10) Console.WriteLine("Нет аварийных отклонении");
            Stream -= EventStream;
        }

        private static void EventStream(int n, double number1, double number2, double average, double deviation)
        {
            Console.WriteLine("\n Cработало событие " + n + " - N1=" + number1.ToString("N") + "  N2=" +
                              number2.ToString("N") + "   Среднее=" + average.ToString("N") + "   Отклонение=" +
                              deviation.ToString("N"));
        }

        private delegate void StreamAnalysis(int n, double number1, double number2, double average, double deviation);
    }
}