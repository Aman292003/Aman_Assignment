using System.Text.RegularExpressions;

namespace DAY17_Exam
{
    internal class Program
    {
        public static string ValidateLicensePlate(string plate)
        {
            string pat = @"^[A-Z]{2}[0-9]{2}\s[A-Z]{2}\s[0-9]{4}$";

            if (Regex.IsMatch(plate, pat))
                return "VALID";
            else
                return "INVALID";
            return " ";
        }
       
        static void Main(string[] args)
        {
           string plate = "HR20 AS 7065"; 
           Console.WriteLine(ValidateLicensePlate(plate));
             string plate2 = "HR20 A 7065"; 
           Console.WriteLine(ValidateLicensePlate(plate2));
        }
    }
}
