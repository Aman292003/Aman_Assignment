using System.Collections;
namespace NONGENERIC_sortedlist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList sl = new SortedList();
            sl.Add(103, "John");
            sl.Add(101, "Smith");
            sl.Add(102, "David");
            sl.Add(104, "Mary");
            sl.Add(105, "Tina");
            sl.Add(106, "Fionna");

            foreach (DictionaryEntry de in sl)
            {
                Console.WriteLine($"{de.Key}  {de.Value}");
            }
        }
    }
}
