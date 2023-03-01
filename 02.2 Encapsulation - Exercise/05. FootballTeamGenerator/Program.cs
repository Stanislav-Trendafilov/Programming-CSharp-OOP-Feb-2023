using FootballTeamGenerator;
using System;

string input = string.Empty;
List<Team> teams = new List<Team>();

while ((input = Console.ReadLine()) != "END")
{
    string[] cmdTokens = input
        .Split(';', StringSplitOptions.RemoveEmptyEntries);
    string command = cmdTokens[0];

    try
    {
        if (command == "Team")
        {
            Team team = new(cmdTokens[1]);
            teams.Add(team);
        }
        else if (command == "Add")
        {
            string currTeamName = cmdTokens[1];
            if (!teams.Any(x => x.Name == currTeamName))
            {
                Console.WriteLine($"Team {currTeamName} does not exist.");
                continue;
            }
            string playerName = cmdTokens[2];
            int endurance = int.Parse(cmdTokens[3]);
            int sprint = int.Parse(cmdTokens[4]);
            int dribble = int.Parse(cmdTokens[5]);
            int passing = int.Parse(cmdTokens[6]);
            int shooting = int.Parse(cmdTokens[7]);

            Player player = new(playerName, endurance, sprint, dribble, passing, shooting);
            var currTeam = teams.Find(x => x.Name == currTeamName);
            currTeam.AddPlayer(player);
        }
        else if (command == "Remove")
        {
            string currTeamName = cmdTokens[1];
            string playerName = cmdTokens[2];
            if (!teams.Any(x => x.Name == currTeamName))
            {
                Console.WriteLine($"Team {currTeamName} does not exist.");
                continue;
            }
            teams.Find(x => x.Name == currTeamName).RemovePlayer(playerName);
        }
        else if (command == "Rating")
        {
            string currTeamName = cmdTokens[1];
            if (!teams.Any(x => x.Name == currTeamName))
            {
                Console.WriteLine($"Team {currTeamName} does not exist.");
                continue;
            }
            Console.WriteLine(teams.Find(x => x.Name == currTeamName));
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
