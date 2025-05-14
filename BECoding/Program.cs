// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!"); 

class Program
{

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
        matches = matchResults;
        Console.WriteLine(matches);

    }

    public void ProccessScore(List<string> matches)
    {
        foreach (var match in matches)
        {
            var teams = match.Split(',');

            var team1 = teams[0];
            var team2 = teams[1];
        }

    }
}

