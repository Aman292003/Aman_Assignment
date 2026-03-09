

namespace Timecom
{
    internal class Program
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minidx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minidx])
                    {
                        minidx = j;
                    }
                }
                int temp = arr[minidx];
                arr[minidx] = arr[i];
                arr[i] = temp;
            }
        }
        static int[] GenerateRandomArray(int n)
        {
            Random rnd = new Random();
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(); // 0 to int.MaxValue
            }

            return arr;
        }
        static void Main(string[] args)
        {
            int[] arr = GenerateRandomArray(10000);
            int[] arr1 = (int[])arr.Clone();
            int[] arr2 = (int[])arr.Clone();
            var sw = System.Diagnostics.Stopwatch.StartNew();
            BubbleSort(arr);
            sw.Stop();
            Console.WriteLine($"bs Time: {sw.ElapsedMilliseconds} ms");
            
            
            var sw1 = System.Diagnostics.Stopwatch.StartNew();
            InsertionSort(arr1);
            sw1.Stop();
            Console.WriteLine($"is Time: {sw1.ElapsedMilliseconds} ms");
            
            
            var sw2 = System.Diagnostics.Stopwatch.StartNew();
            SelectionSort(arr2);
            sw2.Stop();
            Console.WriteLine($"ss Time: {sw2.ElapsedMilliseconds} ms");
        }
    }
}
