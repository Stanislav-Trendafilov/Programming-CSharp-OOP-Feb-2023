
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public class CompositeGift : GiftBase, IGiftOperation
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, int price)
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} contains the following products with prices:");

            int total = 0;

            foreach (GiftBase gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }
            return total;
        }

    }
}
