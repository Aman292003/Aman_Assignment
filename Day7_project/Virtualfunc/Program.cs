namespace Virtualfunc
{
    class Base
    {
        public virtual void show()
        {
            System.Console.WriteLine("Base class show method called");
        }
        public void display()
        {
            System.Console.WriteLine("Base class display method called");
        }
    }
    class Derived : Base
    {
        public override void show()
        {
            System.Console.WriteLine("Derived class show method called");
        }
        public new void display()
        {
            System.Console.WriteLine("Derived class display method called");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Base obj = new Derived();
            obj.show();
            obj.display();
        }
    }
}
