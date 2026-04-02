namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The no ");
            int num = Convert.ToInt32(Console.ReadLine());

            int count = (int)Math.Log10(num)+1;
            if(count == 3)
            {
                 num /= 10;
                num %= 10;
                if (num % 3 == 0)
                {
                    Console.WriteLine("Trendy Number");
                    
                }
                else
                    Console.WriteLine("Not a trendy number");

            }
            else 
            {
                Console.WriteLine("Not a trendy number");
            }
        }
    }
}
