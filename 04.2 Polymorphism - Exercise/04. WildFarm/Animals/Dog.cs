using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        private const double dogWeightModifier = 0.4;
        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Meat")
            {
                FoodEaten += food.Quantity;
                Weight += dogWeightModifier * food.Quantity;
            }
            else
            {
                Console.WriteLine($"Dog does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
