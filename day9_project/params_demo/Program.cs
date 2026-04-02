namespace params_demo
{
    class employee
    {
        //public void tsal( int sal, int bonus ,int allowance)
        //{
        //    Console.WriteLine($"The Salary is { sal+bonus+allowance}");
        //}
        //public void tsal(int sal, int bonus, int allowance ,int houseallowance)
        //{
        //    Console.WriteLine($"The Salary is {sal + bonus + allowance + houseallowance}");
        //}
        //public void tsal(int sal, int bonus)
        //{
        //    Console.WriteLine($"The Salary is {sal + bonus }");
        //}
        public void tsal(params int[] values)
        {
            int total = 0;
            foreach (var value in values)
            {
                total += value;
            }
            Console.WriteLine($"The Salary is {total}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            employee emp = new employee();
            emp .tsal(1000, 200, 300);
            
        }
    }
}
