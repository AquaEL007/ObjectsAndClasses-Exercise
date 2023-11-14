using System.Threading.Channels;

class Team
{
    public Team(string teamName, string creatorName)
    {
        Name = teamName;
        Creator = creatorName;
        Members = new List<string>();
    }

    public string Name { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }
    public override string ToString()
    {
        return $"{Name}\n" +
               $"- {Creator}\n" +
               $"{GetMembersString()}";
    }

    public string GetMembersString()
    {
        Members = Members.OrderBy(name => name).ToList();

        string result = string.Empty;

        for (int i = 0; i < Members.Count - 1; i++)
        {
            result += $"-- {Members[i]}\n";
        }

        result += $"-- {Members[Members.Count - 1]}";
        return result;
    }
}
internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Team> teams = new List<Team>();

        for (int i = 0; i < n; i++)
        {
            string[] teamCommands = Console.ReadLine().Split("-").ToArray();

            string creatorName = teamCommands[0];
            string teamName = teamCommands[1];

            Team team = new Team(teamName, creatorName);

            Team sameTeamFound = teams.Find(t => t.Name == team.Name);

            if (sameTeamFound != null)
            {
                Console.WriteLine($"Team {team.Name} was already created!");
                continue;
            }

            Team sameCreatorFound = teams.Find(t => t.Creator == creatorName); 
            
            if (sameCreatorFound != null) 
            {
                Console.WriteLine($"{sameCreatorFound.Creator} cannot create another team!");
                continue;
            }

            teams.Add(team);
            Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
        }

        string command;
        while ((command = Console.ReadLine()) != "end of assignment")
        {
            string[] arguments = command.Split("->");

            string joinerName = arguments[0];
            string teamName = arguments[1];

            bool hasAnyTeamWithSameName = teams.Any(t => t.Name == teamName);
            if (hasAnyTeamWithSameName == false)
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (teams.Any(team => team.Creator == joinerName) || 
                teams.Any(team => team.Members.Contains(joinerName)))
            {
                Console.WriteLine($"Member {joinerName} cannot join team {teamName}!");
                continue;
            }

            Team t = teams.Find(t => t.Name == teamName);

            if (t != null)
            {
                t.Members.Add(joinerName);
            }
        }

        List<Team> leftTeams = teams.Where(t => t.Members.Count > 0).ToList();
        List<Team> disband = teams.Where(t => t.Members.Count <= 0).ToList();

        List<Team> orderedLeftTeams = leftTeams
            .OrderByDescending(t => t.Members.Count)
            .ThenBy(t => t.Name)
            .ToList();

        orderedLeftTeams.ForEach(t => Console.WriteLine(t));

        List<Team> disbandTeams = teams.Where(t => t.Members.Count <= 0).ToList();
        Console.WriteLine("Teams to disband:");

        disbandTeams = disbandTeams.OrderBy(x => x.Name).ToList();

        disbandTeams.ForEach(t => Console.WriteLine(t.Name));

    }
}