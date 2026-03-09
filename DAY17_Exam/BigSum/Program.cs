namespace BigSum
{
    internal class Program
    {
        public static double CalculateSum(int N, string[] array)
        {
            double sum = 0;

            for (int i = 0; i < N; i++)
            {
                sum += double.Parse(array[i]);
            }

            return sum;
        }
        static void Main(string[] args)
        {
            string[] arr = { "1000000001", "1000000002", "1000000003", "1000000004", "1000000005", "1000000006", "1000000007", "1000000008", "1000000009" };
            Console.WriteLine(CalculateSum(9, arr));
        }
    }
}
