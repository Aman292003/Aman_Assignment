namespace TDD
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
    public class BankAccountTests
    {
        [Test]
        public void Deposit_ShouldIncreaseBalance()
        {
            var account = new BankAccount();
            account.Deposit(100);

            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        public void Withdraw_ShouldDecreaseBalance()
        {
            var account = new BankAccount();
            account.Deposit(100);
            account.Withdraw(50);

            Assert.AreEqual(50, account.Balance);
        }

        [Test]
        public void Withdraw_ShouldThrowException_WhenInsufficient()
        {
            var account = new BankAccount();

            Assert.Throws<InvalidOperationException>(() => account.Withdraw(50));
        }
    }
}