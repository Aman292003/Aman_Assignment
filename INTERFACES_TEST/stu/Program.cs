using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#region Exception

public class CourseException : Exception
{
    public CourseException(string msg) : base(msg) { }
}

#endregion

#region Interfaces

public interface IStudent
{
    string StudentId { get; set; }
    string Name { get; set; }
    int CompletedLessons { get; set; }
    bool IsCertified { get; set; }

    void validate();

    void CompleteLesson(int count);
}

#endregion

#region Student Class

public class Student : IStudent
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public int CompletedLessons { get; set; }
    public bool IsCertified { get; set; }

    // TODO
    // if lessons < 0 → throw exception
    // increase lessons
    // if lessons >= 10 → mark certified

    public void CompleteLesson(int count)
    {
        if (count < 1)
        {
            throw new CourseException("You must complete atleast 1 course");

        }
        CompletedLessons += count;
        if (CompletedLessons > 9)
        {
            IsCertified = true;
        }
    }
    public void validate()
    {
        if(String.IsNullOrEmpty(StudentId)|| String.IsNullOrEmpty(Name))
        {
            throw new CourseException("Name or id is empty");
        }
        if (CompletedLessons < 0)
        {
            throw new CourseException(" completed lessons must be 0 or more ");
        }
    }
}

#endregion

#region Course Platform

public class CoursePlatform
{
    private Dictionary<string, IStudent> students =
        new Dictionary<string, IStudent>(StringComparer.OrdinalIgnoreCase);

    // Delegate
    public delegate void CertificationNotification(string message);

    // Event
    public event CertificationNotification Notify;

    // TODO
    // Add student
    // duplicate check
    public void AddStudent(IStudent student)
    {
        student.validate();
        if (students.ContainsKey(student.StudentId))
        {
            throw new CourseException("Student Already exists");
        }
        students.Add(student.StudentId, student);
        Notify?.Invoke(student.StudentId + " is added");
    }

    // TODO
    // complete lessons
    // trigger event if certified
    public void CompleteLessons(string id, int lessons)
    {

        if (!students.ContainsKey(id))
        {
            throw new CourseException("Student doesnot exists");
        }
        var student = students[id];
        student.CompleteLesson(lessons);
        if (student.IsCertified)
        {
            Notify?.Invoke(student.StudentId+" get certified ");
        }
    }

    // TODO
    // get certified students
    public List<IStudent> GetCertifiedStudents()
    {
        return students.Values.Where(c => c.IsCertified).ToList();
    }

    // TODO
    // get top learner (max lessons)
    public IStudent GetTopLearner()
    {
        return students.Values.OrderByDescending(x => x.CompletedLessons).FirstOrDefault();
    }

    // TODO
    // average lessons completed
    public double AverageLessons()
    {
        return students.Values.Average(x => x.CompletedLessons);
    }

    // TODO
    // group by certification status
    public Dictionary<bool, List<IStudent>> GroupByCertification()
    {
        return students.Values.GroupBy(x => x.IsCertified).ToDictionary(x => x.Key, x => x.ToList());
    }
}

#endregion

#region Main


    class Program
    {
        static void Main()
        {
            CoursePlatform platform = new CoursePlatform();


    platform.Notify += msg => Console.WriteLine("EVENT: " + msg);

            // Test 1
            try
            {
                platform.AddStudent(new Student { StudentId = "S1", Name = "Aman" });
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 2
            try
            {
                platform.AddStudent(new Student { StudentId = "S2", Name = "Riya" });
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 3
            try
            {
                platform.AddStudent(new Student { StudentId = "S3", Name = "Karan" });
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 4
            try
            {
                platform.CompleteLessons("S1", 5);
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 5 (Certification event)
            try
            {
                platform.CompleteLessons("S1", 6);
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 6
            try
            {
                platform.CompleteLessons("S2", 3);
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 7
            try
            {
                platform.CompleteLessons("S3", 12);
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 8 (Duplicate student)
            try
            {
                platform.AddStudent(new Student { StudentId = "S1", Name = "Duplicate" });
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 9 (Invalid student)
            try
            {
                platform.CompleteLessons("S9", 3);
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 10 (Negative lessons)
            try
            {
                platform.CompleteLessons("S2", -1);
            }
            catch (CourseException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 11
            try
            {
                Console.WriteLine("Top Learner: " + platform.GetTopLearner().Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 12
            try
            {
                Console.WriteLine("Average Lessons: " + platform.AverageLessons());
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 13
            try
            {
                Console.WriteLine("Certified Students:");
                foreach (var s in platform.GetCertifiedStudents())
                    Console.WriteLine(s.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // Test 14 & 15
            try
            {
                var groups = platform.GroupByCertification();

                Console.WriteLine("Certified Count: " + groups[true].Count);
                Console.WriteLine("Non Certified Count: " + groups[false].Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }


}


#endregion