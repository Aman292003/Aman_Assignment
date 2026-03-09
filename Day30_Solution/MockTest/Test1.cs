using Moq;
namespace MockTest

{

    public class checkEmployee
    {
        public virtual Boolean checkemp()
        {
            throw new NotImplementedException();
        }

        public virtual int substract(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

    public class processEmployee
    {
        public bool insertEmployee(checkEmployee emp)
        {
            emp.checkemp();

            return true;
        }
        public int insertEmployee2(checkEmployee emp)
        {

            emp.substract(4, 3);
            return 1;
        }
    }

    [TestClass]
    public class MockTesting
    {
        [TestMethod]
        public void testmethod1()
        {
            Mock<checkEmployee> chk = new Mock<checkEmployee>();
            chk.Setup(x => x.checkemp()).Returns(true);
            chk.Setup(x => x.substract(5, 3)).Returns(1);
            processEmployee objprocess = new processEmployee();
            Assert.AreEqual(objprocess.insertEmployee(chk.Object), true);
            Assert.AreEqual(objprocess.insertEmployee2(chk.Object), 1);

        }
    }
}