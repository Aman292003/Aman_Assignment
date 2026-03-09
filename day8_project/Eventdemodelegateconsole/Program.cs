namespace Eventdemodelegateconsole
{
    internal class Program
    {
        public Program()
        {
            myevent = new mydelegate(testmethod);
            
        }
        public void testmethod()
        {
            Console.WriteLine("This is a test method.");
        }
        public delegate void mydelegate();
        public event mydelegate myevent;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.myevent();
            new Program().myevent();
        }
    }
}
