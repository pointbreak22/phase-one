﻿using System;
using System.Diagnostics;

namespace PackagingAndUnpacking
{
    internal class Program
    {
        private static void Main()
        {
            int n = 0;
            object o = new object();
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i = 0; i < 100; i++)
            {
                o = n; //упаковка
            }
            st.Stop();
            string time1 = st.ElapsedTicks.ToString();
            st.Restart();
            for (int i = 0; i < 100; i++)
            {
                n = (int)o;//расспаковка.
            }
            st.Stop();
            string time2 = st.ElapsedTicks.ToString();
            Console.WriteLine("Время упаковки в тиках:" + time1 + " Время расспаковки:" + time2);
            Console.ReadLine();
        }
    }
}