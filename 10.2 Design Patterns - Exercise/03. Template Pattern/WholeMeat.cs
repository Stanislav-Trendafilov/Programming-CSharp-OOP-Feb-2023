using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template_Pattern;

namespace Template_Pattern
{
    public class WholeMeat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the WholeMeat Bread.(350min.)");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering Ingredients for WholeMeat Bread.");
        }
    }
}
