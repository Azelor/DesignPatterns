using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        static DeliveryAppTests deliveryApp = new DeliveryAppTests();

        private void MakeDelivery(IDeliveryVehicle vehicle)
        {
            vehicle.Deliver();
        }
        
        #endregion

        [TestMethod]
        public void TestFleetOfVehicles()
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
        public void TestFleetOfTrucksWithRandomNumber()
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
            MakeDelivery(fleetOfTrucks); // Make delivery with the fleet
            List<String> consoleEntries = endReading(writer); // end console capture
            
            // Create String to compare Console statements with
            var expectedList = new String[randomNumber];
            for(int i = 0 ; i < randomNumber ; i++) expectedList[i] = "Truck makes a delivery";
            
            Assert.AreEqual(consoleEntries.Count, randomNumber, "Delivery count does not match expected deliveries");
            CollectionAssert.AreEqual(consoleEntries, expectedList, "Deliveries don't match expected deliveries");
        }
        
        
        
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