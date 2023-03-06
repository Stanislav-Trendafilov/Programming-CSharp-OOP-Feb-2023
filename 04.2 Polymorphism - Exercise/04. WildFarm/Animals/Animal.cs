using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }


        public abstract void Feed(Food food);

        public abstract string ProduceSound();

    }
}
