using System;
using System.Collections.Generic;
using System.Linq;

/*
=====================================================
EMPLOYEE BONUS PROCESSING SYSTEM

WHAT YOU NEED TO DO (TODOs):

1. Create InvalidEmployeeException
2. Create IBonusCalculator interface
3. Make Employee implement interface
4. Implement CalculateBonus()
5. Add validation logic
6. Complete processing loop
7. Complete LINQ summary section
=====================================================
*/


/* ---------- CUSTOM EXCEPTION ---------- */
// TODO: Implement properly
class InvalidEmployeeException : Exception
{
    public InvalidEmployeeException(string message) : base(message)
    {
        // already working
    }
}


/* ---------- INTERFACE ---------- */
// TODO: Add method CalculateBonus()
interface IBonusCalculator
{
    double CalculateBonus();   // already added so project runs
}


/* ---------- EMPLOYEE CLASS ---------- */
class Employee : IBonusCalculator
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;
    public int Rating;

    public Employee(int id, string name, string dept,
                    double salary, int rating)
    {
        Id = id;
        Name = name;
        Department = dept;
        Salary = salary;
        Rating = rating;
    }

    // TODO:
    // Apply bonus rules based on rating
    public double CalculateBonus()
    {
        if (Rating == 5)
        {
            return Salary * 0.20;
        }
        else if (Rating == 4)
        {
            return Salary * 0.15;
        }
        else if (Rating == 3)
        {
            return Salary * 0.1;
        }
        else if (Rating == 2)
        {
            return Salary * 0.05;
        }
        return 0;
    }
}


/* ---------- PROCESSOR CLASS ---------- */
class EmployeeProcessor
{
    // TODO:
    // Throw exception if salary <= 0
    // OR rating not between 1 and 5
    public static void Validate(Employee e)
    {
        if(e.Salary<0 || e.Rating<0 || e.Rating > 5)
        {
            throw new InvalidEmployeeException($"{e.Name} is Invalid");
        }
    }
}


/* ---------- MAIN PROGRAM ---------- */
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee(101,"Aman","IT",100000,5),
            new Employee(102,"Riya","HR",80000,3),
            new Employee(103,"Karan","IT",-50000,4), // invalid
            new Employee(104,"Simran","Finance",150000,5),
            new Employee(105,"Neha","HR",90000,2)
        };

        // stores valid employee bonus results
        List<(string name, double bonus)> validBonuses =
            new List<(string, double)>();

        foreach (var emp in employees)
        {
            try
            {
                // TODO:
                // 1 Validate employee
                EmployeeProcessor.Validate(emp);

                // 2 Calculate bonus
                double bonus = emp.CalculateBonus();

                // 3 Print result
                Console.WriteLine(emp.Name + " Bonus : " + bonus);

                // 4 Store result
                validBonuses.Add((emp.Name, bonus));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Employee : " + emp.Id);
            }
        }

        Console.WriteLine("\n---- SUMMARY (TO IMPLEMENT USING LINQ) ----");

        // TODO LINQ PART:
        // Total Bonus Paid
        // Average Bonus
        // Highest Bonus Employee
        // Sort by bonus descending

        Console.WriteLine("Implementation Pending...");
    }
}