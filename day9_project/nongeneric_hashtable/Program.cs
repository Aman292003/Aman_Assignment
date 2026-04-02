using System.Collections;

namespace nongeneric_hashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(101, "John");
            ht.Add(102, "Smith");
            ht.Add('a', 543.8756);
            ht.Add(DateTime.Now,DateTime.UtcNow);
            foreach (DictionaryEntry de in ht)
            {
                Console.WriteLine($"{de.Key}  {de.Value}");
            }
            if(ht.ContainsKey(102))
            {
                Console.WriteLine("Key found : " + ht[102]);
            }
            ht.Remove('a');

            foreach (DictionaryEntry de in ht)
            {
                Console.WriteLine($"{de.Key}  {de.Value}");
            }
        }

    }
}
