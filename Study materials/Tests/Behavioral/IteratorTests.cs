using GoF.Behavioral.Iterator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests.Behavioral {
    [TestClass] public class IteratorTests {
        private Collection collection;
        [TestInitialize] public void Initialize() {

            collection = new Collection();
            collection.Add(new Item("Item 0"));
            collection.Add(new Item("Item 1"));
            collection.Add(new Item("Item 2"));
            collection.Add(new Item("Item 3"));
            collection.Add(new Item("Item 4"));
            collection.Add(new Item("Item 5"));
            collection.Add(new Item("Item 6"));
            collection.Add(new Item("Item 7"));
            collection.Add(new Item("Item 8"));
        }

        [TestMethod] public void GetFirstElementTest() {
            collection.First();
            Assert.AreEqual("Item 0", collection.CurrentItem()
                .Name);
        }


        [TestMethod] public void IterateElementsTest() {

            collection.Step = 2;

            var i = 0;
            var j = 0;
            for (collection.First(); !collection.IsDone; collection.Next()) {
                Assert.AreEqual($"Item {i}", collection.CurrentItem()
                    .Name);
                i += 2;
                j++;
            }
            Assert.AreEqual(10, i);
            Assert.AreEqual(5, j);
        }

        [TestMethod] public void CurrentElementIsNullAfterIterationTest() {

            collection.Step = 1;
            var j = 0;
            for (collection.First(); !collection.IsDone; collection.Next()) { j++; }
            Assert.IsNull(collection.CurrentItem());
            Assert.AreEqual(9, j);
        }

    }
}