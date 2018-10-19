using System;

namespace DeliveryApplication
{
    class DeliveryApp
    {
        public static void Main(string[] args) // main method
        {
            var deliveryApp = new DeliveryApp();
            deliveryApp.BeginOperation();
        }

        private void BeginOperation()
        {
            IDeliveryVehicle deliveryBike = new DeliveryBike();
            IDeliveryVehicle deliveryCar = new DeliveryCar();
            IDeliveryVehicle deliveryVan = new DeliveryVan();
            IDeliveryVehicle deliveryTruck = new DeliveryTruck();
           
            Console.WriteLine("Deliveries:");
           
            MakeDelivery(deliveryBike);
            MakeDelivery(deliveryCar);
            MakeDelivery(deliveryVan);
            MakeDelivery(deliveryTruck);
        }

        private void MakeDelivery(IDeliveryVehicle vehicle)
        {
            vehicle.Deliver();
        }
    }

    public interface IDeliveryVehicle
    {
        void Deliver();
    }

    public class DeliveryBike : IDeliveryVehicle
    {
        public void Deliver()
        {
            Console.WriteLine("Bike makes a delivery");
        }
    }
   
    public class DeliveryCar : IDeliveryVehicle
    {
        public void Deliver()
        {
            Console.WriteLine("Car makes a delivery");
        }
    }
   
    public class DeliveryVan : IDeliveryVehicle
    {
        public void Deliver()
        {
            Console.WriteLine("Van makes a delivery");
        }
    }
   
    public class DeliveryTruck : IDeliveryVehicle
    {
        public void Deliver()
        {
            Console.WriteLine("Truck makes a delivery");
        }
    }
}