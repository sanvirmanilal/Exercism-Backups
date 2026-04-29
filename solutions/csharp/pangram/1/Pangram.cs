public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        foreach (var character in input.ToLower())
        {
            if (alphabet.Contains(character))
            {
                var index = alphabet.IndexOf(character);
                alphabet = index > -1 ? alphabet.Remove(index, 1) : alphabet;
            }
        }

        return string.IsNullOrEmpty(alphabet);
    }
}
