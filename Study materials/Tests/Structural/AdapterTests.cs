using GoF.Structural.Adapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structural
{
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public void WaterCompoundTest()
        {
            Compound water = new RichCompound("Water");

            Assert.AreEqual("H2O", water.MolecularFormula);
            Assert.AreEqual(18.0150, water.MolecularWeight);
            Assert.AreEqual(0.0f, water.MeltingPoint);
            Assert.AreEqual(100.0f, water.BoilingPoint);
        }

        [TestMethod]
        public void BenzeneCompoundTest()
        {
            Compound benzene = new RichCompound("Benzene");

            Assert.AreEqual("C6H6", benzene.MolecularFormula);
            Assert.AreEqual(78.1134, benzene.MolecularWeight);
            Assert.AreEqual(5.5f, benzene.MeltingPoint);
            Assert.AreEqual(80.1f, benzene.BoilingPoint);
        }

        [TestMethod]
        public void EthanolCompoundTest()
        {
            Compound ethanol = new RichCompound("Ethanol");

            Assert.AreEqual("C2H5OH", ethanol.MolecularFormula);
            Assert.AreEqual(46.0688, ethanol.MolecularWeight);
            Assert.AreEqual(-114.1f, ethanol.MeltingPoint);
            Assert.AreEqual(78.3f, ethanol.BoilingPoint);
        }
    }
}
