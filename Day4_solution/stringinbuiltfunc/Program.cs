using System.Globalization;

namespace stringinbuiltfunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello, World!";
            string str2 = "Hello, C#!";
            string str3 = "Hello ";

            string sample = " ";
            string empty = string.Empty;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // modifing
            Console.WriteLine(empty);
            Console.WriteLine($"str1 length is {str.Length}");
            Console.WriteLine("\nModifying:");
            Console.WriteLine($"Insert: {str.Insert(6, "Beautiful")}");
            Console.WriteLine($"Remove: {str.Remove(7, 5)}");
            Console.WriteLine($"Replace: {str.Replace("World", "C#")}");
            Console.WriteLine($"Trim: '{str.Trim()}'");
            Console.WriteLine($"TrimStart: '{str.TrimStart()}'");
            Console.WriteLine($"TrimEnd: '{str.TrimEnd()}'");
            Console.WriteLine($"PadLeft: '{str2.PadLeft(10, '*')}'");
            Console.WriteLine($"PadRight: '{str2.PadRight(10, '-')}'");
            Console.WriteLine($"ToUpper: {str3.ToUpper()}");
            Console.WriteLine($"ToLower: {str2.ToLower()}");

            // Extracting
            Console.WriteLine("\nExtracting:");
            Console.WriteLine($"Substring: {str.Substring(7, 5)}");
            Console.WriteLine($"Split: {string.Join(", ", str.Split(' '))}");

            // Formatting
            Console.WriteLine("\nFormatting:");
            double number = 12345.6789;
            Console.WriteLine($"Currency: {number.ToString("C", new CultureInfo("en-IN"))}");
            Console.WriteLine($"Exponential: {number.ToString("E")}");
            Console.WriteLine($"General: {number.ToString("G")}");
            Console.WriteLine($"Percentage: {number.ToString("P")}");
            DateTime date = DateTime.Now;
            Console.WriteLine($"Short Date: {date.ToString("d")}");
            Console.WriteLine($"Long Date: {date.ToString("D")}");
            Console.WriteLine($"Short Time: {date.ToString("t")}");
            Console.WriteLine($"Long Time: {date.ToString("T")}");

            // Searching
            Console.WriteLine("\nSearching:");
            Console.WriteLine($"StartsWith 'Hello': {str.StartsWith(" Hello")}");
            Console.WriteLine($"EndsWith '!': {str.EndsWith("!")}");
            Console.WriteLine($"IndexOf 'World': {str.IndexOf("World")}");
            Console.WriteLine($"Contains 'World': {str.Contains("World")}");

            string r = "sam";
            string s = "mas";
            Console.WriteLine($"\nComparing '{s}' and '{r}': {string.Compare(s, r)}");
            Console.WriteLine($"\nComparing '{s}' and '{r}': {s.CompareTo(r)}");
            Console.WriteLine($"\nEqual '{s}' and '{r}': {string.Equals(s, r)}");

        }
    }
}
