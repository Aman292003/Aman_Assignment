using System;

namespace Array

{
    class customer
    {
        public int customerid;
        public string customername;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] aa1 = new int[] { 23, 45, 67, 89, 12, 34 };
            //above is infinite arrrray i can keep as many 
            //elements i want so above i had done declaration also 
            // and initialization also
            int[] aa2 = new int[3] { 12, 45, 67 };
            // above it is fixed array so decalration and initialization done
            string[] names = new string[] { "sachin", "ravi", "kiran", "sita" };
            char[] chars = new char[4] { 'a', 'b', 'c', 'd' };
            int[] arr = new int[5];
            int i, j, sum = 0;
            //i = input(arr);
            Console.WriteLine("Elements in array are:");
            //Print_arr(arr);

            //sum_arr(arr);
            foreach (string name in names)
            {
                Console.WriteLine("\nName: " + name);
            }
            j = search_arr(aa1);
            customer[] clist = new customer[3];
            Console.WriteLine("\nEnter customer details:");
            for (i = 0; i < clist.Length; i++)
            {
                clist[i] = new customer();
                Console.WriteLine("Enter customer id:");
                clist[i].customerid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter customer name:");
                clist[i].customername = Console.ReadLine();
            }

            Console.WriteLine("\nCustomer details are:");
            foreach(customer c in clist)
            {
                Console.WriteLine("Customer ID: " + c.customerid + ", Customer Name: " + c.customername);
            }

            Console.ReadLine();
        }

        private static int search_arr(int[] aa1)
        {
            int j;
            int element_to_find = 34;
            bool found = false;
            for (j = 0; j < aa1.Length; j++)
            {
                if (aa1[j] == element_to_find)
                {
                    found = true;
                    break;
                }
            }
            if (found)
                Console.WriteLine($"\nElement {element_to_find} found at index {j + 1} in aa1 array.");
            else
                Console.WriteLine($"\nElement {element_to_find} not found in aa1 array.");
            return j;
        }

        private static void sum_arr(int[] arr)
        {
            int i;
            int sum = 0;
            for (i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("\nSum of array elements is: " + sum);
            return ;
        }

        private static void Print_arr(int[] arr)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                Console.Write(arr[k] + "\t");
            }
        }

        private static int input(int[] arr)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter element for index " + (i + 1));
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            return i;
        }
    }
}
