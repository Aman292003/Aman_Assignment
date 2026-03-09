namespace tupplesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string name ,int age ,bool isactive) person = ("Aman", 22, true);
            Console.WriteLine(person);


            var (name, age, isactive) = person;

            Console.WriteLine($"Name: {name}, Age: {age}, IsActive: {isactive}");

        }
    }
}
