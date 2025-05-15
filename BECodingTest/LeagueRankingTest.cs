public class LeagueRankingTest
{
    [Fact]
    public void ProccessTeamScore_CorrectAnswer()
    {
        var input = "Lions 3";
        var result = LeagueRanking.ProccessTeamScore(input);

        Assert.Equal("Lions", result.Name);
        Assert.Equal(3, result.Score);
    }

    [Fact]
    public void ProccessTeamScore_ArgumentException()
    {
        var input = "Lions";
        //Assert
        var caughtException = Assert.Throws<ArgumentException>(() => LeagueRanking.ProccessTeamScore(input));
        Assert.Equal("Team information incomplete", caughtException.Message);
    }

    [Fact]
    public void SortResults_NameScore()
    {
        var teams = new List<string>();
        teams.Add("Lions 3, Snakes 3");
        teams.Add("Tarantulas 1, FC Awesome 0");
        teams.Add("Lions 1, FC Awesome 1");
        teams.Add("Tarantulas 3, Snakes 1");
        teams.Add("Lions 4, Grouches 0");

        var sorted = LeagueRanking.ProccessScores(teams);

        Assert.Equal(5, sorted["Lions"]);
        Assert.Equal(1, sorted["Snakes"]);
        Assert.Equal(6, sorted["Tarantulas"]);
        Assert.Equal(1, sorted["FC Awesome"]);
        Assert.Equal(0, sorted["Grouches"]);
    }

}