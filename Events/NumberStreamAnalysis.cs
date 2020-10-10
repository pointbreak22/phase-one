using System;

namespace Events
{
    internal class NumberStreamAnalysis
    {
        private readonly Random _random = new Random();
        private double _number1, _number2, _avarge, _deviation;

        private delegate void Streamanalysis(int n, double _number1, double _number2, double average, double _deviation);

        private event Streamanalysis Stream;

        public void Methodstream()
        {
            Stream += EventStream;
            Console.WriteLine("введите предел отклонения (x)");
            double x = Convert.ToDouble(Console.ReadLine());
            _number1 = _random.Next(100);
            Console.Write(_number1.ToString() + " ");
            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                _number2 = _random.Next(100);
                Console.Write(_number2.ToString() + " ");
                _avarge = (_number2 + _number1) / 2; //среднее
                _deviation = Math.Sqrt((Math.Pow(_avarge - _number1, 2) + Math.Pow(_avarge - _number2, 2)) / 2); //стандартное отклонение
                if (_deviation > x)
                {
                    Stream?.Invoke(i + 1, _number1, _number2, _avarge, _deviation);
                }
                else
                {
                    k++;
                }
                _number1 = _number2;
            }
            if (k == 10)
            {
                Console.WriteLine("Нет аварийных отклонении");
            }
            Stream -= EventStream;
        }

        private void EventStream(int n, double _number1, double _number2, double average, double _deviation)
        {
            Console.WriteLine("\n Cработало событие " + n + " - N1=" + _number1.ToString() + "  N2=" + _number2.ToString() + "   Среднее=" + _avarge.ToString() + "   Отклонение=" + _deviation.ToString());
        }
    }
}