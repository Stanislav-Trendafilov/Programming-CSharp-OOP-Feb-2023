using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Animals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight,livingRegion)
        {
            Breed = breed;
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
        public string Breed { get; set; }
    }
}
