using System.Collections;
namespace generic_dict_demo
{
    class customer
    {
        public customer(object value1, object value2)
        {
        }

        public int id
        {
            set;
            get;
        }
        public string name
        {
            set;
            get;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Console.WriteLine("\n Enter no of elements to be added in dictionary:");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n Enter key:");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter Value");
                string value = Console.ReadLine();
                dic.Add(key, value);


            }
            Console.WriteLine("\n The elements in dictionary are:");
            foreach(var item in dic)
            {
                Console.WriteLine(item);
            }
            Dictionary<double, customer> dic2 = new Dictionary<double, customer>()
           {
               {101.12 , new customer(101 ,"aman") }
           };


        }
    }
}
