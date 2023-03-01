using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int grams;

        private const double doughCalories = 2;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType 
        { 
            get => flourType; 
            set 
            { 
                if(value.ToLower()!="white"&&value.ToLower()!= "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value ; 
            } 
        }
        public string BakingTechnique 
        {
            get => bakingTechnique;
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy"&& value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public int Grams 
        { 
            get => grams;
            set
            {
                if (value <1||value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value; 
            }
        }


       
		public double CaloriesPerGram { get => Calories(); }

        private double Calories()
        {
            double totalCalories = 1;
            if(flourType.ToLower()=="white")
            {
                totalCalories *= 1.5;
            }
            else
            {
                totalCalories *= 1.0;
            }
            if(bakingTechnique.ToLower()=="crispy")
            {
                totalCalories*= 0.9;
            }
            else if(bakingTechnique.ToLower()=="chewy")
            {
                totalCalories*= 1.1;
            }
            else
            {
                totalCalories *= 1.0;
            }

            return totalCalories * grams * doughCalories;
        }
    }

}
