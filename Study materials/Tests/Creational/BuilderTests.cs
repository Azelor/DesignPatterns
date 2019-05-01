using GoF.Creational.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Creational
{
    [TestClass]
    public class BuilderTests
    {
        VehicleBuilder builder;
        readonly Shop shop = new Shop();

        [TestMethod]
        public void CarBuilderTest()
        {
            builder = new CarBuilder();
            shop.Construct(builder);

            Assert.AreEqual(builder.Vehicle.VehicleType, "Car");
            Assert.AreEqual(builder.Vehicle["frame"], "Car Frame");
            Assert.AreEqual(builder.Vehicle["engine"], "2500 cc");
            Assert.AreEqual(builder.Vehicle["wheels"], "4");
            Assert.AreEqual(builder.Vehicle["doors"], "4");
        }

        [TestMethod]
        public void MotorCycleBuilderTest()
        {
            builder = new MotorCycleBuilder();
            shop.Construct(builder);

            Assert.AreEqual(builder.Vehicle.VehicleType, "MotorCycle");
            Assert.AreEqual(builder.Vehicle["frame"], "MotorCycle Frame");
            Assert.AreEqual(builder.Vehicle["engine"], "500 cc");
            Assert.AreEqual(builder.Vehicle["wheels"], "2");
            Assert.AreEqual(builder.Vehicle["doors"], "0");
        }

        [TestMethod]
        public void ScooterBuilderTest()
        {
            builder = new ScooterBuilder();
            shop.Construct(builder);

            Assert.AreEqual(builder.Vehicle.VehicleType, "Scooter");
            Assert.AreEqual(builder.Vehicle["frame"], "Scooter Frame");
            Assert.AreEqual(builder.Vehicle["engine"], "50 cc");
            Assert.AreEqual(builder.Vehicle["wheels"], "2");
            Assert.AreEqual(builder.Vehicle["doors"], "0");
        }
    }
}
