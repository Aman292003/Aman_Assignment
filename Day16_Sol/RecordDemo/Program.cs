namespace RecordDemo
{
    public record person(int Age , string Name);
    internal class Program
    {
        static void Main(string[] args)
        {
            person p1 = new person(20, "Alice");
            person p2 = new person(20, "Aam");
            Console.WriteLine(p1);
            Console.WriteLine(p2.Age +" " + p2.Name);
            //p2.Age = 43 //error because records are immutable by default
            Console.ReadLine();
        }
    }
}
