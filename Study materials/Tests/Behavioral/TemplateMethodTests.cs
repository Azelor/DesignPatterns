using System.Collections.Generic;
using System.Linq;
using GoF.Behavioral.TemplateMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Behavioral {

    [TestClass]
    public class TemplateMethodTests {

        [TestMethod]
        public void SelectCategoriesTest()
        {
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            List<string> expectedList = new List<string> { "Fruit", "Bakery", "Dairy" };
            
            Assert.IsTrue(expectedList.SequenceEqual(daoCategories.results));
        }

        [TestMethod]
        public void SelectProductsTest()
        {
            DataAccessObject daoProducts = new Products();
            daoProducts.Run();

            List<string> expectedList = new List<string>
            {
                "Apples", "Oranges", "Bananas", "White Bread",
                "Whole Grain", "Multi Grain", "Milk", "Yoghurt", "Cheese"
            };

            Assert.IsTrue(expectedList.SequenceEqual(daoProducts.results));
        }
    }
}