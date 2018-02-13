using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singelton;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()

        {
            var th1 = new Thread(addNumbers);
            var th2 = new Thread(addNumbers);
            th1.Start();
            th2.Start();
            Thread.Sleep(3000);
            var l = NewSingleton.Instance.List();
            Assert.AreEqual(10, NewSingleton.Instance.Count());
        }

        private void addNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                NewSingleton.Instance.Add(i.ToString());
            } 
        }
    }
}