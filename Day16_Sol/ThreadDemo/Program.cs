using System.Threading;
namespace ThreadDemo
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
            Thread t = new Thread(func1);
            ThreadStart t1 = new ThreadStart(func1);
            ThreadStart t2 = new ThreadStart(func2);
            Thread f1 = new Thread(t1);
            Thread f2 = new Thread(t2);
            f1.Priority = ThreadPriority.Lowest;
            f2.Priority = ThreadPriority.Highest;
            //f1.Start();
            f2.Start();
            t.Start();
            Console.ReadLine(); 
        }
    }
}
