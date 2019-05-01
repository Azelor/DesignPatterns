using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoF.Behavioral.Memento;

namespace Tests.Behavioral
{
    [TestClass]
    public class MementoTests
    {
        private SalesProspect s;
        private ProspectMemory m;

        [TestInitialize]
        public void Initialize()
        {
            s = new SalesProspect
            {
                Name = "Noel van Halen",
                Phone = "(412) 256-0990",
                Budget = 25000.0
            };
        }

        [TestMethod]
        public void SaveMementoTest()
        {
            m = new ProspectMemory
            {
                Memento = s.SaveMemento()
            };

            Assert.AreEqual(m.Memento.Name, s.Name);
            Assert.AreEqual(m.Memento.Phone, s.Phone);
            Assert.AreEqual(m.Memento.Budget, s.Budget);
        }

        [TestMethod]
        public void RestoreMementoTest()
        {
            var savedMemory = new ProspectMemory
            {
                Memento = new Memento("Stored Name", "(412) 123-4567", 9000.0)
            };

            s.RestoreMemento(savedMemory.Memento);

            Assert.AreEqual(s.Name, "Stored Name");
            Assert.AreEqual(s.Phone, "(412) 123-4567");
            Assert.AreEqual(s.Budget, 9000.0);
        }

        [TestMethod]
        public void SaveAndRestoreMementoTest()
        {
            m = new ProspectMemory
            {
                Memento = s.SaveMemento()
            };

            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            Assert.AreNotEqual(m.Memento.Name, s.Name);
            Assert.AreNotEqual(m.Memento.Phone, s.Phone);
            Assert.AreNotEqual(m.Memento.Budget, s.Budget);

            s.RestoreMemento(m.Memento);

            Assert.AreEqual(m.Memento.Name, s.Name);
            Assert.AreEqual(m.Memento.Phone, s.Phone);
            Assert.AreEqual(m.Memento.Budget, s.Budget);
        }
    }
}