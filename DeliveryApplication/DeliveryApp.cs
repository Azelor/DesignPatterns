using System;

namespace DeliveryApplication
{
    class DeliveryApp
    {
        public static void Main(string[] args)
        {
            var deliveryApp = new DeliveryApp();
            deliveryApp.MakeDelivery();
        }

        private void MakeDelivery()
        {
            // TODO: Create vehicles

            Console.WriteLine("Deliveries:");
            
            // TODO: Make deliveries
            
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
    
    // TODO: Create vehicle classes that implement IDeliveryVehicle
    
}