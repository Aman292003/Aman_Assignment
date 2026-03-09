namespace Stack_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Stack<int> stack = new Stack<int>();
            
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Printing element");
            foreach(var item in stack)
            {
                Console.WriteLine(item);
            }
            int popele = stack.Pop();
            Console.WriteLine(popele);

            int top_ele = stack.Peek();
            Console.WriteLine(top_ele);

        }
    }
}
