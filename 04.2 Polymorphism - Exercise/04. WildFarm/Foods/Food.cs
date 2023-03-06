using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
