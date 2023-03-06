using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        private const double CatWeightModifier = 0.3;
        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Meat" || foodType == "Vegetable")
            {
                FoodEaten += food.Quantity;
                Weight += CatWeightModifier * food.Quantity;
            }
            else
            {
                Console.WriteLine($"Cat does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
