namespace P4
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = Convert.ToInt32(Console.ReadLine());
            int[, ]arr = new int[n,n]; 

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    arr[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            int ld = 0;
            int rd = 0;

            for(int i = 0; i < n; i++)
            {
                ld = ld + arr[i,i];

                rd= rd + arr[i,n - 1 - i];
            }

            Console.WriteLine(Math.Abs(ld-rd));
        }
    }
}
