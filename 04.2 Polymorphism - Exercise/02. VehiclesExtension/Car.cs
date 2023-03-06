using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double incresedFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            FuelConsumptionPerKm += incresedFuelConsumption;
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
    }
}
