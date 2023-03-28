

using Prototype_Pattern;

SandwichMenu sandwichMenu= new SandwichMenu();

sandwichMenu["BLI"] = new Sandwich("Wheat", "Bacon", "", "Tomato");

Sandwich sandwich = sandwichMenu["BLI"].Clone() as Sandwich;