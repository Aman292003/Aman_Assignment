namespace Employee_management
{
    interface Iwork
    {
        void performWork();
        bool requestleave(int a);
    }
    abstract public class Employee
    {
        public String name;
        public int  employeeID;
        Employee (string a , int id)
        {
            name = a;
            employeeID = id;
        }
        public abstract double CalculateSalary();
    }
    class permanentEmployee : Employee, Iwork

    {

        double basicSalary;
        double benifits;
        permanentEmployee()
        {

        }

        permanentEmployee(double a , double b) {
            basicSalary = a;
            benifits = b;
        }
        

        public override double CalculateSalary()
        {
            return basicSalary + benifits;
        }

        public bool requestleave(int a)
        {
            if (a <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void performWork()
        {
            Console.WriteLine("permanent employee is working");
        }
        public void display()
        {
            Console.WriteLine("permanent employee details");
            Console.WriteLine("name: " + name);
            Console.WriteLine("employee id  " + employeeID);
            
        }
    }
    class contractEmployee : Employee, Iwork
    {
        double hourlyRate;
        int hoursWorked;
        public override double CalculateSalary()
        {
            return hourlyRate * hoursWorked;
        }

        public bool requestleave(int a)
        {
            if (a <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void display()
        {
            Console.WriteLine("permanent employee details");
            Console.WriteLine("name: " + name);
            Console.WriteLine("employee id  " + employeeID);

        }
        public void performWork()
        {
            Console.WriteLine("contract employee is working");
        }
        internal class Program
        {

            static void Main(string[] args)
            {
                permanentEmployee p = new permanentEmployee();
                contractEmployee c = new contractEmployee();
                
            }
        }
    }
}
