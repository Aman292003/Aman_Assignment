using System;
using System.Collections.Generic;
using System.Linq;

/* =====================================================
   CUSTOM EXCEPTION
===================================================== */

public class CourseException : Exception
{
    public CourseException(string msg) : base(msg) { }
}


/* =====================================================
   DELEGATE
===================================================== */

// TODO: Trigger when certification achieved
// OR student completes >=20 lessons at once
public delegate void CourseNotification(string message);



/* =====================================================
   INTERFACE
===================================================== */

public interface IStudent
{
    string StudentId { get; set; }
    string Name { get; set; }
    int CompletedLessons { get; set; }
    bool IsCertified { get; set; }

    void Validate();
    void CompleteLesson(int count);
    double CalculateRewardPoints();
}


/* =====================================================
   ABSTRACT BASE CLASS
===================================================== */

public abstract class StudentBase : IStudent
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public int CompletedLessons { get; set; }
    public bool IsCertified { get; set; }

    // TODO:
    // id/name empty -> exception
    // lessons < 0 -> exception
    public virtual void Validate()
    {
        if (String.IsNullOrEmpty(StudentId) || String.IsNullOrEmpty(Name) || CompletedLessons < 0)
        {
            throw new CourseException("Invalid Data");
        }
    }

    // TODO:
    // increase lessons
    // certification if lessons >= 50
    public virtual void CompleteLesson(int count)
    {
        if (count < 0)
        {
            throw new CourseException("lesson cannot be negative");
        }
        CompletedLessons += count;
        if (CompletedLessons >= 50)
        {
            IsCertified = true;
        }
    }

    public abstract double CalculateRewardPoints();

    public override string ToString()
    {
        return $"{StudentId} - {Name} - Lessons:{CompletedLessons}";
    }
}


/* =====================================================
   STUDENT TYPES
===================================================== */

class RegularStudent : StudentBase
{
    // reward = lessons * 2
    public override double CalculateRewardPoints()
    {
        
        return CompletedLessons*2;
    }
}

class PremiumStudent : StudentBase
{
    // reward = lessons * 5
    // throw exception if lessons < 10
    public override double CalculateRewardPoints()
    {
        if (CompletedLessons < 10)
        {
            throw new CourseException("Premium Student must completed atleast 10 student");
        }
        return CompletedLessons*5;
    }
}


/* =====================================================
   ENGINE
===================================================== */

public class CourseEngine
{
    // MUST USE DICTIONARY (case-insensitive)
    private Dictionary<string, IStudent> students =
        new Dictionary<string, IStudent>(StringComparer.OrdinalIgnoreCase);

    // delegate instance
    public CourseNotification Notify;

    /* ================= CORE ================= */

    // TODO:
    // validate
    // duplicate check
    public void RegisterStudent(IStudent s)
    {
        s.Validate();
        if (students.ContainsKey(s.StudentId))
        {
            throw new CourseException("Student Already Exists");
        }
        students.Add(s.StudentId, s);
    }

    // TODO:
    // student must exist
    // lessons > 0
    // trigger delegate events
    public void CompleteLessons(string id, int lessons)
    {
        if (!students.ContainsKey(id))
            throw new CourseException("Add Student First");

        var student = students[id];

        student.CompleteLesson(lessons);  // call student method

        if (student.IsCertified)
            Notify?.Invoke(student.Name + " is now certified!");

        if (lessons >= 20)
            Notify?.Invoke(student.Name + " completed many lessons!");
    }

    // TODO:
    // case-insensitive search
    public IStudent GetStudent(string id)
    {
        var student = students.Values.FirstOrDefault(x => x.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));
        return student == null ? throw new CourseException("No such Student is Present"):student;
    }


    /* ================= LINQ ================= */

    // total lessons completed
    public int GetTotalLessons()
    {
        return students.Values.Sum(x => x.CompletedLessons);
    }

    // certified students
    public List<IStudent> GetCertifiedStudents()
    {
        return students.Values.Where(x => x.IsCertified == true).ToList();
        
    }

    // highest reward student
    public IStudent GetTopRewardStudent()
    {
        // TODO
        var student = students.Values.OrderByDescending(x => x.CalculateRewardPoints()).FirstOrDefault();
        return student != null ? student : throw new CourseException("No such Student is Present");
    }

    // students above lesson count
    public List<IStudent> GetStudentsAbove(int lessons)
    {
       
        return students.Values.Where(x=>x.CompletedLessons>=lessons).ToList();
    }

    // sort by reward descending
    public List<IStudent> SortByRewards()
    {
        return students.Values.OrderByDescending(x => x.CalculateRewardPoints()).ToList();


    }

    // group by certification status
    public Dictionary<bool, List<IStudent>> GroupByCertification()
    {
        return students.Values.GroupBy(x => x.IsCertified).ToDictionary(g=>g.Key,g=>g.ToList());
    }
}


/* =====================================================
   MAIN FUNCTION (TEST CASES)
===================================================== */

class Program
{
    static void Main()
    {
        CourseEngine engine = new CourseEngine();

        // delegate handler
        engine.Notify += msg => Console.WriteLine("[NOTIFY] " + msg);

        Console.WriteLine("===== TEST 1 : Registration =====");

        engine.RegisterStudent(new RegularStudent
        {
            StudentId = "S1",
            Name = "Aman",
            CompletedLessons = 10
        });

        engine.RegisterStudent(new PremiumStudent
        {
            StudentId = "P1",
            Name = "Riya",
            CompletedLessons = 5
        });

        Console.WriteLine("Students Registered");


        /* ========= EDGE CASES ========= */

        Console.WriteLine("\nTEST 2 : Duplicate");
        try
        {
            engine.RegisterStudent(new RegularStudent
            {
                StudentId = "s1",
                Name = "Duplicate",
                CompletedLessons = 1
            });
        }
        catch (CourseException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine("\nTEST 3 : Lesson Completion");
        engine.CompleteLessons("S1", 45); // certification trigger
        engine.CompleteLessons("P1", 20); // delegate trigger


        Console.WriteLine("\nTEST 4 : Invalid Student");
        try
        {
            engine.CompleteLessons("XX", 10);
        }
        catch (CourseException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine("\nTEST 5 : LINQ Analytics");

        Console.WriteLine("Total Lessons:");
        Console.WriteLine(engine.GetTotalLessons());

        Console.WriteLine("\nCertified Students:");
        foreach (var s in engine.GetCertifiedStudents())
            Console.WriteLine(s);

        Console.WriteLine("\nTop Reward Student:");
        Console.WriteLine(engine.GetTopRewardStudent());

        Console.WriteLine("\nSorted By Rewards:");
        foreach (var s in engine.SortByRewards())
            Console.WriteLine($"{s.Name} -> {s.CalculateRewardPoints()}");


        Console.WriteLine("\nALL TESTS COMPLETED ✅");
    }
}