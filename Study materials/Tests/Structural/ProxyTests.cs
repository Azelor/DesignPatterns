using GoF.Structural.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structural
{
    [TestClass]
    public class ProxyTests
    {
        private MathProxy proxy;

        [TestInitialize]
        public void Initialize()
        {
            proxy = new MathProxy();
        }

        [TestMethod]
        public void ProxyAddTest()
        {
            double result = proxy.Add(6, 2);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void ProxySubtractTest()
        {
            double result = proxy.Sub(6, 2);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void ProxyMultiplyTest()
        {
            double result = proxy.Mul(6, 2);

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void ProxyDivideTest()
        {
            double result = proxy.Div(6, 2);

            Assert.AreEqual(3, result);
        }
    }
}