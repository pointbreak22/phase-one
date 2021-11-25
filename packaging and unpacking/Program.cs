using System;
using System.Diagnostics;

namespace packaging_and_unpacking
{
    internal class Program
    {
        private static void Main()
        {
            var n = 0;
            var o = new object();
            var st = new Stopwatch();
            st.Start();
            for (var i = 0; i < 100; i++) o = n; //упаковка
            st.Stop();
            var time1 = st.ElapsedTicks.ToString();
            st.Restart();
            for (var i = 0; i < 100; i++) n = (int) o; //расспаковка.
            st.Stop();
            var time2 = st.ElapsedTicks.ToString();
            Console.WriteLine("Время упаковки в тиках:" + time1 + " Время расспаковки:" + time2);
            Console.ReadLine();
        }
    }
}