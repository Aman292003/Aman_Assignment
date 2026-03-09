using System;

namespace Thread_Join
{
    internal class Program
    {
        public static void func1()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Function 1 - Count: {i}");
                // Thread.Sleep(500); // Simulate work
            }

        }
        public static void func2()
        {

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Function 2 - Count: {i}");
                // Thread.Sleep(700); // Simulate work
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the main program ");
            Thread firstthread = new Thread(new ThreadStart(func1));
            Thread secondthread = new Thread(new ThreadStart(func2));
            firstthread.Start();
            secondthread.Start();
            firstthread.Join();
            secondthread.Join();

            Console.WriteLine("End of main()");
        }
    }
}
