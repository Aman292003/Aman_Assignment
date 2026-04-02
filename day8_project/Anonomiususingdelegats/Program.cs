namespace Anonomiususingdelegats
{
    internal class Program
    {
        public delegate void mydelegate1(int x, int y);
        public delegate int  mydelegate2(int x, int y);
        static void Main(string[] args)
        {
            mydelegate1 m1 = delegate (int x, int y)
            {
                Console.WriteLine(x + y);
            };
            m1+= delegate (int x, int y)
            {
                Console.WriteLine(x / y);
            };
            m1(12, 7);
            mydelegate2 m2 = delegate (int x, int y)
            {
                return x - y;

            };
            m2+= delegate (int x, int y)
            {
                return x * y;
            };
            Console.WriteLine(m2.Invoke(10, 5));
        }
    }
}
