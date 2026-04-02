namespace Arthematicopsandanaother
{
    public class Calculate
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return Math.Abs(a - b);
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)a / b;
        }
        public int getpasswordstrength(string password)
        {
            int strength = 0;
            if (password.Length >= 8) strength++;
            if (password.Any(char.IsUpper)) strength++;
            if (password.Any(char.IsLower)) strength++;
            if (password.Any(char.IsDigit)) strength++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) strength++;
            return strength;
        }

    }
}
