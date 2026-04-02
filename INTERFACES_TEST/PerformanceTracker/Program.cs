using System;
using System.Collections.Generic;
using System.Linq;

/* ================= INTERFACES ================= */

public interface IEmployee
{
    string EmployeeId { get; set; }
    string Name { get; set; }
    int TasksCompleted { get; set; }
    double Rating { get; set; }
}

public interface IPerformanceTracker
{
    void AddEmployee(IEmployee emp);
    void UpdatePerformance(string id, int tasks, double rating);
    IEmployee? GetEmployee(string id);
    List<IEmployee> GetTopPerformers(double minRating);
    int GetTotalTasksCompleted();
}

/* ================= IMPLEMENT YOURSELF ================= */

class Employee : IEmployee {
    public string EmployeeId { get; set; }
    public string Name { get; set; }
    public int TasksCompleted { get; set; }
    public double Rating { get; set; }

    // Added parameterless constructor so object-initializer usage `new Employee { ... }` compiles.
    public Employee() { }

    public Employee(string EmployeeId , string Name, int TasksCompleted ,double Rating)
    {
        this.EmployeeId = EmployeeId;
        this.Name = Name;
        this.TasksCompleted = TasksCompleted;
        this.Rating = Rating;
    }
}

class PerformanceTracker : IPerformanceTracker {
    private List<IEmployee> list = new List<IEmployee>();

    public void AddEmployee(IEmployee emp)
    {
        if (emp == null) throw new ArgumentNullException(nameof(emp));

        // Prevent duplicate EmployeeId
        if (list.Any(x => x.EmployeeId == emp.EmployeeId))
            throw new InvalidOperationException($"Employee with ID '{emp.EmployeeId}' already exists.");

        list.Add(emp);
    }
    public void UpdatePerformance(string id, int tasks, double rating)
    {
        var item = list.FirstOrDefault(x => x.EmployeeId == id);
        if (item == null)
            throw new KeyNotFoundException($"Employee with ID '{id}' not found.");

        // Increment tasks (tests expect cumulative addition) and update rating.
        item.TasksCompleted += tasks;
        item.Rating = rating;
    }
    public IEmployee? GetEmployee(string id)
    {
        return list.FirstOrDefault(x => x.EmployeeId == id);
    }
    public List<IEmployee> GetTopPerformers(double minRating)
    {
        return list.Where(x => x.Rating > minRating).ToList();
    }
    public int GetTotalTasksCompleted()
    {
        return list.Sum(x => x.TasksCompleted);
    }
}

/* ================= TEST DRIVER ================= */

class Program
{
    static void Print(string test, bool pass)
    {
        Console.WriteLine($"{test} : {(pass ? "PASS ✅" : "FAIL ❌")}");
    }

    static void Main()
    {
        IPerformanceTracker tracker = new PerformanceTracker();

        Console.WriteLine("===== START TESTING =====\n");

        /* ---------- TEST 1 : ADD ---------- */
        tracker.AddEmployee(new Employee
        {
            EmployeeId = "E1",
            Name = "Aman",
            TasksCompleted = 10,
            Rating = 4.2
        });

        var emp = tracker.GetEmployee("E1");
        Print("Add Employee", emp != null);

        /* ---------- TEST 2 : DUPLICATE ADD ---------- */
        try
        {
            tracker.AddEmployee(new Employee
            {
                EmployeeId = "E1",
                Name = "Duplicate",
                TasksCompleted = 1,
                Rating = 1
            });

            Console.WriteLine("Duplicate Handling : CHECK YOUR LOGIC ⚠️");
        }
        catch
        {
            Print("Duplicate Add Handling", true);
        }

        /* ---------- TEST 3 : UPDATE ---------- */
        tracker.UpdatePerformance("E1", 5, 4.8);

        emp = tracker.GetEmployee("E1");

        Print("Update Tasks",
            emp != null && emp.TasksCompleted == 15);

        Print("Update Rating",
            emp != null && emp.Rating == 4.8);

        /* ---------- TEST 4 : UPDATE NON EXISTING ---------- */
        try
        {
            tracker.UpdatePerformance("E999", 2, 3);
            Console.WriteLine("Update Non Existing : HANDLE PROPERLY ⚠️");
        }
        catch
        {
            Print("Update Non Existing Employee", true);
        }

        /* ---------- TEST 5 : TOTAL TASKS ---------- */
        tracker.AddEmployee(new Employee
        {
            EmployeeId = "E2",
            Name = "Riya",
            TasksCompleted = 20,
            Rating = 4.9
        });

        int totalTasks = tracker.GetTotalTasksCompleted();
        Print("Total Tasks Calculation", totalTasks == 35);

        /* ---------- TEST 6 : TOP PERFORMERS ---------- */
        var top = tracker.GetTopPerformers(4.5);

        Print("Top Performer Filter",
            top.Count == 2);

        /* ---------- TEST 7 : SEARCH NOT FOUND ---------- */
        var missing = tracker.GetEmployee("XYZ");
        Print("Get Non Existing Employee", missing == null);

        /* ---------- TEST 8 : EDGE VALUES ---------- */
        tracker.AddEmployee(new Employee
        {
            EmployeeId = "E3",
            Name = "ZeroTask",
            TasksCompleted = 0,
            Rating = 0
        });

        Print("Zero Values Allowed",
            tracker.GetEmployee("E3") != null);

        /* ---------- TEST 9 : LARGE UPDATE ---------- */
        tracker.UpdatePerformance("E3", 1000, 5);

        Print("Large Update",
            tracker.GetEmployee("E3")!.TasksCompleted == 1000);

        Console.WriteLine("\n===== TESTING COMPLETE =====");
    }
}