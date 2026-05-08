using Xunit.Internal;

public static class RnaTranscription
{
    private static Dictionary<char, char> dnaToRna = new()
    {
        {'G', 'C'},
        {'C', 'G'},
        {'T', 'A'},
        {'A', 'U'}
    };

    public static string ToRna(string strand) => string.Concat(strand.Select(x => dnaToRna[x]));
}