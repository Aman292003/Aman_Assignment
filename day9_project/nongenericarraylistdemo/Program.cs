using System.Collections;

namespace nongenericarraylistdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(100);
            list.Add("Hello");
            list.Add(12.34);
            list.Add(true);

            Console.WriteLine("NO of element are "+ list.Count);
            Console.WriteLine("Capacity is "+ list.Capacity);
            Console.WriteLine("Element of list are ");
            foreach (var ele in list){
                Console.WriteLine(ele);
                          
            }
            Console.WriteLine();
            list.Insert(1, "hello world");
            list.Remove("Hello");
            foreach (var ele in list)
            {
                Console.WriteLine(ele);

            }
            

        }
    }
}
