using System.Security.Cryptography.X509Certificates;

namespace call_by_value__ref
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            Program p = new Program();
            Console.WriteLine($"Before Swap: a = {a}, b = {b}");
            p.SwapByValue(a, b);
            Console.WriteLine($"After SwapByValue: a = {a}, b = {b}");
            Console.WriteLine($"Before Swap: a = {a}, b = {b}");
            p.SwapByRef(ref a, ref b);
            Console.WriteLine($"After SwapByRef: a = {a}, b = {b}");
            Console.ReadLine();

        }
        public void SwapByValue(int a, int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        public void SwapByRef(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}
