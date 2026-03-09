namespace IF_demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ifdemo();
            if_else_ladder();

        }

        private static void ifdemo()

        {
            Console.WriteLine("if working");
            int a, b, c, d;
            int l;
            Console.WriteLine("Enter four integers:");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());
            d = Convert.ToInt32(Console.ReadLine());
            l = a;
            if (l < b)
            {
                l = b;
            }
            if (l < c)
            {
                l = c;
            }
            if (l < d)
            {
                l = d;
            }
            Console.WriteLine("The largest integer is: " + l);

        }

        private static void if_else_ladder()
        {

            Console.WriteLine("if-else-ladder working");
            int p, q, r, s;
            int m;
            Console.WriteLine("Enter four integers:");
            p = Convert.ToInt32(Console.ReadLine());
            q = Convert.ToInt32(Console.ReadLine());
            r = Convert.ToInt32(Console.ReadLine());
            s = Convert.ToInt32(Console.ReadLine());

            if (p > q && p > r && p > s)
            {
                m = p;
            }
            else if (q > p && q > r && q > s)
            {
                m = q;
            }
            else if (r > p && r > q && r > s)
            {
                m = r;
            }
            else
            {
                m = s;
            }

            Console.WriteLine("The largest integer is: " + m);
        }
    }
}
