using System.Text;

namespace String_demo
{
    internal class Program
    {
        public static void concat(string s1)
        {
            s1 = s1 + " world";
        }
        public static void concat2(StringBuilder sb1)
        {
            sb1.Append("Everyone");
        }
        static void Main(string[] args)
        {
            string x = "Aman Anand";
            x.Substring(1, 3);// it don't get modified
            Console.WriteLine(x.Substring(1, 3));

            string fname = "Aman";
            string lname = "Anand";

            //string fullname = string.Concat(fname, " ", lname);
            string fullname = $"{fname} {lname}"; // string interpolation
            Console.WriteLine($"the fullname is: {fullname}");
            Console.WriteLine($"the new fname is: ");
            string fname2 = Console.ReadLine();
            fname = fname2;
            Console.WriteLine($"the modified fullname is: {fname} {lname}");
            string s1 = "hello";
            StringBuilder sb = new StringBuilder("hello");
            concat(s1);
            concat2(sb);

            Console.WriteLine(s1); // hello
            Console.WriteLine(sb); // helloEveryone


            string[] weekdays = new string[] { "Monday", "Tuesday", "Wednesday",
                                     "Thursday","Friday", "Saturday", "Sunday" };
            StringBuilder weekd = new StringBuilder();
            for (int i = 0; i < weekdays.Length - 2; i++)
            {
                weekd.Append(weekdays[i]);
                if(i < weekdays.Length - 3)
                weekd.Append(", ");


            }
            Console.WriteLine(weekd);
        }
    }
}
