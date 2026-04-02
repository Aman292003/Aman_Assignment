using System;

namespace switchdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Switchdemo();
            int a, b; 
            char choice;

            Console.WriteLine("Enter two integers:");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter choice:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            choice = Convert.ToChar(Console.ReadLine());

            switch (choice)
            {
                case '+':
                    Console.WriteLine($"Addition is: {a + b}");
                    break;

                case '-':
                    Console.WriteLine(a >= b
                        ? $"Subtraction is: {a - b}"
                        : $"Subtraction is: {b - a}");
                    break;

                case '*':
                    Console.WriteLine($"Multiplication is: {a * b}");
                    break;

                case '/':
                    if (b != 0)
                        Console.WriteLine($"Division is: {a / b}");
                    else
                        Console.WriteLine("Division is not possible");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        

        //private static void Switchdemo()
        //{
        //    int a, b, choice;

        //    Console.WriteLine("Enter two integers:");
        //    a = Convert.ToInt32(Console.ReadLine());
        //    b = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Enter choice:");
        //    Console.WriteLine("1. Addition");
        //    Console.WriteLine("2. Subtraction");
        //    Console.WriteLine("3. Multiplication");
        //    Console.WriteLine("4. Division");

        //    choice = Convert.ToInt32(Console.ReadLine());

        //    switch (choice)
        //    {
        //        case 1:
        //            Console.WriteLine($"Addition is: {a + b}");
        //            break;

        //        case 2:
        //            Console.WriteLine(a >= b
        //                ? $"Subtraction is: {a - b}"
        //                : $"Subtraction is: {b - a}");
        //            break;

        //        case 3:
        //            Console.WriteLine($"Multiplication is: {a * b}");
        //            break;

        //        case 4:
        //            if (b != 0)
        //                Console.WriteLine($"Division is: {a / b}");
        //            else
        //                Console.WriteLine("Division is not possible");
        //            break;

        //        default:
        //            Console.WriteLine("Invalid choice");
        //            break;
        //    }
        //}

    }
}
