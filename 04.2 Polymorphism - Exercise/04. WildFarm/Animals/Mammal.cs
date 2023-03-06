using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Animals
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
        public string LivingRegion { get; set; }
    }
}
