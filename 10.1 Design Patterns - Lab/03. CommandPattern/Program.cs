
using CommandPattern.Enumeration;
using CommandPattern.Interface;
using CommandPattern.Models;
using System.Runtime.CompilerServices;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main()
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Phone", 500);

            Execute(product, modifyPrice, new ProductCommand(product, PriceActionEnum.Increase, 100));

            Execute(product, modifyPrice, new ProductCommand(product, PriceActionEnum.Increase, 50));

            Execute(product, modifyPrice, new ProductCommand(product, PriceActionEnum.Decrease, 25));

            Console.WriteLine(product);
        }
        public static void Execute(Product product, ModifyPrice modify, ICommand productCommand)
        {
            modify.SetCommand(productCommand);
            modify.Invoke();
        }
    }
}
