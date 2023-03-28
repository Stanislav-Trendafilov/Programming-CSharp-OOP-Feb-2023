

using Facade;

var car = new CarBuilderFacade()
    .Info
        .WithType("Chevrolet")
        .WithColor("Red")
        .WithNumberOfDoors(4)
    .Built
        .InCity("Detroit")
        .AtAddress("Michigan, U.S.")
    .Build();

Console.WriteLine(car);