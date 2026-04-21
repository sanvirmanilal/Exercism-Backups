using System.Diagnostics.CodeAnalysis;

public static class LineUp
{
    public static string Format(string name, int number)
    {
        int[] exceptions = [11, 12, 13];
        int numberModuloTen = number > 13 ? number % 100 : number;

        string suffix = "th";

        if (!exceptions.Contains(numberModuloTen))
        {
            suffix = (numberModuloTen % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
        }

        return $"{name}, you are the {number}{suffix} customer we serve today. Thank you!";
    }
}
