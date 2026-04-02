namespace isasdemo
{
    class Employee
    {
        public string Name { get; set; }
        public Employee(string name)
        {
            Name = name;
        }

    }
    class Manager : Employee
    {
        public Manager(string name) : base(name)
        {
        }
        public void ApproveLeave()
        {
            Console.WriteLine($" {Name} approved leave request");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Manager("Alice");
            Employee emp2 = new Employee("Bob");
            if (emp is Manager mgr)
            {
                Console.WriteLine($"{emp.Name} is a manager.");
            }
            else
            {
                Console.WriteLine($"{emp.Name} is not a manager and cannot approve leave requests.");
            }
            if (emp2 is Manager mgr2)
            {
                Console.WriteLine($"{emp2.Name} is a manager.");
            }
            else
            {
                Console.WriteLine($"{emp2.Name} is not a manager");
            }
            Manager mgr1 = emp2 as Manager;
            if (mgr1 != null)
            {
                mgr1.ApproveLeave();
            }
            else
            {
                Console.WriteLine($"{emp2.Name} is not a manager and cannot approve leave requests.");
            }
        }
    }
}
