using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Product
    {

        private int cost;
        private string name;

        public Product(int cost, string name)
        {
            this.Cost = cost;
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public int Cost
        {
            get { return cost; }
            set
            { 
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value; 
            
            }
        }

    }
}
