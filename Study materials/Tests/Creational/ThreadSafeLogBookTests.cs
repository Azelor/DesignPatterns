using System.Collections.Generic;
using System.Threading;
using GoF.Aids;
using GoF.Creational.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests.Creational {
    [TestClass] public class ThreadSafeLogBookTests {
        private List<string> list;

        [TestInitialize] public void Initialize() { list = new List<string>(); }

        [TestMethod] public void IsSameInstanceTest() {
            var logBook = ThreadSafeLogBook.Create(list);
            for (var i = 0; i < GetRandom.Int32(3, 10); i++) {
                Assert.AreSame(logBook, ThreadSafeLogBook.Create(list));
            }
        }
        [TestMethod] public void TwoThreadsAreLoggingTest() {
            var thread1 = StartThread(1, 5);
            var thread2 = StartThread(6, 10);
            do { Thread.Sleep(1); } while (thread1.IsAlive || thread2.IsAlive);
            Assert.AreEqual(10, list.Count);
        }

        private Thread StartThread(int fromInt, int toInt) {
            var logger = new Logger(fromInt, toInt, list);
            var thread = new Thread(logger.LogNumbers);
            thread.Start();
            return thread;
        }
        private class Logger {
            private readonly ThreadSafeLogBook logBook;
            private readonly int fromInt;
            private readonly int toInt;
            public Logger(int f, int t, List<string> l) {
                logBook = ThreadSafeLogBook.Create(l);
                fromInt = f;
                toInt = t;
            }
            public void LogNumbers() {
                for (var i = fromInt; i <= toInt; i++) {
                    Thread.Sleep(1);
                    logBook.Write(i.ToString());
                }
            }
        }
    }
}

