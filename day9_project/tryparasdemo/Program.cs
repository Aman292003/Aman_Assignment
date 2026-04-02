namespace tryparasdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //tryparse();
            Console.WriteLine("Enter product price");
            decimal input = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"The price after tax is {input + (input * 0.18m)}");
            Console.ReadLine();
        }

        private static void tryparse()
        {
            Console.WriteLine("Enter product price");
            string input = Console.ReadLine();
            bool isvalid = decimal.TryParse(input, out decimal result);
            if (isvalid)
            {
                Console.WriteLine($"The price after tax is {result + (result * 0.18m)}");
            }
            else
            {
                Console.WriteLine("Invalid price");
            }
        }
    }
}
