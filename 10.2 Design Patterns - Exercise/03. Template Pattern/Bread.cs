using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Pattern
{
    public abstract class Bread
    {
        public abstract void MixIngridients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread!");
        }

        public void Make()
        {
            MixIngridients();
            Bake();
            Slice();
        }
    }
}
