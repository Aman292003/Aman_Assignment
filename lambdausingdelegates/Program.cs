namespace lambdausingdelegates
{
    class Program
    {
        //public static void add(int x, int y)
        //{
        //    Console.WriteLine($"The sum is :{x + y}");
        //}
        //public static int substract(int x, int y)
        //{
        //    return x - y;
        //}
        //public static int multiply(int x, int y)
        //{
        //    return x * y;
        //}
        //public static void divide(int x, int y)
        //{
        //    Console.WriteLine($"The division is :{x / y}");

        //}
        public delegate void mydelegate1(int a, int b);
        public delegate int mydelegate2(int a, int b);

        static void Main(string[] args)
        {
            mydelegate1 m1 = (x, y) => Console.WriteLine($"The sum is :{x + y}");
            m1 += (x, y) => Console.WriteLine($"The division is :{x / y}");
            mydelegate2 m2 = (x, y) => x - y;
            m2 += (x, y) => x * y;
            foreach (mydelegate2 mm in m2.GetInvocationList())
            {
                Console.WriteLine($"Result :{mm(50, 10)}");
            }
            Console.ReadLine();
        }
    }
}
