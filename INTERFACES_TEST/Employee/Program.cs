using System;
using System.Collections.Generic;

/* ================= INTERFACES ================= */

public interface IEmployee
{
    string Name { get; set; }
    string Department { get; set; }
    double Salary { get; set; }
}

public interface ICompany
{
    void AddEmployee(IEmployee emp);
    List<IEmployee> GetEmployeesByDepartment(string dept);
    int GetEmployeeCount();
    double GetTotalSalary();
    IEmployee GetHighestPaidEmployee();
}



   class Employee : IEmployee {
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Employee(string Name , String Department , double Salary)
    {
        this.Name = Name;
        this.Department = Department;
        this.Salary = Salary;
    }
}
   class Company : ICompany {

    private List<IEmployee> list = new List<IEmployee>();

    public void AddEmployee(IEmployee emp)
    {
        list.Add(emp);
    }
    public List<IEmployee> GetEmployeesByDepartment(string dept)
    {
        return list.Where(s => s.Department.Equals(dept, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public int GetEmployeeCount()
    {
        return list.Count;
    }
    public double GetTotalSalary()
    {
        return list.Sum(s => s.Salary);
    }
    public IEmployee GetHighestPaidEmployee()
    {
        return list.OrderByDescending(s => s.Salary).FirstOrDefault();
    }
}

   

class Program
{
    static void Main(string[] args)
    {
        ICompany company = new Company();

        company.AddEmployee(new Employee("Aman", "IT", 50000));
        company.AddEmployee(new Employee("Riya", "HR", 40000));
        company.AddEmployee(new Employee("Karan", "IT", 65000));
        company.AddEmployee(new Employee("Neha", "Finance", 55000));

        Console.WriteLine("Total Employees:");
        Console.WriteLine(company.GetEmployeeCount());

        Console.WriteLine("\nIT Department Employees:");
        var itEmployees = company.GetEmployeesByDepartment("IT");

        foreach (var e in itEmployees)
        {
            Console.WriteLine(e.Name);
        }

        Console.WriteLine("\nTotal Salary Payout:");
        Console.WriteLine(company.GetTotalSalary());

        Console.WriteLine("\nHighest Paid Employee:");
        var highest = company.GetHighestPaidEmployee();
        Console.WriteLine($"{highest.Name} - {highest.Salary}");
    }
}