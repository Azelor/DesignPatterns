using System;
using System.Collections.Generic;

namespace DeliveryApplication
{
    class DeliveryApp
    {
        public static void Main(string[] args)
        {
            AbstractDeliveryVehicleFactory factory = new CountingDeliveryVehicleFactory();
            
            var deliveryApp = new DeliveryApp();
            deliveryApp.MakeDelivery(factory);
            
            Console.ReadKey(); // Wait for user input
        }

        private void MakeDelivery(AbstractDeliveryVehicleFactory factory)
        {
            IDeliveryVehicle deliveryBike = factory.CreateDeliveryBike();
            IDeliveryVehicle deliveryCar = factory.CreateDeliveryCar();
            IDeliveryVehicle deliveryVan = factory.CreateDeliveryVan();
            IDeliveryVehicle deliveryTruck = factory.CreateDeliveryTruck();
            IDeliveryVehicle parcelLocker = factory.CreateParcelLocker();
            
            var fleetOfDeliveryVehicles = new Fleet();

            fleetOfDeliveryVehicles.Add(deliveryBike);
            fleetOfDeliveryVehicles.Add(deliveryCar);
            fleetOfDeliveryVehicles.Add(deliveryVan);
            fleetOfDeliveryVehicles.Add(deliveryTruck);
            fleetOfDeliveryVehicles.Add(parcelLocker);
            
            Console.WriteLine("Deliveries:");
            MakeDelivery(fleetOfDeliveryVehicles);
            
            var fleetOfTrucks = new Fleet();
            
            IDeliveryVehicle truckOne = factory.CreateDeliveryTruck();
            IDeliveryVehicle truckTwo = factory.CreateDeliveryTruck();
            IDeliveryVehicle truckThree = factory.CreateDeliveryTruck();
            
            fleetOfTrucks.Add(truckOne);
            fleetOfTrucks.Add(truckTwo);
            fleetOfTrucks.Add(truckThree);

            Console.WriteLine("\nDeliveries made by the new fleet of trucks:");
            MakeDelivery(fleetOfTrucks);

            Console.WriteLine("\nTotal parcels delivered (including pick-ups) : " + DeliveryCounter.NumberOfDeliveries);
        }

        private void MakeDelivery(IDeliveryVehicle vehicle)
        {
            vehicle.Deliver();
        }
    }
    
    #region Delivery Vehicles

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
    
    #region Factory

    public abstract class AbstractDeliveryVehicleFactory
    {
        public abstract IDeliveryVehicle CreateDeliveryBike();
        public abstract IDeliveryVehicle CreateDeliveryCar();
        public abstract IDeliveryVehicle CreateDeliveryVan();
        public abstract IDeliveryVehicle CreateDeliveryTruck();
        public abstract IDeliveryVehicle CreateParcelLocker();
    }
    
    public class CountingDeliveryVehicleFactory : AbstractDeliveryVehicleFactory
    {
        public override IDeliveryVehicle CreateDeliveryBike()
        {
            return new DeliveryCounter(new DeliveryBike());
        }
        
        public override IDeliveryVehicle CreateDeliveryCar()
        {
            return new DeliveryCounter(new DeliveryCar());
        }
        
        public override IDeliveryVehicle CreateDeliveryVan()
        {
            return new DeliveryCounter(new DeliveryVan());
        }
        
        public override IDeliveryVehicle CreateDeliveryTruck()
        {
            return new DeliveryCounter(new DeliveryTruck());
        }
        
        public override IDeliveryVehicle CreateParcelLocker()
        {
            return new DeliveryCounter(new ParcelLockerAdapter(new ParcelLocker()));
        }
    }
    
    #endregion
    
    #region Delivery Fleet

    public class Fleet : IDeliveryVehicle
    {
        List<IDeliveryVehicle> _vehicles = new List<IDeliveryVehicle>();

        public void Add(IDeliveryVehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void Deliver()
        {
            foreach (IDeliveryVehicle vehicle in _vehicles)
            {
                vehicle.Deliver();
            }
        }
    }
    
    #endregion
}