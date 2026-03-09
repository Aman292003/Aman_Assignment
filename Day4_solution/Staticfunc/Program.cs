namespace Staticfunc
{

    class abcd
    {
        static int a = 1;
         static public void count()
        {
            a = a + 1;

            Console.WriteLine($"The value is {a}");
        }
        static void Main(string[] args)
        {
            abcd obj = new abcd();
            //obj.count();
            count();
            Console.ReadLine();
        }
    }
    class Program
    {

    }
}
