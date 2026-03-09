namespace functionoverloading
{
    class abcd
    {
        public void add(int a , int b)
        {
            Console.WriteLine("The sum of two integers is : " + (a + b).ToString());
        }
        public void add(double a , double b)
        {
            Console.WriteLine("The sum of two double values is : " + (a + b).ToString());
        }
        //public void add(int a , int b , int c)
        //{
        //    Console.WriteLine("The sum of three integers is : " + (a + b + c).ToString());
        //}
        public decimal add(int a , decimal b , double c)
        {
            return a + b + (decimal)c;
        }
        public void add(int a , char b)
        {
            Console.WriteLine("The sum of integer and char is : " + (a + b).ToString());
        }
        public double add (int a ,decimal b , double c , float d)
        {
            return a + (double)b + c + (double)d;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            abcd obj = new abcd();
            obj.add(10, 20);
            obj.add(10.5, 20.5);
            decimal result = obj.add(10, 20.5m, 30.585);
            Console.WriteLine("The sum of integer, decimal and double is : " + result.ToString());
            obj .add(10, 'A');
            Console.WriteLine("The sum of integer, decimal, double and float is : " + obj.add(10, 20.5m, 30.585, 40.5f).ToString());
        }
    }
}
