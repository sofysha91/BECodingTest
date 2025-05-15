public class LeagueRanking
{
    public class Team
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Team(string name, int score = 0)
        {
            Name = name;
            Score = score;
        }
    }

    static void Main()
    {
        IEnumerable<string> matches;

        Console.WriteLine("Enter match results:");
        var matchResults = new List<string>();
        string match;

        while (!string.IsNullOrWhiteSpace(match = Console.ReadLine()))
        {
            matchResults.Add(match);
        }

        Dictionary<string, int> results = ProccessScores(matchResults);

        if (results is null)
            return;

        //Print results        
        PrintWithRank(results);
    }

    public static Dictionary<string, int> ProccessScores(List<string> matches)
    {
        Dictionary<string, int> results = new();

        foreach (var match in matches)
        {
            var teams = match.Split(',');
            int team1Score = 0, team2Score = 0;
            Team team1 = ProccessTeamScore(teams[0]);
            Team team2 = ProccessTeamScore(teams[1]);

            if (team1.Score > team2.Score)
            {
                team1Score = 3;
            }
            else if (team1.Score == team2.Score)
            {
                team1Score = 1;
                team2Score = 1;
            }
            else
            {
                team2Score = 3;
            }

            //Add or update team 1
            if (results.ContainsKey(team1.Name))
            {
                results[team1.Name] += team1Score;
            }
            else
            {
                results.Add(team1.Name, team1Score);
            }

            //Add or update team 2
            if (results.ContainsKey(team2.Name))
            {
                results[team2.Name] += team2Score;
            }
            else
            {
                results.Add(team2.Name, team2Score);
            }
        }

        return results;
    }

    public static Team ProccessTeamScore(string input)
    {
        var trimmed = input.Trim();
        int lastSpace = trimmed.LastIndexOf(' ');
        if (lastSpace == -1)
            throw new ArgumentException("Team information incomplete");

        string name = trimmed.Substring(0, lastSpace);
        int score = int.Parse(trimmed.Substring(lastSpace + 1));
        return new Team(name, score);
    }

    static void PrintWithRank(Dictionary<string, int> results)
    {
        int rank = 0;
        int prevScore = -1;

        foreach (KeyValuePair<string, int> team in results.OrderByDescending(i => i.Value).ThenBy(x => x.Key))
        {
            if (team.Value != prevScore)
            {
                rank++;
                prevScore = team.Value;
            }
            Console.WriteLine($"{rank}. {team.Key}, {team.Value} {(team.Value == 1 ? "pt" : "pts")}");
        }

    }

}

