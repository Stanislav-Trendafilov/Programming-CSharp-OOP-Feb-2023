using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
       
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        private const double MouseWeightModifier = 0.1;
        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Fruit" || foodType == "Vegetable")
            {
                FoodEaten += food.Quantity;
                Weight += MouseWeightModifier * food.Quantity;
            }
            else
            {
                Console.WriteLine($"Mouse does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
