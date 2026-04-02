using System.Text.RegularExpressions;
namespace Regex_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var subject = Console.ReadLine();   

            var ragex = new Regex(pattern);

            var match = ragex.Match(subject);

            Console.WriteLine(match.Success);
            Console.WriteLine(ragex);

            while(match.Success)
            {
                Console.WriteLine($"Matched value: {match.Value} at{match.Index} with length {match.Length}");
               
                match = match.NextMatch();
            }
            Console.ReadLine(); 

        }
    }
}
