namespace _2d_array_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j = 0, sum = 0;
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < i; j++)
                {
                    Console.Write($"*\t");
                }
                Console.WriteLine();
            }
            int[,] arr = new int[3,3];
            int[,,] aa1 = new int[2, 3, 4];

            for(i = 0; i < arr.GetLength(0); i++)
            {
                for (j = 0; j < arr.GetLength(1); j++)

                {
                    Console.WriteLine($"Enter element at position [{i},{j}]: ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for(i = 0; i < arr.GetLength(0); i++)
            {
                for (j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                    sum += arr[i, j];
                }

                Console.WriteLine();
            }
            Console.WriteLine($"Sum of all elements in the 2D array: {sum}");

        }
    }
}
