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

        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
            FuelConsumptionPerKm += increasedFuelConsumption;
        }
        public override void Refuel(double fuel)
        {
            FuelQuantity += 0.95 * fuel;
        }
    }
}
