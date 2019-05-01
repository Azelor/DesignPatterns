using System;
using System.Collections.Generic;
using System.Linq;
using GoF.Behavioral.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortedList = GoF.Behavioral.Strategy.SortedList;

namespace Tests.Behavioral {

    [TestClass]
    public class StrategyTests
    {
        private class TestSort : ISortStrategy
        {
            public string Result { get; private set; }
            public void Sort(List<string> list)
            {
                Result = "sorted";
            }
        }

        private SortedList list;
        
        [TestInitialize]
        public void Initialize()
        {
            list = new SortedList();
            list.Add("Samual");
            list.Add("Jimmy");
            list.Add("Sandra");
        }

        [TestMethod]
        public void GeneralSortTest() {
            var sort = new TestSort();
            list.SortStrategy = sort;
            list.Sort();
            Assert.AreEqual("sorted", sort.Result);
        }

        [TestMethod]
        public void QuickSortTest()
        {
            list.SortStrategy = new QuickSort();
            list.Sort();
            var expectedList = new List<string> {"Jimmy", "Samual", "Sandra"};
            
            Assert.IsTrue(expectedList.SequenceEqual(list.List));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ShellSortTest()
        {
            list.SortStrategy = new ShellSort();
            list.Sort();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void MergeSortTest()
        {
            list.SortStrategy = new MergeSort();
            list.Sort();
        }
    }
}