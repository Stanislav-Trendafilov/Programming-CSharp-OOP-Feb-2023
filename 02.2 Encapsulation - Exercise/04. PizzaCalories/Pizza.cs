using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
		private string name;
		private Dough doughType;
        private List<Topping> toppings;

        public Pizza(string name, Dough doughType)
        {
            Name = name;
            DoughType = doughType;
			toppings = new List<Topping>();
        }


        public Dough DoughType
		{
			get => doughType; 
			set
			{
				doughType = value; 
			}
		}

		public string Name
		{
			get => name;
			set 
			{ 
				if(string.IsNullOrEmpty(value)||value.Length>15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				name = value; 
			}
		}
		public int NumberOfToppings
		{
			get=>toppings.Count;
		}
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public override string ToString()
        {
			return $"{name} - {TotalCalories:f2} Calories.";
        }
        public double TotalCalories => Calories();
		private double Calories()
		{
			double totalCalories = doughType.CaloriesPerGram;
			foreach (var topping  in toppings)
			{
				totalCalories += topping.CaloriesPerGram;
			}
			return totalCalories;
		}

	}
}
