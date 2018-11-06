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
        AbstractDeliveryVehicleFactory factory = new CountingDeliveryVehicleFactory();
        static DeliveryAppTests deliveryApp = new DeliveryAppTests();
//        deliveryApp.PlanDelivery(factory);


        [TestInitialize]
        public void Initialize()
        {
//            AbstractDeliveryVehicleFactory factory = new CountingDeliveryVehicleFactory();
            
//            var deliveryApp = new DeliveryAppTests();
//            deliveryApp.PlanDelivery(factory);
            
            IDeliveryVehicle deliveryBike = factory.CreateDeliveryBike();
        }
        
//        public void PlanDelivery(AbstractDeliveryVehicleFactory factory)
//        {
//            IDeliveryVehicle deliveryBike = factory.CreateDeliveryBike();
//            IDeliveryVehicle deliveryCar = factory.CreateDeliveryCar();
//            IDeliveryVehicle deliveryVan = factory.CreateDeliveryVan();
//            IDeliveryVehicle deliveryTruck = factory.CreateDeliveryTruck();
//            IDeliveryVehicle locker = factory.CreateParcelLocker();
//            
//            Fleet fleetOfVehicles = new Fleet();
//            
//            fleetOfVehicles.Add(deliveryBike);
//            fleetOfVehicles.Add(deliveryCar);
//            fleetOfVehicles.Add(deliveryVan);
//            fleetOfVehicles.Add(deliveryTruck);
//            fleetOfVehicles.Add(locker);
//            
//            Console.WriteLine("Deliveries:");
//            
//            MakeDelivery(fleetOfVehicles);
//            
//            var fleetOfTrucks = new Fleet();
//            
//            IDeliveryVehicle truckOne = factory.CreateDeliveryTruck();
//            IDeliveryVehicle truckTwo = factory.CreateDeliveryTruck();
//            IDeliveryVehicle truckThree = factory.CreateDeliveryTruck();
//            
//            fleetOfTrucks.Add(truckOne);
//            fleetOfTrucks.Add(truckTwo);
//            fleetOfTrucks.Add(truckThree);
//
//            Console.WriteLine("\nDeliveries made by the new fleet of trucks:");
//            MakeDelivery(fleetOfTrucks);
//            
//            Console.WriteLine("\nTotal parcels delivered (including pick-ups): " + DeliveryCounter.NumberOfDeliveries);
//        }
//        
        private void MakeDelivery(IDeliveryVehicle vehicle)
        {
//            Console.WriteLine(vehicle.ToString());
            vehicle.Deliver();
        }
//        
//        [TestMethod]
//        public void TestMethod1()
//        {
//            
////            AbstractDeliveryVehicleFactory factory = new CountingDeliveryVehicleFactory();
////            
////            var deliveryApp = new DeliveryAppTests();
//////            deliveryApp.PlanDelivery(factory);
//        }

        private List<String> originalConsoleReader()
        {
            List<String> printedLines = new List<string>();
            var originalConsoleOut = Console.Out; // preserve the original stream
            var writer = new StringWriter();
          
                Console.SetOut(writer);

                // Your Console writing stuff goes here
            
                Console.WriteLine("stuff happens");
                Console.WriteLine("stuff happens again");

                printedLines.Add(writer.ToString());

                writer.Flush(); // when you're done, make sure everything is written out

                var myString = writer.GetStringBuilder().ToString();
                printedLines = myString.Split(System.Environment.NewLine).ToList();
                Console.WriteLine(printedLines);

            

            Console.SetOut(originalConsoleOut); // restore Console.Out

            Console.WriteLine(originalConsoleOut);

            return printedLines;
        }
        
       
        
        [TestMethod]
        public void TestMethod2()
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
            
            Console.WriteLine("Deliveries:");
            
            List<String> printedLines = new List<string>();
            var originalConsoleOut = Console.Out; // preserve the original stream
            var myString = "";
            using(var writer = new StringWriter())
            {
                Console.SetOut(writer);

//                Console.WriteLine("some stuff"); // or make your DLL calls :)

                MakeDelivery(fleetOfVehicles);
                printedLines.Add(writer.ToString());

                writer.Flush(); // when you're done, make sure everything is written out

                myString = writer.GetStringBuilder().ToString();
                printedLines = myString.Split(System.Environment.NewLine).ToList();
                Console.WriteLine(printedLines);

//                Console.WriteLine(myString);
            }

            Console.SetOut(originalConsoleOut); // restore Console.Out

//            Console.WriteLine(originalConsoleOut);
            Console.WriteLine(myString);
            Console.WriteLine(printedLines);
            
//            Process compiler = new Process();
//            compiler.StartInfo.FileName = "csc.exe";
//            compiler.StartInfo.Arguments = "/r:System.dll /out:sample.exe stdstr.cs";
//            compiler.StartInfo.UseShellExecute = false;
//            compiler.StartInfo.RedirectStandardOutput = true;
//            compiler.Start();    
//
//
//            
//            compiler.WaitForExit();
//            StringWriter sw = new StringWriter();
//            Console.SetOut(sw);
//            
//            
//            Console.WriteLine(myString);

//            string consoleOutput = sw.ToString();
//            consoleOutput = consoleOutput + "kek";
        }
        
        [TestMethod]
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
            return myString.Split(Environment.NewLine).ToList();
        }
        
        [TestMethod]
        public void TestTemplate()
        {
            StringWriter writer = beginReading(); // begin console capture
            
            // Setup test here
            
            List<String> consoleEntries = endReading(writer); // end console capture
            
            // Assert here
        }
        
        
        
    }
    
    
}