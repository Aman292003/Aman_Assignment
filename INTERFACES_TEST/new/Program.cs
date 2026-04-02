using System;
using System.Collections.Generic;
using System.Linq;

/* ================= CUSTOM EXCEPTION ================= */

public class EmployeeException : Exception
{
    public EmployeeException(string msg) : base(msg) { }
}


/* ================= INTERFACES ================= */

public interface IEmployee
{
    string EmployeeId { get; set; }
    string Name { get; set; }
    int TasksCompleted { get; set; }
    double Rating { get; set; }

    double CalculateBonus();
}

public interface IRewardEngine
{
    void AddEmployee(IEmployee emp);
    void UpdatePerformance(string id, int tasks, double rating);
    IEmployee GetEmployee(string id);
    List<IEmployee> GetTopPerformers(double minRating);
    double GetTotalTasks();
    IEmployee GetHighestBonusEmployee();
}


/* ================= ABSTRACT BASE ================= */

public abstract class EmployeeBase : IEmployee
{
    public string EmployeeId { get; set; }
    public string Name { get; set; }
    public int TasksCompleted { get; set; }
    public double Rating { get; set; }

    public abstract double CalculateBonus();

    public virtual void Validate()
    {
       if(String.IsNullOrEmpty(EmployeeId)||Rating<0 || Rating >5 )
        {
            throw new InvalidDataException("Invalid Data entry");
        }
    }
}


/* ================= EMPLOYEE TYPES ================= */

class PermanentEmployee : EmployeeBase
{
    public double Salary { get; set; }

    public override double CalculateBonus()
    {
        if (Rating >=4.5)
        {
            return Salary * 0.20;
        }
        else if(Rating >=4){
            return Salary * 0.10;
        }
        return 0;
    }
}

class ContractEmployee : EmployeeBase
{
    public override double CalculateBonus()
    {
        if(TasksCompleted >= 50)
        {
            return 5000;
        }
        else if (TasksCompleted >= 20)
        {
            return 2000;
        }
        return 0;
    }
}


/* ================= ENGINE ================= */

class RewardEngine : IRewardEngine
{
    // MUST USE DICTIONARY<string, IEmployee>
    Dictionary<string, IEmployee> list = new Dictionary<string, IEmployee>();
    public void AddEmployee(IEmployee emp)
    {
        if (list.ContainsKey(emp.EmployeeId)){
            throw new EmployeeException($"Emp {emp.EmployeeId} already exists");
        }
        else
        {
            list.Add(emp.EmployeeId, emp);
        }
    }

    public void UpdatePerformance(string id, int tasks, double rating)
    {
        if (!list.ContainsKey(id))
        {
            throw new EmployeeException($"No emp with {id} exist ");
        }
        else
        {
            list[id].TasksCompleted += tasks;
            list[id].Rating = rating;
        }
    }

    public IEmployee GetEmployee(string id)
    {
        return list.Values.FirstOrDefault(x => x.EmployeeId == id);
    }

    public List<IEmployee> GetTopPerformers(double minRating)
    {
        return list.Values.Where(x => x.Rating >= minRating).ToList();
    }
    public double GetTotalTasks()
    {
        return list.Values.Sum(c => c.TasksCompleted);
    }

    public IEmployee GetHighestBonusEmployee()
    {
        var maxium = list.Values.Max(x => x.CalculateBonus());
        return list.Values.FirstOrDefault(x => x.CalculateBonus() == maxium);
    }
}


/* ================= TEST DRIVER ================= */

class Program
{
    static void Main()
    {
        IRewardEngine engine = new RewardEngine();

        engine.AddEmployee(new PermanentEmployee
        {
            EmployeeId = "E1",
            Name = "Aman",
            Salary = 60000,
            TasksCompleted = 40,
            Rating = 4.6
        });

        engine.AddEmployee(new ContractEmployee
        {
            EmployeeId = "E2",
            Name = "Riya",
            TasksCompleted = 55,
            Rating = 4.2
        });

        engine.UpdatePerformance("E1", 10, 4.8);

        Console.WriteLine("Top Performers:");
        foreach (var e in engine.GetTopPerformers(4.5))
            Console.WriteLine(e.Name);

        Console.WriteLine("\nTotal Tasks:");
        Console.WriteLine(engine.GetTotalTasks());

        Console.WriteLine("\nHighest Bonus:");
        Console.WriteLine(engine.GetHighestBonusEmployee().Name);
    }
}