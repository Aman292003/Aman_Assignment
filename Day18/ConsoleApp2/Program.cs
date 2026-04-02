namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer:");
            int num = Convert.ToInt32(Console.ReadLine());

            string s = num.ToString();
            string result = "";

            foreach (char c in s)
            {
                if (!result.Contains(c))
                {
                    result += c;
                }
            }

            Console.WriteLine("Number after removing duplicates: " + result);
        }
    }
}
