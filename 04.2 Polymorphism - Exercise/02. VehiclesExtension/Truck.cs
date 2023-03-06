using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double increasedFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm,tankCapacity)
        {
            FuelConsumptionPerKm += increasedFuelConsumption;
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
                    FuelQuantity += 0.95 * fuel;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
