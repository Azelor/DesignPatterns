using System.Collections.Generic;

namespace GoF.Creational.Builder
{
    class Vehicle
    {
        public string VehicleType { get; }
        private readonly Dictionary<string, string> parts = new Dictionary<string, string>();

        public Vehicle(string vehicleType)
        {
            VehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }
    }
}