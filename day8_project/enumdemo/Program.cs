namespace enumdemo
{
    class Employee
    {
        public int id { set; get; }
        public string Name { set; get; }


        public EmployeeType Type { get; set; }


    }
    enum EmployeeType
    {
        Fulltime, partime, contract
    }

    internal class Program
    {

        enum weekdays { sun = 10, mon, tue, wed, thu = 100, fri, sat };

        static void Main(string[] args)
        {

            Console.WriteLine($"{(int)weekdays.fri}");
            Console.WriteLine($"{(int)weekdays.mon}");
            Employee objemp = new Employee();
            objemp.id = 101;
            objemp.Name = "ravi";
            objemp.Type = EmployeeType.Fulltime;

            Console.WriteLine($"{objemp.id}--{objemp.Name}--{objemp.Type}");
            Console.ReadLine();
        }
    }
}
