using Cube_find;
namespace ConsoleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindCube obj=new FindCube();
            Console.WriteLine($"Cube of 3 is: {obj.Cube(3)}");
        }
    }
}
