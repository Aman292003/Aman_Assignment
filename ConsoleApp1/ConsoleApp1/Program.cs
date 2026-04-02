using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y, z;
            //Console.WriteLine("Enter the value of x :");
            //x =Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the value of y :");
            //y = Convert.ToInt32(Console.ReadLine());
            //z = x + y;
            //Console.WriteLine("The sum of {0} and {1} is {2}", x, y, z);
            //Console.WriteLine("The sum of " + x + " and " + y + "is " + z);
            //Console.WriteLine($"{35}");
            //Console.WriteLine("Enter value in single line");
            //string input = Console.ReadLine();
            //x = Convert.ToInt32(input.Split(',')[0]);
            //y = Convert.ToInt32(input.Split(',')[1]);
            //z = x + y;
            //Console.WriteLine($"The sum of {x} and {y} is {z}");
            char[] ch = new char[] {',','.','/','-'};
            int m, n;
            string input = Console.ReadLine();
           // m = Convert.ToInt32(input.Split(ch)[0]);
          //  n = Convert.ToInt32(input.Split(ch)[1]);
            //Console.WriteLine($"The sum of {m} and {n} is {m+n}");
            Console.WriteLine($"The max and min value of int data type is {int.MaxValue} and {int.MinValue}");
            float f = 56.98f;
            double d = 45.6789;
            decimal di = 789.456m;
            Console.WriteLine($"{f}--{d}--{di}");
            Console.ReadKey();


        }
    }
}
