namespace Boxing_Unboxing
{
    public class Emp
    {
        public int age;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Object obj1, obj2;
            String str1;
            Emp e = new Emp();
            int a = 50;
            obj1 = a; // Boxing
            Console.WriteLine("Value of obj1: " + obj1);
            obj2 = 9;

            str1 = a.ToString();
            Console.WriteLine("Value of String1: " + str1);
            e.age = 12;
            Console.WriteLine($"The age is {e.age}");

            int? salary = null;
            string? name = null;

        }
    }
}
