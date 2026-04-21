public class HighScores
{
    private readonly List<int> _highScoreList;


    public HighScores(List<int> list)
    {
        _highScoreList = list;
    }

    public List<int> Scores()
    {
        return _highScoreList;
    }

    public int Latest()
    {
        return _highScoreList.Last();
    }

    public int PersonalBest()
    {
        return _highScoreList.Max();
    }

    public List<int> PersonalTopThree()
    {
        return _highScoreList.OrderDescending().Take(3).ToList();
    }
}