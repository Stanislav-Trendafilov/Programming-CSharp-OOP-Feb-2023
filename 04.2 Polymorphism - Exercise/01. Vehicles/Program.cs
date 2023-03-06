

using Vehicles;

string[] carInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] truckInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] cmdArg = Console.ReadLine()
        .Split(" ",StringSplitOptions.RemoveEmptyEntries);

    if (cmdArg[0]=="Drive")
    {
        double distance = double.Parse(cmdArg[2]);
        if (cmdArg[1]=="Car")
        {
            car.Drive(distance);
        }
        else
        {
            truck.Drive(distance);
        }
    }
    else
    {
        double fuel = double.Parse(cmdArg[2]);
        if (cmdArg[1] == "Car")
        {
            car.Refuel(fuel);
        }
        else
        {
            truck.Refuel(fuel);
        }
    }
}
Console.WriteLine(car);
Console.WriteLine(truck);