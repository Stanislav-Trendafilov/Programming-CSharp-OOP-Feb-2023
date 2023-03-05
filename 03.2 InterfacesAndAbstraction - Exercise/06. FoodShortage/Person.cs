using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    internal class Person : IBuyer
    {
        public Person(string name, int age, string id,string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate=birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }

        public int BuyFood()
        {
            return 10;
        }
    }
}
