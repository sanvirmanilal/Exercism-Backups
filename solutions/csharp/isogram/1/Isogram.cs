public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        return word.ToLower().Where(char.IsLetter).GroupBy(x => x).All(x => x.Count() == 1);
    }
}
