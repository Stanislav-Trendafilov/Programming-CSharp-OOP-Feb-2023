using System.ComponentModel;
using System.Xml;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(" ");
                string[]doughInfo= Console.ReadLine().Split(" ");
                Pizza pizza = new(pizzaInfo[1], new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3])));

                string topping = string.Empty;
                while((topping=Console.ReadLine())!="END")
                {
                    string[] toppingInfo = topping.Split();
                    pizza.AddTopping(new Topping(toppingInfo[1], int.Parse(toppingInfo[2])));
                }
                Console.WriteLine(pizza.ToString());

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}