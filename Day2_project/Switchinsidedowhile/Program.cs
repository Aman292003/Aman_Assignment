using System.Runtime.InteropServices;

namespace Switchinsidedowhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, choice;
            
            Console.WriteLine("enter values in a ,b ..");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.WriteLine("Enter your choice..");
                Console.WriteLine("************************");
                Console.WriteLine("1.Addtion...");
                Console.WriteLine("2.Substraction...");
                Console.WriteLine("3.Multipliation...");
                Console.WriteLine("4.division...");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        c = a + b;
                        Console.WriteLine($"The sum is {c} ");
                        break;

                    case 2:
                        c = (a > b) ? (a - b) : (b - a);
                        Console.WriteLine($"The diference is {c} ");
                        break;
                    case 3:
                        c = a * b;
                        Console.WriteLine($"The product is {c} ");
                        break;
                    case 4:
                        c = a / b;
                        Console.WriteLine($"The divison is {c} ");
                        break;
                    default:
                        Console.WriteLine($"enter values in 1 to 4 ");
                        break;
                }
                Console.WriteLine("Do you want to continue");
                if (Console.ReadLine() != "y") {
                    break;
                }
            } while (true);



        }
    }
}
