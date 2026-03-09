using Arthematicopsandanaother;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
namespace NunitTest
{
    [TestFixture]
    public class Tests
    {
        Calculate c = null;
        [SetUp]
        public void Setup()
        {
            c = new Calculate();
        }

        [Test]
        public void Add()
        {
            //int actual = 30;
            int expected = 30;
            int actual = c.Add(10, 20);
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
        [Test]
        [TestCase(10, 20, 30)]
        [TestCase(20, 30, 50)]
        [TestCase(5, 5, 10)]
        public void Add_Test(int a, int b, int expected)
        {
            Calculate c = new Calculate();
            int actual = c.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(100, 20, 80)]
        [TestCase(25, 35, 10)]
        [TestCase(5, -5, 10)]
        public void Sub_Test(int a, int b, int expected)
        {
            Calculate c = new Calculate();
            int actual = c.Subtract(a, b);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase("12345",1)]
        [TestCase("hello123",3)]
        [TestCase("hello23", 2)]

        [TestCase("Hello@123",5)]
        [TestCase("Hello12345",4)]
        [TestCase("hello@12345", 4)]



        public void passwordstrength(string password, int strength)
        {
            Calculate c = new Calculate();
            int actual = c.getpasswordstrength(password);
            Assert.AreEqual(strength, actual);
        }


        public void Division(int x, int y)
        {
            //arrange 
            double actual;
            int expected = 0;
            //act 
            actual = c.Divide(x, y);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }

        [Test]//negative test cases 
        [TestCase(12, 3)]//here it will fail as it passes for negative tasks
        [TestCase(12, 0)]// this will pass 
        public void DivideWithException(int a, int b)
        {
            Assert.Throws<DivideByZeroException>(() => c.Divide(a, b));
        }

        [Test]
        [Ignore("will test it later ")]
        public void Divide()
        {
            double actual = c.Divide(12, 4);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }



    }
}