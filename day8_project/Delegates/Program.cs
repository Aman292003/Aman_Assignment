namespace Delegates
{
    internal class Program
    {
        public static void add(int x, int y)
        {
            Console.WriteLine($"the sum of {x} and {y} is {x + y}");
        }
        public static int sub(int x, int y)
        {
           return x - y;

        }
        public static int multiply(int x, int y)
        {
            return x * y;
        }   
        public delegate void mydelegate1(int x, int y);
        public delegate int mydelegate2(int x, int y);
        static void Main(string[] args)
        {
            mydelegate1 del1 = add;
            del1(12, 54);
            mydelegate2 del2 = sub;
            Console.WriteLine($"the difference is {del2(40, 6)}");
            del2 += multiply;
            Console.WriteLine($"the product is {del2(4, 6)}");



        }
    }
}
