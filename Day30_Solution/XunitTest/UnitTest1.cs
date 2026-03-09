using Arthematicopsandanaother;

namespace XunitTest
{
    public class CalculateTests
    {
        private readonly Calculate _calculator;

        public CalculateTests()
        {
            _calculator = new Calculate();
        }

        [Fact]
        public void Addition_ShouldReturnCorrectSum()
        {
            int result = _calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectResult_WhenNum1IsGreater()
        {
            int result = _calculator.Subtract(10, 3);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectResult_WhenNum2IsGreater()
        {
            int result = _calculator.Subtract(3, 10);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Multiplication_ShouldReturnCorrectProduct()
        {
            int result = _calculator.Multiply(5, 4);
            Assert.Equal(20, result);
        }

        [Fact]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            double result = _calculator.Divide(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Theory]
        [InlineData("", 0)] // Empty password
        [InlineData("12345", 1)] // Digits only
        [InlineData("password123", 3)] // Lowercase + digits
        [InlineData("Password123", 4)] // Uppercase + lowercase + digits
        [InlineData("Password@123", 5)] // Special char + uppercase + lowercase + digits
        public void GetPasswordStrength_ShouldReturnExpectedStrength(string password, int expectedStrength)
        {
            int result = _calculator.getpasswordstrength(password);
            Assert.Equal(expectedStrength, result);
        }
    }
}