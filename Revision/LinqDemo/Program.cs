namespace LinqDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 12, 33, 44, 55, 6, 78, 100, 289, 25, 90, 44, 12, 78, 55, 100 };
            string[] names = new string[] { "Ravi", "Kiran", "Kishore", "Kavitha", "Mahesh", "Priya", "Suresh", "Anita", "Deepak", "Lakshmi", "Rajesh", "Pooja" };

            //var num30 = numbers.Where(s => s > 30).ToList();
            //Console.Write("Number greater than 30 are ");
            //foreach(var num in num30)
            //{
            //    Console.Write(num + "\t");
            //}
            //Console.WriteLine();

            //var evennum = numbers.Where(s => s % 2 == 0);
            //Console.WriteLine("The even num are " + string.Join("\t", evennum));

            //Console.WriteLine("The sum of num is :" + numbers.Sum());

            //var top3 = numbers.OrderByDescending(x => x).Take(3);

            //Console.WriteLine("The top 3 num are " + string.Join("\t", top3));

            //var evenodd = numbers.GroupBy(s => s % 2 == 0 ? "Even" : "odd");

            //foreach(var group in evenodd)
            //{
            //    Console.WriteLine($"{group.Key} : Count : {group.Count()},Average :{group.Average():F1} , Items = {string.Join(",",group)}");
                
            //}
            //var sqranged = numbers.Where(s => s >= 20 && s <= 100).Select(x => x * x).OrderBy(x => x);
            //Console.WriteLine("The Sq   in the range 20 to 100 is :" + string.Join("\t", sqranged));

            //var mostfreq = numbers.GroupBy(x=>x).OrderByDescending(x=>x.Count()).Take(3);

            //Console.WriteLine("Top 3 freq element are :");
            //foreach (var group in mostfreq)
            //{
            //    Console.WriteLine($"Number: {group.Key}, Count: {group.Count()}");
            //}

            //var cummilativesum = numbers.Select((x,i) => numbers.Take(i + 1).Sum());
            //Console.WriteLine($"Cummilative sum :" + string.Join(" ", cummilativesum));

            var nameswithk = names.Where(x => x.StartsWith("K"));
            Console.WriteLine($"Names Starts with K are  :" + string.Join(" ", nameswithk));

            foreach(var name in names)
            {
                Console.WriteLine($"The {name} has length {name.Length}");
            }
            var nameupper = names.Where(x => x.Length > 5).Select(x => x.ToUpper());
            Console.WriteLine($"Names with length>5 and in uppercase are :" + string.Join(" ", nameupper));

            var endvowel = names.Where(x => "aeiouAEIOU".Contains(x[^1])).OrderByDescending(x=>x.Length);
            Console.WriteLine($"Names endswith vowel are:" + string.Join(" ", endvowel));

            var groupbylength = names.OrderBy(x => x).GroupBy(x =>x.Length).OrderBy(g => g.Key); ;
            foreach (var group in groupbylength)
            {
                
                Console.WriteLine($"Group with length {group.Key} : Count : {group.Count()}, Smallest : {group.First()} ,Largest : {group.Last()}");
            }
            var reversename = names.Select(x => new string(x.Reverse().ToArray()));
            Console.WriteLine("Reverse string are "+ string.Join("-",reversename));

            var nameswithvowel = names.Where(x=>x.ToLower().Contains('a')||x.ToLower().Contains('i'))
                .Select(x=>new {name =x , countvalue = x.Count(c=>!"aeiouAEIOU".Contains(c))});
            Console.WriteLine("Name With Vowels " + string.Join("-", nameswithvowel));

            var first3upper = names.OrderBy(x => x).Take(3).Select(x => x.ToUpper());
            Console.WriteLine("Top 3 Name With Uppercase " + string.Join("-", first3upper));

            var len5 = names.All(x => x.Length > 5);
            Console.WriteLine("Name with length>3  " + len5);

            var len3 = names.Any(x => x.Length > 2);
            Console.WriteLine("Name with length>3  " + len3);

            Console.WriteLine($"Any Name start with P : {names.Any(x => x.StartsWith('P'))} ");




        }

    }
}
