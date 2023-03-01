using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
	public class Topping
	{
		private double baseCaloriesPerGram = 2;

		private string toppingType;
		private int grams;

        public Topping(string toppingType, int grams)
        {
            ToppingType = toppingType;
            Grams = grams;
        }

        public int Grams
		{
			get => grams;
			set
			{ 
				if (value < 1||value>50)
				{
					throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
				}
				grams = value;
			}
		}

		public string ToppingType
		{
			get => toppingType;
			set
			{
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
			}
		}
		public double CaloriesPerGram=>TotalCalories();

		private double TotalCalories()
		{
			double totalCalories = 1;
			if (toppingType.ToLower() == "meat")
			{
				totalCalories *= 1.2;
			}
			else if (toppingType.ToLower() == "veggies")
			{
				totalCalories *= 0.8;
			}
			else if (toppingType.ToLower() == "cheese")
			{
				totalCalories *= 1.1;
			}
			else
			{
				totalCalories *= 0.9;
			}
			return totalCalories*baseCaloriesPerGram*grams;
		}

	}
}
