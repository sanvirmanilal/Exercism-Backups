using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
    }

    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, @"<[-^*=]+>");
    }

    public int CountQuotedPasswords(string lines)
    {
        return Regex.Matches(lines, "\"[^\"\\r\\n]*password[^\"\\r\\n]*\"", RegexOptions.IgnoreCase).Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line\d+", string.Empty);
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] parsedLines = new string[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            var match = Regex.Match(lines[i], @"password\S+", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                parsedLines[i] = $"{match.Value}: {lines[i]}";
            }
            else
            {
                parsedLines[i] = $"--------: {lines[i]}";
            }

        }

        return parsedLines;
    }
}
