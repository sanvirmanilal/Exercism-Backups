using System.Drawing;

using Xunit.Internal;

public static class ResistorColorTrio
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

    public static string Label(string[] colors)
    {
        long ohms = (_resistorColors[colors[0]] * 10 + _resistorColors[colors[1]]) * (long)Math.Pow(10L, _resistorColors[colors[2]]);

        return ohms switch
        {
            >= 1000000000 => $"{ohms / 1000000000} gigaohms",
            >= 1000000 => $"{ohms / 1000000} megaohms",
            >= 1000 => $"{ohms / 1000} kiloohms",
            _ => $"{ohms} ohms"
        };
    }
}
