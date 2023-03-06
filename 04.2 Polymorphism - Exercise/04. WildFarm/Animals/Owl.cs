using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight,  wingSize)
        {
        }
        private const double OwlWeightModifier = 0.25;
        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Meat")
            {
                FoodEaten += food.Quantity;
                Weight += OwlWeightModifier * food.Quantity;
            }
            else
            {
                Console.WriteLine($"Owl does not eat {foodType}!");
            }
        }


        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
