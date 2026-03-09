namespace p5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(string.Join(",", input.Where(char.IsLetter)));
        }
    }
}
