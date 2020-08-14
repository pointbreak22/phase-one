using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    class NumberStreamAnalysis
    {
        private Random random = new Random();
        private double number1, number2, avarge, deviation;
        private delegate void Stream_analysis(int n, double number1, double number2, double average, double deviation);
        private event Stream_analysis Stream;

        public void methodstream()
        {
            Stream += EventStream;
            Console.WriteLine("введите предел отклонения (x)");
            double x = Convert.ToDouble(Console.ReadLine());
            number1 = random.Next(100);
            Console.Write(number1.ToString() + " ");
            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                number2 = random.Next(100);
                Console.Write(number2.ToString() + " ");
                avarge = (number2 + number1) / 2; //среднее

                deviation = Math.Sqrt((Math.Pow(avarge - number1, 2) + Math.Pow(avarge - number2, 2)) / 2); //стандартное отклонение
                if (deviation > x)
                {
                    Stream?.Invoke(i + 1, number1, number2, avarge, deviation);

                }
                else
                {
                    k++;
                }
                number1 = number2;
            }
            if (k == 10)
            {
                Console.WriteLine("Нет аварийных отклонении");
            }
            Stream -= EventStream;
        }
        private void EventStream(int n, double number1, double number2, double average, double deviation)
        {
            Console.WriteLine("\n Cработало событие " + n + " - N1=" + number1.ToString() + "  N2=" + number2.ToString() + "   Среднее=" + avarge.ToString() + "   Отклонение=" + deviation.ToString());

        }
    }
}
