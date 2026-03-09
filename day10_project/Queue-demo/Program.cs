namespace Queue_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            int ele = queue.Dequeue();
            Console.WriteLine(ele);
        }
    }
}
