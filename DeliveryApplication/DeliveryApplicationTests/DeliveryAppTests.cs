using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeliveryApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryApplicationTests
{
    [TestClass]
    public class DeliveryAppTests
    {
        #region Test setup
        
        AbstractDeliveryVehicleFactory factory = new CountingDeliveryVehicleFactory();

        private void MakeDelivery(IDeliveryVehicle vehicle)
        {
            vehicle.Deliver();
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            DeliveryCounter.NumberOfDeliveries = 0; // Resets delivery count after each test
        }
        
        #endregion

        #region Fleet tests
        
        [TestMethod]
        public void FleetTest()
        {
            IDeliveryVehicle deliveryBike = new DeliveryBike();
            IDeliveryVehicle deliveryCar = new DeliveryCar();
            IDeliveryVehicle deliveryVan = new DeliveryVan();
            IDeliveryVehicle deliveryTruck = new DeliveryTruck();
            
            Fleet fleetOfVehicles = new Fleet();
            
            fleetOfVehicles.Add(deliveryBike);
            fleetOfVehicles.Add(deliveryCar);
            fleetOfVehicles.Add(deliveryVan);
            fleetOfVehicles.Add(deliveryTruck);
            
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(fleetOfVehicles);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            var expectedList = new List<string>(new []
            {
                "Bike makes a delivery", 
                "Car makes a delivery", 
                "Van makes a delivery", 
                "Truck makes a delivery"
            });
            
            Assert.AreEqual(consoleEntries.Count, 4, "Delivery count does not match expected deliveries");
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }
        
        [TestMethod]
        public void FleetTest_RandomNumberOfTrucks()
        {
            // Add random amount of trucks to a fleet
            Random random = new Random();
            int randomNumber = random.Next(10, 100);
            Fleet fleetOfTrucks = new Fleet();
            for (int i = 0; i < randomNumber; i++) 
            {
                fleetOfTrucks.Add(new DeliveryTruck());
            }
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(fleetOfTrucks);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            // Create String to compare Console statements with
            var expectedList = new String[randomNumber];
            for(int i = 0 ; i < randomNumber ; i++) expectedList[i] = "Truck makes a delivery";
            
            Assert.AreEqual(consoleEntries.Count, randomNumber, "Delivery count does not match expected deliveries");
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }
        
        [TestMethod]
        public void FleetTest_RandomVehicles()
        {
            // Adds 30 random vehicles to a fleet and makes a delivery
            Random random = new Random();
            Fleet fleetOfRandomVehicles = new Fleet();
            var expectedList = new String[30];
            for (int i = 0; i < 30; i++)
            {
                int caseSwitch = random.Next(1,5);
                switch (caseSwitch)
                {
                    case 1:
                        fleetOfRandomVehicles.Add(new DeliveryBike());
                        expectedList[i] = "Bike makes a delivery";
                        break;
                    case 2:
                        fleetOfRandomVehicles.Add(new DeliveryCar());
                        expectedList[i] = "Car makes a delivery";
                        break;
                    case 3:
                        fleetOfRandomVehicles.Add(new DeliveryVan());
                        expectedList[i] = "Van makes a delivery";
                        break;
                    case 4:
                        fleetOfRandomVehicles.Add(new DeliveryTruck());
                        expectedList[i] = "Truck makes a delivery";
                        break;
                }
            }
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(fleetOfRandomVehicles);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }
        
        [TestMethod]
        public void FleetTest_Empty()
        {
            Fleet fleet = new Fleet();
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(fleet);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            CollectionAssert.AreEqual(consoleEntries, new List<string>(), "No deliveries should be made");
        }
        
        #endregion

        #region Factory tests

        [TestMethod]
        public void FactoryTest()
        {
            IDeliveryVehicle deliveryBike = factory.CreateDeliveryBike();
            IDeliveryVehicle deliveryCar = factory.CreateDeliveryCar();
            IDeliveryVehicle deliveryVan = factory.CreateDeliveryVan();
            IDeliveryVehicle deliveryTruck = factory.CreateDeliveryTruck();
            
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(deliveryBike);
            MakeDelivery(deliveryCar);
            MakeDelivery(deliveryVan);
            MakeDelivery(deliveryTruck);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            var expectedList = new List<string>(new []
            {
                "Bike makes a delivery", 
                "Car makes a delivery", 
                "Van makes a delivery", 
                "Truck makes a delivery"
            });
            
            Assert.AreEqual(consoleEntries.Count, 4, "Delivery count does not match expected deliveries");
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }
        
        [TestMethod]
        public void FactoryTest_RandomVehicles()
        {
            Random random = new Random();
            var expectedList = new String[30];
            StringWriter writer = beginReading(); // begin console capture
            for (int i = 0; i < 30; i++)
            {
                int caseSwitch = random.Next(1,5);
                switch (caseSwitch)
                {
                    case 1:
                        MakeDelivery(factory.CreateDeliveryBike());
                        expectedList[i] = "Bike makes a delivery";
                        break;
                    case 2:
                        MakeDelivery(factory.CreateDeliveryCar());
                        expectedList[i] = "Car makes a delivery";
                        break;
                    case 3:
                        MakeDelivery(factory.CreateDeliveryVan());
                        expectedList[i] = "Van makes a delivery";
                        break;
                    case 4:
                        MakeDelivery(factory.CreateDeliveryTruck());
                        expectedList[i] = "Truck makes a delivery";
                        break;
                }
            }
            List<String> consoleEntries = endReading(writer); // end console capture
            
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }

        #endregion
        
        #region DeliveryCounter tests
        
        [TestMethod]
        public void DeliveryCounterTest()
        {
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(new DeliveryCounter(new DeliveryBike()));
            MakeDelivery(new DeliveryCounter(new DeliveryCar()));
            MakeDelivery(new DeliveryCounter(new DeliveryVan()));
            MakeDelivery(new DeliveryCounter(new DeliveryTruck()));
            List<String> consoleEntries = endReading(writer); // end console capture
            
            Assert.AreEqual(consoleEntries.Count, DeliveryCounter.NumberOfDeliveries, "Delivery count does not match expected deliveries");
        }
        
        [TestMethod]
        public void DeliveryCounterTest_RandomNumberOfCars()
        {
            Random random = new Random();
            int randomNumber = random.Next(10, 100);
            
            StringWriter writer = beginReading(); // begin console capture
            for (int i = 0; i < randomNumber; i++)
            {
                MakeDelivery(new DeliveryCounter(new DeliveryCar()));
            }
            List<String> consoleEntries = endReading(writer); // end console capture
            
            Assert.AreEqual(consoleEntries.Count, DeliveryCounter.NumberOfDeliveries, "Delivery count does not match expected deliveries");
        }
        
        [TestMethod]
        public void DeliveryCounterTest_NoDeliveries()
        {
            Assert.AreEqual(DeliveryCounter.NumberOfDeliveries, 0, "Delivery count does not match expected deliveries");
        }
        
        #endregion
        
        #region Test Template

        [Ignore]
        public void TestTemplate()
        {
            StringWriter writer = beginReading(); // begin console capture
            
            // Setup test here
            
            List<String> consoleEntries = endReading(writer); // end console capture
            
            // Assert here
        }
        
        private StringWriter beginReading()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            return writer;
        }
        
        private List<String> endReading(StringWriter writer)
        {
            writer.Flush();
            var myString = writer.GetStringBuilder().ToString();
            return myString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        
        #endregion
        
        #region Sample Test
        
        [Ignore]
        public void SampleTest()
        {
            StringWriter writer = beginReading(); // begin console capture
            
            // Setup test here
            Console.WriteLine("stuff happens");
            Console.WriteLine("stuff happens again");
            
            List<String> list = endReading(writer); // end console capture
            
            // Assert here
            
            Console.WriteLine("stuff happens again");

            List<String> expectedList = new List<string>();
            expectedList.Add("stuff happens");
            expectedList.Add("stuff happens again");
            expectedList.Add("");
            CollectionAssert.AreEqual(expectedList, list);
        }
        
        #endregion
    }
}