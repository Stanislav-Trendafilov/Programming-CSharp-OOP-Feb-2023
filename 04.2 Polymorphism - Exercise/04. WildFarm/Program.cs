using WildFarm.Animals;
using WildFarm.Foods;

List<Animal> animals = new();
string input = string.Empty;
while ((input = Console.ReadLine()) != "End")
{
    string[] animalInfo = input
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string animalType = animalInfo[0];
    Animal animal = null;
    switch (animalType)
    {
        case "Owl":
            animal = new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
            break;
        case "Hen":
            animal = new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
            break;
        case "Mouse":
            animal = new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
            break;
        case "Dog":
            animal = new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
            break;
        case "Cat":
            animal = new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
            break;
        case "Tiger":
            animal = new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
            break;
    }
    Console.WriteLine(animal.ProduceSound());

    string[] foodInfo = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    Food food = null;
    string foodType = foodInfo[0];

    switch (foodType)
    {
        case "Vegetable":
            food = new Vegetable(int.Parse(foodInfo[1]));
            break;
        case "Fruit":
            food = new Fruit(int.Parse(foodInfo[1]));
            break;
        case "Meat":
            food = new Meat(int.Parse(foodInfo[1]));
            break;
        case "Seeds":
            food = new Seeds(int.Parse(foodInfo[1]));
            break;
    }
    animal.Feed(food);
    animals.Add(animal);
}
foreach (var animal in animals)
    Console.WriteLine(animal);