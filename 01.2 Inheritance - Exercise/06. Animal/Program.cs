using System.Reflection;
using System.Xml.Linq;

namespace Animals   
{
    public class StartUp
    {   
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command=string.Empty;
            while((command=Console.ReadLine())!= "Beast!") 
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(cmdArg.Length > 3 ) 
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (int.Parse(cmdArg[1])<0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (cmdArg[2] != "Male" && cmdArg[2]!="Female")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string name = cmdArg[0];
                int age = int.Parse(cmdArg[1]);
                string gender = cmdArg[2];
                if (command == "Dog")
                {
                    Dog dog = new(name, age, gender);
                    animals.Add(dog);
                }
                else if (command == "Frog")
                {
                    Frog frog = new(name, age, gender);
                    animals.Add(frog);
                }
                else if (command == "Cat")
                {
                    Cat cat = new(name, age, gender);
                    animals.Add(cat);
                }
                else if (command == "Kitten")
                {
                    Kitten kitten = new(name, age);
                    animals.Add(kitten);
                }
                else
                { 
                    Tomcat tomcat = new(name, age);
                    animals.Add(tomcat);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.GetType().Name}");
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine($"{animal.ProduceSound()}");
            }
        }
    }
}

