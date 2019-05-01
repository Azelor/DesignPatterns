using GoF.Structural.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structural
{
    [TestClass]
    public class FacadeTests
    {
        private Customer customer;
        private int defaultAmount;

        [TestInitialize]
        public void Initialize()
        {
            customer = new Customer("Ann McKinsey");
            defaultAmount = 125000;
        }

        [TestMethod]
        public void CustomerIsEligibleForMortgageTest()
        {
            Mortgage mortgage = new Mortgage();

            bool eligible = mortgage.IsEligible(customer, defaultAmount);
            
            Assert.IsTrue(eligible);
        }

        [TestMethod]
        public void CustomerHasSufficientSavingsTest()
        {
            Bank bank = new Bank();

            bool hasSufficientSavings = bank.HasSufficientSavings(customer, defaultAmount);

            Assert.IsTrue(hasSufficientSavings);
        }

        [TestMethod]
        public void CustomerHasGoodCreditTest()
        {
            Credit credit = new Credit();

            bool hasGoodCredit = credit.HasGoodCredit(customer);

            Assert.IsTrue(hasGoodCredit);
        }

        [TestMethod]
        public void CustomerHasNoBadLoansTest()
        {
            Loan loan = new Loan();

            bool hasNoBadLoans = loan.HasNoBadLoans(customer);

            Assert.IsTrue(hasNoBadLoans);
        }
    }
}