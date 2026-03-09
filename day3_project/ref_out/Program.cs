
namespace ref_out
{
    internal class Program
    {
        // Method must be inside class, NOT inside Main
        public void calculator(int a, int b, out int add, out int subtract)
        {
            add = a + b;
            subtract = a - b;
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            int adds, subs;

            p.calculator(12, 5, out adds, out subs);

            Console.WriteLine($"The addition is {adds} and subtraction is {subs}");
            Console.ReadLine();
        }
    }
}