using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template_Pattern;

namespace Template_Pattern
{
    public class SourDough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the SourDough Bread.(20min.)");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering Ingredients dor SourDough Bread.");
        }
    }
}
