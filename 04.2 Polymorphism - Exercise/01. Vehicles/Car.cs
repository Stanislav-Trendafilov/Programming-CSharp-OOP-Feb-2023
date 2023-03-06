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

        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
            FuelConsumptionPerKm += incresedFuelConsumption;
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
    }
}
