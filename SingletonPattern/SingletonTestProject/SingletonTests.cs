using System;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingletonPattern;

namespace SingletonTestProject
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void SimpleInstanceTest()
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Assert.AreSame(s1,s2);
        }
        
        [TestMethod]
        public void TestThreadSafety()
        {
            var th1 = new Thread(AddNumbers);
            var th2 = new Thread(AddNumbers);
            th1.Start();
            th2.Start();
            Thread.Sleep(3000);
            Assert.AreEqual(10, Singleton.Instance.Count());
        }

        private void AddNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                Singleton.Instance.Add(i);
            }
        }
    }
}