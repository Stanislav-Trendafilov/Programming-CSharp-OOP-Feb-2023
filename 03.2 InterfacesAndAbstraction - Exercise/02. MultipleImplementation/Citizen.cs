using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private int age;
        private string name;

        public Citizen(string name, int age,string id,string birthday)
        {
            Age = age;
            Name = name;
            Id = id;
            Birthdate= birthday;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}
