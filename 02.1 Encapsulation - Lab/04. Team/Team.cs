using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();

        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get => this.firstTeam.AsReadOnly();
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get => this.reserveTeam.AsReadOnly();
        }
        public string Name { get => name; set => name = value; }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
               reserveTeam.Add(person);
            }

        }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.AppendLine($"First team has {firstTeam.Count} players.");
            stringBuilder.AppendLine($"Reserve team has {reserveTeam.Count} players.");
            return stringBuilder.ToString().Trim();

        }
    }
}
