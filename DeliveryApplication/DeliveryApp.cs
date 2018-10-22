using System;

namespace DeliveryApplication
{
    class DeliveryApp
    {
        public static void Main(string[] args)
        {
            var deliveryApp = new DeliveryApp();
            deliveryApp.PlanDelivery();
        }

        private void PlanDelivery()
        {
            IDeliveryVehicle deliveryBike = new DeliveryCounter(new DeliveryBike());
            IDeliveryVehicle deliveryCar = new DeliveryCounter(new DeliveryCar());
            IDeliveryVehicle deliveryVan = new DeliveryCounter(new DeliveryVan());
            IDeliveryVehicle deliveryTruck = new DeliveryCounter(new DeliveryTruck());
            IDeliveryVehicle locker = new DeliveryCounter(new ParcelLockerAdapter(new ParcelLocker()));
            
            Console.WriteLine("Deliveries:");
            
            MakeDelivery(deliveryBike);
            MakeDelivery(deliveryCar);
            MakeDelivery(deliveryVan);
            MakeDelivery(deliveryTruck);
            MakeDelivery(locker);

            Console.WriteLine("\nTotal parcels delivered (including pick-ups): " + DeliveryCounter.NumberOfDeliveries);
        }

        private void MakeDelivery(IDeliveryVehicle vehicle)
        {
            vehicle.Deliver();
        }
    }
    
    #region Deliver Vehicles

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
    
    #endregion
    
    #region Parcel Locker

    public class ParcelLocker
    {
        public void ProvidePickUp()
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
            _parcelLocker.ProvidePickUp();
        }
    }
    
    #endregion
    
    #region Delivery Counter

    public class DeliveryCounter : IDeliveryVehicle
    {
        private IDeliveryVehicle _vehicle;
        public static int NumberOfDeliveries { get; private set; }

        public DeliveryCounter(IDeliveryVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Deliver()
        {
            _vehicle.Deliver();
            NumberOfDeliveries++;
        }
    }
    
    #endregion
}