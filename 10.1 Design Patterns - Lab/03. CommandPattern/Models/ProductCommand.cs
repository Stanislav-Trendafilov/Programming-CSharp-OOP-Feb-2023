using CommandPattern.Enumeration;
using CommandPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Models
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceActionEnum priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceActionEnum priceAction, int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }

        public void Execute()
        {
            if(priceAction==PriceActionEnum.Increase)
            {
                product.IncreasePrice(amount);
            }
            else
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
