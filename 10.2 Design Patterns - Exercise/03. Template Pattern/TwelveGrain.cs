using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Pattern
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread.(30min.)");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering Ingredients dor 12-Grain Bread.");
        }
    }
}
