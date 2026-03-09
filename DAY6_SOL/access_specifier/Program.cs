using ClassLibrary1;

namespace access_specifier
{
    public class abcd :Class1
    {
        private int a =1;
        public int b=2;
        protected int c=3;

        public int geta()
        {
            return a;
        }

    }
    internal class Program:abcd
    {
        static void Main(string[] args)
        {
            abcd ob = new abcd();
            Program p = new Program();
            Console.WriteLine(ob.b);
            Console.WriteLine(b);
            Console.WriteLine(c);
            //Console.WriteLine(ob.geta());
            Console.WriteLine(p.x); 
        }
        
    }
}
