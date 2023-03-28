using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern
{
    public class Sandwich : SandwichProrotype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string vegetables;

        public Sandwich(string bread, string meat, string cheese, string vegetables)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.vegetables = vegetables;
        }

        private string GetIngridients()
                => $"{bread} {meat} {cheese} {vegetables}";


        public override SandwichProrotype Clone()
        {
            string ingridients=
                GetIngridients();

            Console.WriteLine($"Cloning sandwich with ingridients: {ingridients}");

            return MemberwiseClone() as SandwichProrotype;
        }
    }
}
