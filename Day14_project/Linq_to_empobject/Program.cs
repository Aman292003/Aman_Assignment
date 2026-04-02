namespace Linq_to_empobject
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = EmployeeRepo.Retrive();

            var employees2 = from emp in EmployeeRepo.Retrive() select emp;

            //here above i had used two ways of retriving one is what we do in normal way 
            // another is query syntx in both the cases i can see list of employees 

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }

            Console.WriteLine("\n\n");
            foreach (var employee in employees2)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }
            Console.WriteLine("Order by demo");

            var order = employees2.OrderBy(x => x.City).ThenBy(x => x.Sal);
            var usingorderbythen2 = from emp in employees2 orderby emp.City, emp.Sal select emp;
            Console.WriteLine("\n\n");
            foreach (var employee in order)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");


            }
            Console.WriteLine("\n\n");
            foreach (var employee in usingorderbythen2)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");


            }

            var firstname_city = from emp in employees2
                                 select new
                                 {
                                     emp.FirstName,
                                     emp.City
                                 };
            var firstname_city2 = from emp in employees2
                                  select new
                                  {
                                      fname = emp.FirstName,
                                      city = emp.City
                                  };
            var firstnamecity3 = employees.Select(x => new { x.FirstName, x.City });

            var fullname = from emp in employees2
                           select new
                           {
                               full_name = emp.FirstName + " " + emp.LastName,
                           };
            var skip2 = employees.Skip(2).Take(2);
            Console.WriteLine();
            foreach (var employee in skip2)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");

            }

          Console.WriteLine("\n\n");
            Console.WriteLine("Enter the id of emp which you want to retrive: ");
            int empid = Convert.ToInt32(Console.ReadLine());
            var empcheck = from emp in employees where emp.EmployeeID == empid select emp;

            Employee empfound = empcheck.FirstOrDefault();
            Console.WriteLine($"{empfound.EmployeeID}--{empfound.FirstName}");
            var groupby = employees2.GroupBy(x => x.City);
            foreach (var emp in groupby)
            {
                Console.WriteLine($"There are {emp.Count()} employee in {emp.Key}");
                Console.WriteLine($"{emp.Key}--{emp.Sum(x=>x.Sal)}");
                Console.WriteLine($"The name of employee in the {emp.Key} are :");
                foreach (var grp in emp)
                {
                    Console.WriteLine($"{grp.FirstName}");
                }
            }
        }
    }
}
