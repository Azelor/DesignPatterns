using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoF.Creational.AbstractFactory;

namespace Tests.Creational
{
    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void MainTest()
        {
            // TODO
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Assert.AreEqual(1,1);
        }
    }

    [TestClass]
    abstract class TestContinentFactory : ContinentFactory
    {
            public override Herbivore CreateHerbivore()
            {
                return new Wildebeest();
            }
            public override Carnivore CreateCarnivore()
            {
                return new Lion();
            }
    }
}
