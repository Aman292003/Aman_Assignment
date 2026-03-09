namespace File_handling
{
    internal class Program
    {
        public static void readdata()
        {
            FileStream fs = null;
            StreamReader sr;

            fs = new FileStream(@"C:\Users\Aman Anand\Documents\Aman_Exam\Day12_solution\sample.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
        }
        public static void writedata()
        {
            FileStream fs = null;

            fs = new FileStream(@"C:\Users\Aman Anand\Documents\Aman_Exam\Day12_solution\sample.txt", FileMode.Open, FileAccess.Read);


            Console.WriteLine("enter something inside the file ");
            string input = Console.ReadLine();
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(input);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        static void Main(string[] args)
        {
            readdata();
            writedata();
        }
    }
}
