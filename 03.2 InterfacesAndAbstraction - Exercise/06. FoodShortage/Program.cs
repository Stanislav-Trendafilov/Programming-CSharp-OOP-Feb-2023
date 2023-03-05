using FoodShortage;

namespace FoodShortage;

public class StartUp
{
    static void Main(string[] args)
    {
        int n=int.Parse(Console.ReadLine());

        IBuyer ibuyer;
        List<IBuyer> list = new List<IBuyer>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if(input.Length==4)
            {
                ibuyer=new Person(input[0], int.Parse(input[1]), input[2], input[3]);
                list.Add(ibuyer);
            }
            else
            {
                ibuyer = new Rebel(input[0], int.Parse(input[1]), input[2]);
                list.Add(ibuyer);
            }
        }

        string name = string.Empty;
        int suma = 0;
        while((name=Console.ReadLine())!="End")
        {
            if(list.Any(n=>n.Name==name))
            {
                var currentBuyer = list.FirstOrDefault(b => b.Name == name);
                if (currentBuyer == null)
                {
                    continue;
                }
                suma+=currentBuyer.BuyFood();
            }
        }
        Console.WriteLine(suma);
    }
}