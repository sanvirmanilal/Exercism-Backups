public static class ResistorColor
{
    private static Dictionary<string, int> resistorColours = new(StringComparer.OrdinalIgnoreCase)
    {
        ["black"] = 0,
        ["brown"] = 1,
        ["red"] = 2,
        ["orange"] = 3,
        ["yellow"] = 4,
        ["green"] = 5,
        ["blue"] = 6,
        ["violet"] = 7,
        ["grey"] = 8,
        ["white"] = 9,
    };

    public static int ColorCode(string color)
    {
        return resistorColours[color];
    }

    public static string[] Colors()
    {
        return resistorColours.Keys.ToArray();
    }
}