using GoF.Behavioral.Interpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests.Behavioral {
    [TestClass] public class InterpreterTests {

        [TestMethod]
        public void NineToArabicTest() {
            Assert.AreEqual(9, new RomanNumber("IX").ToArabic());
        }
        [TestMethod]
        public void ElevenToArabicTest() {
            Assert.AreEqual(11, new RomanNumber("XI").ToArabic());
        }
        [TestMethod]
        public void YearToArabicTest()
        {
            Assert.AreEqual(1928, new RomanNumber("MCMXXVIII").ToArabic());
        }
    }
}