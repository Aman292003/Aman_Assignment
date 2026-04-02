namespace generic_method
{
    internal class Program
    {
        //public static void swap(ref DateTime x, ref DateTime y)
        //{
        //    DateTime temp = x;
        //    x = y;
        //    y = temp;
        //}
        //public static void swap(string a, string b)
        //{
        //    string temp = a;
        //    a = b;
        //    b = temp;

        //} 
        static void Main(string[] args)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Now.AddDays(4);
            Console.WriteLine($"Before Swap: d1 = {d1}, d2 = {d2}");
            Helper.swap(ref d1, ref d2);
            Console.WriteLine($"After Swap: d1 = {d1}, d2 = {d2}");
            Double x = 12.5;
            Double y = 15.5;
            Console.WriteLine($"The sum is of {x} and {y} is {helper2<double>.ADD(x, y)}");
        }
    }
}
