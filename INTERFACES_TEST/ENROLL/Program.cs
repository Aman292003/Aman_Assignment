using System;
using System.Collections.Generic;
using System.Linq;

/* ================= CUSTOM EXCEPTION ================= */

public class StudentException : Exception
{
    public StudentException(string msg) : base(msg) { }
}


/* ================= INTERFACE ================= */

public interface IStudent
{
    string StudentId { get; set; }
    string Name { get; set; }
    double Progress { get; set; }

    double CalculateReward();

    void Validate();
}


/* ================= ABSTRACT CLASS ================= */

public abstract class StudentBase : IStudent
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public double Progress { get; set; }

    public abstract double CalculateReward();

    public virtual void Validate()
    {
        if(String.IsNullOrEmpty(StudentId)|| String.IsNullOrEmpty(Name)||Progress<0 || Progress>100)
        {
            throw new StudentException("Invalid Student or details");
        }
    }

    public override string ToString()
    {
        return $"{StudentId} - {Name} ({Progress}%)";
    }
}


/* ================= STUDENT TYPES ================= */

class RegularStudent : StudentBase
{
    public override void Validate()
    {
        base.Validate();
    }
    public override double CalculateReward()
    {
        if (Progress >= 80)
        {
            return 1000;
        }
        else if (Progress >= 50)
        {
            return 500;
        }
        return 0;
    }
}

class PremiumStudent : StudentBase
{
    public double CourseFee { get; set; }

    public override double CalculateReward()
    {
        if (Progress >= 80)
        {
            return 0.25 * CourseFee;
        }
        else if (Progress >= 60)
        {
            return 0.1 * CourseFee;
        }
        return 0;

    }
}




public interface ICourseEngine
{
    void AddStudent(IStudent student);
    void UpdateProgress(string id, double progress);
    IStudent GetStudent(string id);

    int GetTotalStudents();
    double GetAverageProgress();
    List<IStudent> GetTopStudents(double minProgress);
    IStudent GetHighestRewardStudent();
    List<IStudent> SortByProgressDesc();
}

class CourseEngine : ICourseEngine
{
    // MUST USE DICTIONARY
    Dictionary<string, IStudent> students =
        new Dictionary<string, IStudent>();

    public void AddStudent(IStudent student)
    {
        student.Validate();
        if (!students.ContainsKey(student.StudentId))
        {
            students.Add(student.StudentId, student);
        }
        else
        {
            throw new StudentException($"{student.StudentId} already exists");
        }
    }

    public void UpdateProgress(string id, double progress)
    {
        if (!students.ContainsKey(id))
            throw new StudentException("Student not found");

        if (progress < 0)
            throw new StudentException("Progress cannot be negative");

        var student = students[id];

        if (student.Progress + progress > 100)
            throw new StudentException("Progress exceeds 100");

        student.Progress += progress;
    }
    public IStudent GetStudent(string id)

    {
        var student = students.Values.FirstOrDefault(x => x.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (student==null)
            throw new StudentException("Student not found");
        return student;
    }

    public int GetTotalStudents()
    {
        return students.Count;
    }
    public double GetAverageProgress()
    {
        return students.Values.Average(x => x.Progress);

    }
    public List<IStudent> GetTopStudents(double minProgress)
    {
        return students.Values.Where(x => x.Progress >= minProgress).ToList();
    }
    public IStudent GetHighestRewardStudent()
    {
        double max = students.Values.Max(x => x.CalculateReward());
        return students.Values.FirstOrDefault(x => x.CalculateReward() == max);

    }
    public List<IStudent> SortByProgressDesc()
    {
        return students.Values.OrderByDescending(x => x.Progress).ToList();
    }
        
}


/* ================= MAIN (TEST DRIVER) ================= */

class Program
{
    static void Main()
    {
        ICourseEngine engine = new CourseEngine();

        Console.WriteLine("===== TEST 1: Normal Add =====");

        engine.AddStudent(new RegularStudent
        {
            StudentId = "S1",
            Name = "Aman",
            Progress = 70
        });

        engine.AddStudent(new PremiumStudent
        {
            StudentId = "S2",
            Name = "Riya",
            Progress = 85,
            CourseFee = 20000
        });

        Console.WriteLine("Students Added Successfully\n");


        /* ===================================================== */
        Console.WriteLine("===== TEST 2: Duplicate ID (EDGE CASE) =====");

        try
        {
            engine.AddStudent(new RegularStudent
            {
                StudentId = "S1",
                Name = "Duplicate",
                Progress = 50
            });
        }
        catch (StudentException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 3: Invalid Progress =====");

        try
        {
            engine.AddStudent(new RegularStudent
            {
                StudentId = "S3",
                Name = "Invalid",
                Progress = 120   // ❌ invalid
            });
        }
        catch (StudentException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 4: Update Progress (ADD not replace) =====");

        engine.UpdateProgress("S1", 20); // 70 + 20 = 90

        Console.WriteLine(engine.GetStudent("S1"));


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 5: Update Non-Existing Student =====");

        try
        {
            engine.UpdateProgress("S99", 10);
        }
        catch (StudentException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 6: Boundary Reward Check =====");

        engine.AddStudent(new RegularStudent
        {
            StudentId = "S4",
            Name = "Boundary50",
            Progress = 50
        });

        engine.AddStudent(new RegularStudent
        {
            StudentId = "S5",
            Name = "Boundary80",
            Progress = 80
        });

        foreach (var s in engine.SortByProgressDesc())
        {
            Console.WriteLine($"{s.Name} Reward: {s.CalculateReward()}");
        }


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 7: LINQ Analytics =====");

        Console.WriteLine("Total Students:");
        Console.WriteLine(engine.GetTotalStudents());

        Console.WriteLine("\nAverage Progress:");
        Console.WriteLine(engine.GetAverageProgress());

        Console.WriteLine("\nTop Students >= 80:");
        foreach (var s in engine.GetTopStudents(80))
            Console.WriteLine(s.Name);


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 8: Highest Reward =====");

        var top = engine.GetHighestRewardStudent();
        Console.WriteLine(top.Name);


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 9: Empty Engine Edge Case =====");

        ICourseEngine emptyEngine = new CourseEngine();

        try
        {
            emptyEngine.GetHighestRewardStudent();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Handled Empty Case");
        }


        /* ===================================================== */
        Console.WriteLine("\n===== TEST 10: Case Sensitivity =====");

        Console.WriteLine(engine.GetStudent("s1")); // should still work if handled
    }
}