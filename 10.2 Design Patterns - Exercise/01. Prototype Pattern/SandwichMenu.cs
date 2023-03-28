using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichProrotype> sandwiches =
            new Dictionary<string, SandwichProrotype>();

        public SandwichProrotype this[string name]
        {
            get
            {
                return sandwiches[name];
            }
            set
            {
                sandwiches.Add(name, value);
            }
        }
    }
}
