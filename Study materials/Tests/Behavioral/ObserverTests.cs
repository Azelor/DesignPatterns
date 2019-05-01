using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoF.Behavioral.Observer;

namespace Tests.Behavioral
{
    [TestClass]
    public class ObserverTests
    {
        private IBM ibm;
        private Investor sorros;
        private Investor berkshire;

        [TestInitialize]
        public void Initialize()
        {
            ibm = new IBM("IBM", 120.00);
            sorros = new Investor("Sorros");
            berkshire = new Investor("Berkshire");
        }

        [TestMethod]
        public void AttachObserversTest()
        {
            ibm.Attach(sorros);
            ibm.Attach(berkshire);

            Assert.AreEqual(ibm.investors[0], sorros);
            Assert.AreEqual(ibm.investors[1], berkshire);
        }

        [TestMethod]
        public void DetachObserversTest()
        {
            ibm.investors.Add(sorros);
            ibm.investors.Add(berkshire);

            Assert.AreEqual(ibm.investors[0], sorros);
            Assert.AreEqual(ibm.investors[1], berkshire);
        }

        [TestMethod]
        public void CountNotificationsTest()
        {
            ibm.Attach(sorros);
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            Assert.AreEqual(sorros.notifications.Count, 4);
        }

        [TestMethod]
        public void NotifyInvestorsTest()
        {
            var firstPrice = 120.10;
            var secondPrice = 121.00;

            ibm.Attach(sorros);
            ibm.Attach(berkshire);
            ibm.Price = firstPrice;
            ibm.Price = secondPrice;

            Assert.AreEqual(sorros.notifications[0], $"Notified Sorros of IBM's change to {firstPrice.ToString("C")}");
            Assert.AreEqual(sorros.notifications[1], $"Notified Sorros of IBM's change to {secondPrice.ToString("C")}");
            Assert.AreEqual(berkshire.notifications[0], $"Notified Berkshire of IBM's change to {firstPrice.ToString("C")}");
            Assert.AreEqual(berkshire.notifications[1], $"Notified Berkshire of IBM's change to {secondPrice.ToString("C")}");
        }
    }
}