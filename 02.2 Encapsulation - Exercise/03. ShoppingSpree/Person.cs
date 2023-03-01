using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {

        private int money;
        private string name;
        private List<Product> products;

        public Person(int money, string name)
        {
            this.Money = money;
            this.Name = name;
            this.products = new List<Product>();
        }

        public string Name
        {

            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }

        }
        public int Money
        {
            get { return money; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> Products { get => products; }


        public void BuyFood(Product product)
        {
            if (Money - product.Cost < 0)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                Money -= product.Cost;
                products.Add(product);
            }
        }

    }
}
