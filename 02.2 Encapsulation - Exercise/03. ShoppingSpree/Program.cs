namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                string[] people=Console.ReadLine()
                    .Split(";");
                List<Person>peopleList = new List<Person>();
                foreach(string person in people)
                {
                    string[] personInfo = person.Split("=");
                    peopleList.Add(new Person(int.Parse(personInfo[1]), personInfo[0]));
                }

                string[] products = Console.ReadLine()
                    .Split(";",StringSplitOptions.RemoveEmptyEntries);
                List<Product> productsList = new List<Product>();
                foreach (string product in products)
                {
                    string[] productInfo = product.Split("=");
                    productsList.Add(new Product(int.Parse(productInfo[1]), productInfo[0]));
                }

                string command = string.Empty;
                while((command=Console.ReadLine())!="END")
                {
                    string[] cmdArg = command.Split(" ");
                    string person=cmdArg[0];
                    string product=cmdArg[1];

                    var personName = peopleList.Find(x => x.Name == person);
                    var productName = productsList.Find(x => x.Name == product);
                    personName.BuyFood(productName);

                }
                foreach (var personInfo in peopleList)
                {
                    if(personInfo.Products.Count>0)
                    {
                        Console.Write($"{personInfo.Name} - ");
                        int i =0;
                        foreach (var pr in personInfo.Products)
                        {
                            if (i == personInfo.Products.Count - 1)
                            {
                                Console.Write($"{pr.Name}");
                                i = 0;
                            }
                            else
                            {
                                i++;
                                Console.Write($"{pr.Name}, ");
                            }
                        }
                    }
                    else
                    {
                        Console.Write($"{personInfo.Name} - Nothing bought");
                    }
                    Console.WriteLine();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }

        }
    }
}