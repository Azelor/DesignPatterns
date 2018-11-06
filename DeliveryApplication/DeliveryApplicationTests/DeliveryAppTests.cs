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
        public void TestFleet()
        {
            IDeliveryVehicle deliveryBike = factory.CreateDeliveryBike();
            IDeliveryVehicle deliveryCar = factory.CreateDeliveryCar();
            IDeliveryVehicle deliveryVan = factory.CreateDeliveryVan();
            IDeliveryVehicle deliveryTruck = factory.CreateDeliveryTruck();
            IDeliveryVehicle locker = factory.CreateParcelLocker();
            
            Fleet fleetOfVehicles = new Fleet();
            
            fleetOfVehicles.Add(deliveryBike);
            fleetOfVehicles.Add(deliveryCar);
            fleetOfVehicles.Add(deliveryVan);
            fleetOfVehicles.Add(deliveryTruck);
            fleetOfVehicles.Add(locker);
            
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(fleetOfVehicles);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            var expectedList = new List<string>(new []
            {
                "Bike makes a delivery", 
                "Car makes a delivery", 
                "Van makes a delivery", 
                "Truck makes a delivery", 
                "Package is picked up from a parcel locker"
            });
            
            Assert.AreEqual(consoleEntries.Count, 5, "Delivery count does not match expected deliveries");
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }
        
        [TestMethod]
        public void TestFleet_RandomNumberOfTrucks()
        {
            // Add random amount of trucks to a fleet
            Random random = new Random();
            int randomNumber = random.Next(10, 100);
            Fleet fleetOfTrucks = new Fleet();
            for (int i = 0; i < randomNumber; i++) 
            {
                fleetOfTrucks.Add(factory.CreateDeliveryTruck());
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
        public void TestFleet_RandomVehicles()
        {
            // Adds 30 random vehicles to a fleet and makes a delivery
            Random random = new Random();
            Fleet fleetOfRandomVehicles = new Fleet();
            var expectedList = new String[30];
            for (int i = 0; i < 30; i++)
            {
                int caseSwitch = random.Next(1,6);
                switch (caseSwitch)
                {
                    case 1:
                        fleetOfRandomVehicles.Add(factory.CreateDeliveryBike());
                        expectedList[i] = "Bike makes a delivery";
                        break;
                    case 2:
                        fleetOfRandomVehicles.Add(factory.CreateDeliveryCar());
                        expectedList[i] = "Car makes a delivery";
                        break;
                    case 3:
                        fleetOfRandomVehicles.Add(factory.CreateDeliveryVan());
                        expectedList[i] = "Van makes a delivery";
                        break;
                    case 4:
                        fleetOfRandomVehicles.Add(factory.CreateDeliveryTruck());
                        expectedList[i] = "Truck makes a delivery";
                        break;
                    case 5:
                        fleetOfRandomVehicles.Add(factory.CreateParcelLocker());
                        expectedList[i] = "Package is picked up from a parcel locker";
                        break;
                }
            }
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(fleetOfRandomVehicles);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }
        
        [TestMethod]
        public void TestFleet_Empty()
        {
            Fleet fleet = new Fleet();
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(fleet);
            List<String> consoleEntries = endReading(writer); // end console capture
            
            CollectionAssert.AreEqual(consoleEntries, new List<string>(), "No deliveries should be made");
        }
        
        #endregion
        
        #region DeliveryCounter tests
        
        [TestMethod]
        public void TestDeliveryCounter()
        {
            StringWriter writer = beginReading(); // begin console capture
            MakeDelivery(new DeliveryCounter(new DeliveryBike()));
            MakeDelivery(new DeliveryCounter(new DeliveryCar()));
            MakeDelivery(new DeliveryCounter(new DeliveryVan()));
            MakeDelivery(new DeliveryCounter(new DeliveryTruck()));
            MakeDelivery(new DeliveryCounter(new ParcelLockerAdapter(new ParcelLocker())));
            List<String> consoleEntries = endReading(writer); // end console capture
            
            Assert.AreEqual(consoleEntries.Count, DeliveryCounter.NumberOfDeliveries, "Delivery count does not match expected deliveries");
        }
        
        [TestMethod]
        public void TestDeliveryCounter_RandomNumberOfCars()
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
        public void TestDeliveryCounter_NoDeliveries()
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