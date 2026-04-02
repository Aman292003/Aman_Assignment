using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MsTestdemo
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");
            Balance -= amount;
        }
    }
    [TestFixture]
    public class BankAccounttests
    {
        [Test]
        public void Deposit_shouldIncrease()
        {
            var account = new BankAccount();
            account.Deposit(100);
            Assert.AreEqual(100, account.Balance);
        }
        [Test]
        public void Withdraw_shouldDecrease()
        {
            var account = new BankAccount();
            account.Deposit(100);
            account.Withdraw(50);
            Assert.AreEqual(50, account.Balance);
        }
        [Test]
        public void Withdraw_shoulldThrowException_insufficent()
        {
            var account = new BankAccount();

            account.Withdraw(50);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100));
        }
    }
}

