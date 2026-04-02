using System;
using System.Collections.Generic;
using System.Linq;

/*
=========================================================
        EMPLOYEE REWARD MANAGEMENT SYSTEM
=========================================================

You must implement:

1. Validation using custom exception
2. Bonus calculation logic
3. Reward eligibility rules
4. LINQ analytics section
5. Proper polymorphic behavior

DO NOT MODIFY EXISTING SIGNATURES
=========================================================
*/


/* ---------------- CUSTOM EXCEPTION ---------------- */
public class EmployeeValidationException : Exception
{
    public EmployeeValidationException(string message) : base(message) { }
}


/* ---------------- INTERFACE ---------------- */
public interface IRewardPolicy
{
    double CalculateBonus();
    bool IsEligibleForReward();
}


/* ---------------- BASE CLASS ---------------- */
public abstract class Employee : IRewardPolicy
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public int Rating { get; set; }

    public abstract double CalculateBonus();
    public abstract bool IsEligibleForReward();

    public void Validate()
    {
        if (String.IsNullOrEmpty(Name) || Salary <= 0 || Rating < 0 || Rating > 5)
        {
            throw new EmployeeValidationException($"Emp{EmpId} is not not valid");
        }
    } 

    public override string ToString()
    {
        return $"{EmpId}-{Name} | Salary:{Salary} | Rating:{Rating}";
    }
}


/* ---------------- PERMANENT EMPLOYEE ---------------- */
public class PermanentEmployee : Employee
{
    public int YearsOfService { get; set; }

    public override double CalculateBonus()
    {
        if (Rating == 5)
        {
            return 0.2 * Salary;
        }
        else if (Rating == 4)
        {
            return 0.15 * Salary;
        }
        else if (Rating == 3)
        {
            return 0.10 * Salary;
        }
        return 0;
    }

    public override bool IsEligibleForReward()
    {
        if (Rating > 2)
        {
            return true;
        }
        return false;
    }
}


/* ---------------- INTERN EMPLOYEE ---------------- */
public class InternEmployee : Employee
{
    public int CompletedProjects { get; set; }

    public override double CalculateBonus()
    {
        if (Rating == 5)
        {
            return 3000;
        }
        else if(Rating == 4)
        {
            return 1500;
        }
        return 0;
    }

    public override bool IsEligibleForReward()
    {
        if (Rating > 3)
        {
            return true;
        }
        return false;
    }

}


/* ---------------- SERVICE LAYER ---------------- */
public class RewardEngine
{
    public static double GenerateBonus(Employee emp)
    {
        emp.Validate();
        return emp.CalculateBonus();
    }
}


/* ---------------- MAIN (DO NOT CHANGE) ---------------- */
public class Solution
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new PermanentEmployee
            {
                EmpId = 1,
                Name = "Aman",
                Salary = 60000,
                Rating = 5,
                YearsOfService = 6
            },

            new InternEmployee
            {
                EmpId = 2,
                Name = "Neha",
                Salary = 20000,
                Rating = 3,
                CompletedProjects = 4
            },

            new PermanentEmployee
            {
                EmpId = 3,
                Name = "",
                Salary = -500,
                Rating = 8,
                YearsOfService = 1
            }
        };

        List<double> bonuses = new List<double>();

        foreach (var emp in employees)
        {
            try
            {
                double bonus = RewardEngine.GenerateBonus(emp);
                bonuses.Add(bonus);

                Console.WriteLine(emp);
                Console.WriteLine($"Bonus: {bonus}");
                Console.WriteLine($"Reward Eligible: {emp.IsEligibleForReward()}");
                Console.WriteLine();
            }
            catch (EmployeeValidationException ex)
            {
                Console.WriteLine($"Validation Failed: {ex.Message}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Logic Pending Implementation.");
            }
        }


        /* ================= LINQ TASKS ================= */

        // TODO:
        // 1. Highest bonus
        // 2. Average salary of valid employees
        // 3. Count reward eligible employees
        // 4. Employee with max rating
        // 5. Sort employees by salary desc
    }
}