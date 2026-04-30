using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        StringBuilder stringBuilder = new();
        if (number % 3 == 0)
        {
            stringBuilder.Append("Pling");
        }

        if (number % 5 == 0)
        {
            stringBuilder.Append("Plang");
        }

        if (number % 7 == 0)
        {
            stringBuilder.Append("Plong");
        }

        var raindrops = stringBuilder.ToString();

        return raindrops.Length == 0 ? number.ToString() : raindrops;
    }
}