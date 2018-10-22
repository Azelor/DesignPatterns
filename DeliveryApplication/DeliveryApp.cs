using System;

namespace DeliveryApplication
{
    class DeliveryApp
    {
        public static void Main(string[] args) // main method
        {
            var deliveryApp = new DeliveryApp();
            deliveryApp.PlanDelivery();
        }

        private void PlanDelivery()
        {
            IDeliveryVehicle deliveryBike = new DeliveryBike();
            IDeliveryVehicle deliveryCar = new DeliveryCar();
            IDeliveryVehicle deliveryVan = new DeliveryVan();
            IDeliveryVehicle deliveryTruck = new DeliveryTruck();
            IDeliveryVehicle locker = new ParcelLockerAdapter(new ParcelLocker());
            
            Console.WriteLine("Deliveries:");
            
            MakeDelivery(deliveryBike);
            MakeDelivery(deliveryCar);
            MakeDelivery(deliveryVan);
            MakeDelivery(deliveryTruck);
            MakeDelivery(locker);
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
    
    public class ParcelLocker
    {
        public void ProvidePickup()
        {
            Console.WriteLine("Package is picked up from a parcel locker");
        }
    }
    
    public class ParcelLockerAdapter : IDeliveryVehicle
    {
        private ParcelLocker _parcelLocker;

        public ParcelLockerAdapter(ParcelLocker parcelLocker)
        {
            _parcelLocker = parcelLocker;
        }

        public void Deliver()
        {
            _parcelLocker.ProvidePickup();
        }
    }
}