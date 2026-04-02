namespace partialclassdemo
{
    public partial class employee
    {
        public int empid {  get; set; }
        public string name { get; set; }

        public employee(int empid, string name)
        {
            this.empid = empid;
            this.name = name;
        }
    }
    public partial class employee
    {
        public void display()
        {
            Console.WriteLine($"{empid} {name}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            employee emp = new employee(1,"Aman");
            emp.display();
        }
    }
}
