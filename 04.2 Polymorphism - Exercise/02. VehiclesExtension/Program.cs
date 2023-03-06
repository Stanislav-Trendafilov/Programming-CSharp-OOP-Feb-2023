

using Vehicles;

string[] carInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] truckInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] busInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
Bus bus=new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] cmdArg = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (cmdArg[0] == "Drive")
    {
        double distance = double.Parse(cmdArg[2]);
        if (cmdArg[1] == "Car")
        {
            car.Drive(distance);
        }
        else if (cmdArg[1]=="Truck")
        {
            truck.Drive(distance);
        }
        else
        {
            bus.Drive(distance);
        }
    }
    else if (cmdArg[0]=="DriveEmpty")
    {
        double distance = double.Parse(cmdArg[2]);
        bus.DriveEmpty(distance);
    }
    else
    {
        double fuel = double.Parse(cmdArg[2]);
        if (cmdArg[1] == "Car")
        {
            car.Refuel(fuel);
        }
        else if (cmdArg[1] == "Truck")
        {
            truck.Refuel(fuel);
        }
        else
        {
            bus.Refuel(fuel);
        }
    }
}
Console.WriteLine(car);
Console.WriteLine(truck);
Console.WriteLine(bus);