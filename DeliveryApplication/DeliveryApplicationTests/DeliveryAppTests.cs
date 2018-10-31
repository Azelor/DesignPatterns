using System;
using DeliveryApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryApplicationTests
{
    [TestClass]
    public class DeliveryAppTests
    {
        [TestInitialize()]
        public void Initialize()
        {
            AbstractDeliveryVehicleFactory factory = new CountingDeliveryVehicleFactory();
            
            var deliveryApp = new DeliveryAppTests();
        }
        
        public void PlanDelivery(AbstractDeliveryVehicleFactory factory)
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
            
            MakeDelivery(fleetOfVehicles);
            
            var fleetOfTrucks = new Fleet();
            
            IDeliveryVehicle truckOne = factory.CreateDeliveryTruck();
            IDeliveryVehicle truckTwo = factory.CreateDeliveryTruck();
            IDeliveryVehicle truckThree = factory.CreateDeliveryTruck();
            
            fleetOfTrucks.Add(truckOne);
            fleetOfTrucks.Add(truckTwo);
            fleetOfTrucks.Add(truckThree);

            Console.WriteLine("\nDeliveries made by the new fleet of trucks:");
            MakeDelivery(fleetOfTrucks);
            
            Console.WriteLine("\nTotal parcels delivered (including pick-ups): " + DeliveryCounter.NumberOfDeliveries);
        }
        
        private void MakeDelivery(IDeliveryVehicle vehicle)
        {
            vehicle.Deliver();
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            AbstractDeliveryVehicleFactory factory = new CountingDeliveryVehicleFactory();
            
            var deliveryApp = new DeliveryAppTests();
            deliveryApp.PlanDelivery(factory);
        }
    }
}