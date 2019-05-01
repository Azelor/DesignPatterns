using System.Collections.Generic;
using GoF.Structural.Bridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structural
{
    [TestClass]
    public class BridgeTests
    {
        readonly Customers customers = new Customers("Chicago");
        private List<string> expectedCustomers;

        [TestInitialize]
        public void Initialize()
        {
            customers.Data = new CustomersData();

            expectedCustomers = new List<string>
            {
                "Jim Jones",
                "Samual Jackson",
                "Allen Good",
                "Ann Stills",
                "Lisa Giolani"
            };
        }

        [TestMethod]
        public void ShowRecordTest()
        {
            Assert.AreEqual("Jim Jones", customers.Data.ShowRecord());
        }

        [TestMethod]
        public void ShowAllRecordsTest()
        {
            CollectionAssert.AreEqual(expectedCustomers, customers.Data.ShowAllRecords());
        }

        [TestMethod]
        public void NextRecordTest()
        {
            customers.Data.NextRecord();

            Assert.AreEqual("Samual Jackson", customers.Data.ShowRecord());
        }

        [TestMethod]
        public void NextAndPriorRecordTest()
        {
            customers.Data.NextRecord();

            Assert.AreEqual("Samual Jackson", customers.Data.ShowRecord());

            customers.Data.PriorRecord();

            Assert.AreEqual("Jim Jones", customers.Data.ShowRecord());
        }

        [TestMethod]
        public void PriorRecordTest()
        {
            customers.Data.PriorRecord();

            Assert.AreEqual("Jim Jones", customers.Data.ShowRecord());
        }

        [TestMethod]
        public void AddRecordTest()
        {
            int numberOfCustomers = customers.Data.ShowAllRecords().Count;
            customers.Data.AddRecord("Henry Velasquez");

            Assert.AreEqual(numberOfCustomers + 1, customers.Data.ShowAllRecords().Count);
            Assert.AreEqual("Henry Velasquez", customers.Data.ShowAllRecords()[numberOfCustomers]);
        }

        [TestMethod]
        public void DeleteRecordTest()
        {
            int numberOfCustomers = customers.Data.ShowAllRecords().Count;
            customers.Data.DeleteRecord("Allen Good");

            Assert.AreEqual(numberOfCustomers - 1, customers.Data.ShowAllRecords().Count);
            CollectionAssert.DoesNotContain(customers.Data.ShowAllRecords(), "Allen Good");
        }
    }
}