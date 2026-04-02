namespace INBUILTDELEGATION
{
    internal class Program
    {
        public static void add(int a, float b, decimal k)
        {
            Console.WriteLine($"The sum is:{a + Convert.ToDecimal(b) + k}");
        }

        public static double add(int a, decimal b, double kk)
        {
            return (a + Convert.ToDouble(b) + kk);

        }

        public static bool checklength(string str)
        {
            if (str.Length > 10)
                return true;
            else
                return false;
        }
        public delegate void mydelegate1(int a, float b, decimal k);
        public delegate double mydelegate2(int a, decimal b, double kk);
        public delegate bool mydelegate3(string str);
        static void Main(string[] args)
        {
            Action<int, float, decimal> action = add;
            action(12, 45.5f, 78.9m);
            Func<int, decimal, double, double> func = add;
            double res1 = func(12, 45.5m, 78.9);
            Predicate<string> predicate = checklength;
            bool res2 = predicate("Hello World");
            //mydelegate1 d1 = add;
            //d1(12, 45.5f, 78.9m);
            //mydelegate2 d2 = add;
            //double result = d2(12, 45.5m, 78.9);
            //Console.WriteLine(result);
            //mydelegate3 d3 = checklength;
            //bool res = d3("Hello World");
            Console.WriteLine(res1);
        }
    }
}
