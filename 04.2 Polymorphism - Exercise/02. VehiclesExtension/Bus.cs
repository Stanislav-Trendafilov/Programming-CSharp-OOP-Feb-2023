using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double consumptionWithPeople = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            FuelConsumptionPerKm += consumptionWithPeople;
        }

        public override void Refuel(double fuel)
        {
            try
            {
                FuelIsValid(fuel);
                if (fuel + FuelQuantity > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                }
                else
                {
                    FuelQuantity += fuel;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public void DriveEmpty(double distance)
        {
            double fuelConsumpWithoutPeople = FuelConsumptionPerKm - consumptionWithPeople;

            if (FuelQuantity - fuelConsumpWithoutPeople * distance >= 0)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                FuelQuantity -= fuelConsumpWithoutPeople * distance;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }
    }
}
