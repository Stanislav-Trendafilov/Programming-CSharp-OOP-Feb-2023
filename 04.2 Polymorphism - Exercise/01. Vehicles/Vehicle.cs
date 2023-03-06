using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - FuelConsumptionPerKm * distance >= 0)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                FuelQuantity -= FuelConsumptionPerKm * distance;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public abstract void Refuel(double fuel);

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }

    }
}
