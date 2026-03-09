using System;
using System.Collections.Generic;
using System.Linq;

#region Custom Exception
public class StudentException : Exception
{
    public StudentException(string msg) : base(msg) { }
}
#endregion

#region Interfaces

public interface IStudent
{
    void AddStudent(Student s);
    void RemoveStudent(int id);
    List<Student> GetAllStudents();
}

public interface ICourse
{
    void AddCourse(Course c);
    List<Course> GetAllCourses();
}

#endregion

#region Models

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public override string ToString()
    {
        return $"{Id} {Name} Age:{Age} Marks:{Marks}";
    }
}

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }

    public override string ToString()
    {
        return $"{CourseId} {CourseName}";
    }
}

#endregion

#region Class 1 implementing IStudent

public class StudentManager : IStudent
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student s)
    {
        if (students.Any(x => x.Id == s.Id))
            throw new StudentException("Duplicate Student ID!");

        students.Add(s);
    }

    public void RemoveStudent(int id)
    {
        var st = students.FirstOrDefault(x => x.Id == id);

        if (st == null)
            throw new StudentException("Student not found");

        students.Remove(st);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    // Difficult LINQ Method
    public void DisplayTopStudents()
    {
        var result = students
                        .Where(x => x.Marks > 60)
                        .OrderByDescending(x => x.Marks)
                        .Take(3)
                        .Select(x => new
                        {
                            x.Name,
                            x.Marks
                        });

        Console.WriteLine("\nTop Students:");

        foreach (var r in result)
        {
            Console.WriteLine($"{r.Name} -> {r.Marks}");
        }
    }

    // GroupBy LINQ
    public void GroupStudentsByAge()
    {
        var groups = students.GroupBy(x => x.Age);

        Console.WriteLine("\nStudents Grouped By Age:");

        foreach (var g in groups)
        {
            Console.WriteLine("Age: " + g.Key);

            foreach (var s in g)
            {
                Console.WriteLine("   " + s.Name);
            }
        }
    }
}

#endregion

#region Class 2 implementing ICourse

public class CourseManager : ICourse
{
    private List<Course> courses = new List<Course>();

    public void AddCourse(Course c)
    {
        if (courses.Any(x => x.CourseId == c.CourseId))
            throw new StudentException("Duplicate Course ID");

        courses.Add(c);
    }

    public List<Course> GetAllCourses()
    {
        return courses;
    }

    // LINQ Method
    public void DisplayCourses()
    {
        var result = courses.Select(x => x.CourseName);

        Console.WriteLine("\nCourse List:");

        foreach (var r in result)
        {
            Console.WriteLine(r);
        }
    }
}

#endregion

#region Main Program

class Program
{
    static void Main()
    {
        StudentManager sm = new StudentManager();
        CourseManager cm = new CourseManager();

        try
        {
            // Students
            sm.AddStudent(new Student { Id = 1, Name = "Aman", Age = 20, Marks = 85 });
            sm.AddStudent(new Student { Id = 2, Name = "Ravi", Age = 21, Marks = 45 });
            sm.AddStudent(new Student { Id = 3, Name = "Priya", Age = 20, Marks = 92 });
            sm.AddStudent(new Student { Id = 4, Name = "Karan", Age = 22, Marks = 67 });
            sm.AddStudent(new Student { Id = 5, Name = "Neha", Age = 21, Marks = 77 });

            // Difficult Test Case 1 (Duplicate ID)
            // sm.AddStudent(new Student { Id = 1, Name = "Duplicate", Age = 23, Marks = 90 });

            // Courses
            cm.AddCourse(new Course { CourseId = 101, CourseName = "AI" });
            cm.AddCourse(new Course { CourseId = 102, CourseName = "Cloud Computing" });
            cm.AddCourse(new Course { CourseId = 103, CourseName = "Cyber Security" });

            // Difficult Test Case 2 (Duplicate Course)
            // cm.AddCourse(new Course { CourseId = 101, CourseName = "Duplicate Course" });

        }
        catch (StudentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        // Display Students
        Console.WriteLine("All Students:\n");
        foreach (var s in sm.GetAllStudents())
        {
            Console.WriteLine(s);
        }

        // LINQ methods
        sm.DisplayTopStudents();
        sm.GroupStudentsByAge();

        // Courses
        cm.DisplayCourses();

        // Difficult Test Case 3 (Delete Non-existing Student)
        try
        {
            sm.RemoveStudent(100);
        }
        catch (StudentException ex)
        {
            Console.WriteLine("\nEdge Case: " + ex.Message);
        }
    }
}

#endregion