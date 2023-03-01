using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
		private string name;
		private List<Player> players;

		public Team(string name)
		{
			Name = name;
			players = new List<Player>();
		}
		public string Name
		{
			get=> name; 
			private set 
			{ 
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("A name should not be empty.");
				}
				name = value;
			}
		}
		public double Average()
        {

            int totalRating = 0;
            foreach (var player in players)
            {
                int skillLevel = (int)Math.Round((player.Endurance + player.Sprint + player.Dribble + player.Passing + player.Shooting) / 5.0);
                totalRating += skillLevel;
            }
            return totalRating;
        }
		public void AddPlayer(Player player)
		{
				players.Add(player);
		}
		public void RemovePlayer(string playerName)
		{
			if (players.Any(x => x.Name == playerName))
			{
				Player player1 = players.FirstOrDefault(x => x.Name == playerName);
				players.Remove(player1);
			}
			else
			{
				throw new ArgumentException($"Player {playerName} is not in {name} team.");
			}
		}
        public override string ToString()
        {
            return $"{name} - {Average():F0}";
        }

    }
}
