using System.Globalization;

public static class HighSchoolSweethearts
{
    private const string expectedBanner =
@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0} +  {1}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        string text = $"{studentA} ♡ {studentB}";
        int alignment = (int)Math.Round((61 - text.Length) / 2d, MidpointRounding.ToZero);
        return text.PadLeft(text.Length - 1 + alignment).PadRight(61);
    }

    public static string DisplayBanner(string studentA, string studentB) => string.Format(expectedBanner, studentA, studentB);

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        return $"{studentA} and {studentB} have been dating since {start:dd.MM.yyyy} - that's {hours.ToString("N2", new CultureInfo("de-DE"))} hours";
    }
}

