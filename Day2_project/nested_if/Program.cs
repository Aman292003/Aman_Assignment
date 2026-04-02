using System;
namespace nested_if
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.WriteLine("Enter the coordinates");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nThe point ({x},{y})lies in ");
            if (x == 0)
            {
                if (y == 0)
                {
                    Console.WriteLine("Origin");
                }
                else
                {
                    Console.WriteLine("Y-axis");
                }
            }
            else if (y == 0)
            {
                Console.WriteLine("X-axis");
            }
            else if (x > 0)
            {
                if (y > 0)
                {
                    Console.WriteLine("First Quadrant");
                }
                else
                    Console.WriteLine("FORTH Quadrant");
            }
            else
            {
                if (y > 0)
                {
                    Console.WriteLine("Second Quadrant");

                }
                else
                {
                    Console.WriteLine("Third Quadrant");
                }
            }
            Console.ReadLine();
        }
    }
}
