using GoF.Behavioral.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Behavioral
{
    [TestClass]
    public class StateTests
    {
        private Account account;

        [TestInitialize]
        public void Initialize()
        {
            account = new Account("Jim Johnson");
        }

        [TestMethod]
        public void DepositTest() {
            account.Deposit(500.0);

            Assert.AreEqual(account.Balance, 500.0);
        }

        [TestMethod]
        public void WithdrawalTest()
        {
            account.Withdraw(100.0);

            Assert.AreEqual(account.Balance, -100.0);
        }

        [TestMethod]
        public void PayInterestIfSilverStateTest()
        {
            account.Deposit(500.0);
            account.PayInterest();

            Assert.AreEqual(account.State.GetType(), typeof(SilverState));
            Assert.AreEqual(account.Balance, 500.0);
        }

        [TestMethod]
        public void PayInterestIfGoldenStateTest()
        {
            account.Deposit(10000.0);
            account.PayInterest();

            Assert.AreEqual(account.State.GetType(), typeof(GoldState));
            Assert.AreEqual(account.Balance, 10500.0);
        }

        [TestMethod]
        public void ChangeStateFromSilverToGolden()
        {
            Assert.AreEqual(account.State.GetType(), typeof(SilverState));

            account.Deposit(10000.0);

            Assert.AreEqual(account.State.GetType(), typeof(GoldState));
        }

        [TestMethod]
        public void ChangeStateFromSilverToRed()
        {
            Assert.AreEqual(account.State.GetType(), typeof(SilverState));

            account.Withdraw(500);

            Assert.AreEqual(account.State.GetType(), typeof(RedState));
        }
    }
}