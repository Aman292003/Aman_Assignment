namespace PatternMatch
{
    internal class Program
    {
        public class Student
        {
            public int Id { get; }
            public string Name { get; }
            public int Marks { get; }
            public string Grade { get; private set; } = "";

            public Student(int id, string name, int marks)
            {
                Id = id;
                Name = name;
                Marks = marks;
            }

            public override string ToString() => $"Student[Id={Id}, {Name}, Marks={Marks}]";
        }
        static string GetGrade(Student student) => student.Marks switch
        {
            >= 90 => "A 🎉 Excellent!",
            >= 80 => "B 👍 Very Good!",
            >= 70 => "C 😊 Good",
            >= 60 => "D 🙂 Pass",
            >= 50 => "E 😐 Average",
            _ => "F 😞 Fail - Retake"
        };

        static void Main(string[] args)
        {
            //int score = 85;
            //string grade = score switch
            //{
            //    >= 90 => "A",
            //    >= 80 => "B",
            //    >= 70 => "C",
            //    >= 60 => "D",
            //    _ => "F"
            //};
            //Console.WriteLine(grade);
            Console.WriteLine("🎯 Pattern Matching with Classes\n");

            // Create students
            Student[] students = {
                new Student(1, "Alice", 92),
                new Student(2, "Bob", 78),
                new Student(3, "Charlie", 55),
                new Student(4, "Diana", 45)
            };

            // Process each student using pattern matching
            foreach (Student s in students)
            {
                string grade = GetGrade(s);
                Console.WriteLine($"{s} -> {grade}");
            }
        }
    }
}
