using System;
using System.Threading;
using System.Threading.Tasks;

namespace test_cancel
{

    public class Token
    {

        public static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        public  static CancellationToken token = cancelTokenSource.Token;
        public static string s = "";

    }
    class Program
    {
        static void Main(string[] args)
        {
            Token token = new Token();
            Action action2 = Factorial;
            Action action1 = ()=> { Factorial(); };

            Task task1 = new Task(action1);
            task1.Start();

            Console.WriteLine("Введите Y для отмены операции или любой другой символ для ее продолжения:");
            Token.s = Console.ReadLine();
            //if (s == "Y")
            //   Token.cancelTokenSource.Cancel();

           task1.Wait();
            Console.WriteLine("Поток скончался");

            Console.ReadLine();
        }
        static void Factorial()
        {
            Console.WriteLine("Вошел");
            int k = 0;
            while (k<7)
            {
                Console.WriteLine("Работает");
                Thread.Sleep(1000);
                if (Token.s=="Y")
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }
                k++;

                
            }
            Console.WriteLine("Вышел");



        }
    }
}
