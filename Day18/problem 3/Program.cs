namespace problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] candle = new int[n];
            for (int i = 0; i < n; i++)
            {
                candle[i] = Convert.ToInt32(Console.ReadLine());
            }

            int max = candle.Max();
            int count = 0;
            for(int i = 0; i < n; i++)
            {
                if(candle[i] == max)
                {
                    count++;
                }
            }
            Console.WriteLine("The count is " +count);
        }
    }
}
