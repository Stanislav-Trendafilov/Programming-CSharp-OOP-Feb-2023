
using Raiding;

List<BaseHero>heroes= new List<BaseHero>();

int n=int.Parse(Console.ReadLine());

while(heroes.Count!=n)
{ 
    string heroName = Console.ReadLine();
    string heroType = Console.ReadLine();

    if(heroType=="Druid")
    {
        heroes.Add(new Druid(heroName));
    }
    else if(heroType== "Paladin")
    {
        heroes.Add(new Paladin(heroName));
    }
    else if (heroType=="Rogue")
    {
        heroes.Add(new Rogue(heroName));
    }
    else if(heroType== "Warrior")
    {
        heroes.Add(new Warrior(heroName));
    }
    else
    {
        Console.WriteLine("Invalid hero!");
    }
}

int bossHealth = int.Parse(Console.ReadLine());
int heroesDamage = 0;

foreach (var hero in heroes)
{
    Console.WriteLine(hero.CastAbility());
    heroesDamage += hero.Power;
}

if(heroesDamage>= bossHealth)
{
    Console.WriteLine("Victory!");
}
else
{
    Console.WriteLine("Defeat...");
}