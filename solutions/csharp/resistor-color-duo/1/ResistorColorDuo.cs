using System.Text;

using Xunit.Internal;

public static class ResistorColorDuo
{

    private static Dictionary<string, int> _resistorColors = new Dictionary<string, int>
    {
        {"black" , 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6 },
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    };

    public static int Value(string[] colors)
    {
        StringBuilder stringBuilder = new();
        colors.Take(2).ForEach(x => stringBuilder.Append(_resistorColors[x]));
        return int.TryParse(stringBuilder.ToString(), out int result) ? result : throw new ArgumentException();
    }
}
