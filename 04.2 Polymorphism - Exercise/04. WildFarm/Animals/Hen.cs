using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightModifier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            string foodType=food.GetType().Name;
            if(foodType=="Fruit"||foodType=="Meat"||foodType=="Seeds"||foodType=="Vegetable")
            {
                FoodEaten += food.Quantity;
                Weight += HenWeightModifier * food.Quantity;
            }
            else
            {
                Console.WriteLine($"Hen does not eat {foodType}!");
            }    
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
