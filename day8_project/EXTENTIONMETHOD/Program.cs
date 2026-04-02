namespace EXTENTIONMETHOD
{
    public static class  intextension
    {
        public static bool isEven(this int number)
        {
            return number % 2 == 0;
        }
    }
    public static class stringextension
    {
        public static bool isPalindrome(this string str)
        {
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
    public static class myext
    {
        public static void display(this string str)
        {
            Console.WriteLine(str);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "madam";
            str1.display();
        }
    }
}
