namespace namedOptionalparameterdemo
{
    internal class Program
    {
        public static void showmessage(int age = 10, string name = "ram")
        {
            Console.WriteLine($"Name is {name} and age is {age}");
        }
        static void Main(string[] args)
        {
            //showmessage(name: "Alice", age: 30);
            showmessage(25, "aman");
            showmessage();


        }
    }
}
