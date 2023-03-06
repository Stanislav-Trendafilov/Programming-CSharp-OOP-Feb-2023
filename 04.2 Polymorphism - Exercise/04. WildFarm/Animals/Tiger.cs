using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        private const double tigerWeightModifier = 1.0;
        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Meat")
            {
                FoodEaten += food.Quantity;
                Weight += tigerWeightModifier * food.Quantity;
            }
            else
            {
                Console.WriteLine($"Tiger does not eat {foodType}!");
            }
        }
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
