namespace operatoroverloading
{
    class abcd
    {
        public int a;
        public abcd()
        {
            a = 0;
        }
        public abcd(int x)
        {
            a = x;
        }
        public static abcd operator +(abcd obj1 , abcd obj2)
        {
            abcd temp = new abcd();
            temp.a = obj1.a + obj2.a;
            Console.WriteLine("The sum of two objects is : " + temp.a);
            return temp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        abcd ob = new abcd(5);
        abcd ob2 = new abcd(10);
        abcd ob3 = new abcd();
        ob3 = ob + ob2;
        Console.WriteLine(ob.a+ob2.a);

        }
    }
}
