using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumptionPerKm { get; set; }

        public double TankCapacity { get; set; }

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

        public void FuelIsValid(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }

    }
}
