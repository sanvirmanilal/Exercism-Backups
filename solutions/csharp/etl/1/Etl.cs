public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> transformedPoints = [];

        foreach (var v in old)
        {
            transformedPoints = transformedPoints
                .Concat(v.Value.ToDictionary(x => x.ToLower(), x => v.Key))
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(group => group.Key, group => group.First().Value); ;
        }

        return transformedPoints;
    }
}