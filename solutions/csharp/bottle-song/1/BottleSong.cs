using Xunit.Internal;

public static class BottleSong
{

    private static Dictionary<int, Bottle> _bottles = new()

    {
        { 0 , new Bottle("no", "s")},
        { 1 , new Bottle("One", string.Empty)},
        { 2 , new Bottle("Two", "s")},
        { 3 , new Bottle("Three", "s")},
        { 4 , new Bottle("Four", "s")},
        { 5 , new Bottle("Five", "s")},
        { 6 , new Bottle("Six", "s")},
        { 7 , new Bottle("Seven", "s")},
        { 8 , new Bottle("Eight", "s")},
        { 9 , new Bottle("Nine", "s")},
        { 10 , new Bottle("Ten", "s")},
    };

    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> poemStanzas = new();
        var placeholderText =
@"{0} green bottle{1} hanging on the wall,
{0} green bottle{1} hanging on the wall,
And if one green bottle should accidentally fall,
There'll be {2} green bottle{3} hanging on the wall.";

        for (int i = startBottles; i > startBottles - takeDown; i--)
        {
            poemStanzas.AddRange(string.Format(placeholderText, _bottles[i].Number, _bottles[i].Pluralised, _bottles[i - 1].Number.ToLower(), _bottles[i - 1].Pluralised).Split('\n'));
            poemStanzas.Add("");
        }

        if (poemStanzas.Last() == "")
        {
            poemStanzas.RemoveAt(poemStanzas.Count - 1);
        }
        return poemStanzas;
    }
}

public record Bottle(string Number, string Pluralised);
