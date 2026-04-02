namespace loop_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //While();
            //dowhiile();
            //mincoin();
            forloop();

        }

        private static void forloop()
        {
            int n;
            Console.WriteLine("Enter the value of n :");
            n = Convert.ToInt32(Console.ReadLine());
            int fact = 1;
            if (n == 0)
            {
                fact = 1;
            }
            for (int i = 1; i < n+1; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine($"The factorial of {n} is {fact}");
        }

        private static void mincoin()
        {
            int five = 0;
            int one = 0;
            int ten = 0;
            int amount = Convert.ToInt32(Console.ReadLine());

            while (amount > 0)
            {
                if (amount / 16 > 0)
                {
                    five += amount / 16;
                    one += amount / 16;
                    ten += amount / 16;
                    amount = amount % 16;
                }
                else if (amount / 10 > 0)
                {
                    ten += amount / 10;
                    amount = amount % 10;

                }
                else if (amount / 5 > 0)
                {
                    five += amount / 5;
                    amount = amount % 5;

                }
                else
                {
                    one += amount;
                    amount = 0;
                }



            }
            Console.WriteLine($"The ten rupee coin are {ten} , five rupee coin are {five} and one rupee coin are {one}");
        }

        private static void dowhiile()
        {
            int counter = 1;
            bool keepgoing = true;
            do
            {
                Console.Write($"\t{counter}");
                if ((counter % 100 == 0) && (counter != 0))
                {
                    Console.WriteLine("\n do you want to continue <y/n>?");
                    if (Console.ReadLine() != "y")
                    {
                        keepgoing = false;
                        //break;
                    }
                }
                counter = counter + 1;
            } while (keepgoing);
            Console.ReadLine();
        }

        private static void While()
        {
            int counter = Convert.ToInt32(Console.ReadLine());

            while (counter <= 100)
            {
                Console.WriteLine($"Counter value: {counter}");
                counter++;
            }
        }
    }
}
