using Xunit.Internal;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength <= numbers.Length && sliceLength > 0)
        {
            var series = new string[numbers.Length - sliceLength + 1];
            Enumerable.Range(0, numbers.Length - sliceLength + 1).ForEach(x => series[x] = numbers.Substring(x, sliceLength));
            return series;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}