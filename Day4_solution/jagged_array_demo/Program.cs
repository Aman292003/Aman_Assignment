namespace jagged_array_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedarray = new int[3][];
            int[,,] arr = new int[2,2,2];

            for(int i =0;i<2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        arr[i, j, k] = Convert.ToInt32(Console.ReadLine());
                    }
                    
                }
                
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        Console.WriteLine(arr[i, j, k]);
                    }
                    Console.WriteLine();

                }
                Console.WriteLine();


            }




            //jaggedarray[0] = new int[2] { 1, 2 };
            //jaggedarray[1] = new int[3] { 3, 4, 5 };
            //jaggedarray[2] = new int[4] { 6, 7, 8, 9 };

        //    for (int i = 0; i < jaggedarray.Length; i++)
        //    {
        //        Console.WriteLine($"Enter number of elements for row {i + 1}:");
        //        int size = Convert.ToInt32(Console.ReadLine());
        //        jaggedarray[i] = jaggedarray[i] - new int[size];
        //        Console.WriteLine($"Enter {size} elements for row {i + 1}:");
        //        for (int j = 0; j < size; j++)
        //        {
        //            jaggedarray[i][j] = Convert.ToInt32(Console.ReadLine());
        //        }
        //    }
        //    Console.WriteLine("Elements in the jagged array are:");
        //    for (int i = 0; i < jaggedarray.Length; i++)
        //    {
        //        for (int j = 0; j < jaggedarray[i].Length; j++)
        //        {
        //            Console.Write(jaggedarray[i][j] + "\t");
        //        }
        //        Console.WriteLine();
        //    }
        }
    }
}
