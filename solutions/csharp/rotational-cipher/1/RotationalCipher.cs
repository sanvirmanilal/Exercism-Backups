using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        StringBuilder stringBuilder = new();
        foreach (var c in text)
        {
            stringBuilder.Append(c switch
            {
                char x when char.IsUpper(x) => char.ToUpper(alphabet[(alphabet.IndexOf(char.ToLower(x)) + shiftKey) % 26]),
                char x when char.IsLetter(x) => alphabet[(alphabet.IndexOf(x) + shiftKey) % 26],
                _ => c,
            });
        }
        return stringBuilder.ToString();
    }
}