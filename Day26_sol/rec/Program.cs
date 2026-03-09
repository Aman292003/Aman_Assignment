namespace rec
{
    internal class Program
    {
        public void calculateIterative(int n)
        {
            while (n > 0)
            {
                int k = n * n;
                Console.WriteLine(k);
                n = n - 1;
            }
        }
        public void calculateRecursive(int n)
        {
            if (n > 0)
            {
                int k = n * n;
                Console.WriteLine(k);
                calculateRecursive(n - 1);
            }
        }
        public void calculateRecursiveHead(int n)
        {
            if (n > 0)
            {
                calculateRecursiveHead(n - 1);
                int k = n * n;
                Console.WriteLine(k);

            }
        }
        static void A(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine($"A({n}) -> Stop");
                return;
            }

            Console.WriteLine($"Calling from A with n = {n}");
            B(n - 1);
        }

        static void B(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine($"B({n}) -> Stop");
                return;
            }

            Console.WriteLine($"Calling from B with n = {n}");
            A(n - 1);
        }


        public void calculateRecursiveTree(int n)
        {
            if (n > 0)
            {
                calculateRecursiveTree(n - 1);
                int k = n * n;
                Console.WriteLine(k);
                calculateRecursiveTree(n - 1);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            //Console.WriteLine("Iterative approach:");
            // p.calculateIterative(5);
            //Console.WriteLine("Recursive approach:");
            //p.calculateRecursive(5);
            //Console.WriteLine("Recursive head approach:");
            //p.calculateRecursiveHead(5);

            //Console.WriteLine("Recursive tree approach:");
            p.calculateRecursiveTree(5);
            //Program.A(4);
            Console.ReadLine();
            
        }
    }
}

