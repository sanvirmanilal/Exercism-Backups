using Xunit.Internal;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}


public class KindergartenGarden(string diagram)
{
    private readonly Dictionary<string, int> studentPlantPositions = new()
    {
        { "Alice", 0 },
        { "Bob", 2 },
        { "Charlie", 4 },
        { "David", 6 },
        { "Eve", 8 },
        { "Fred", 10 },
        { "Ginny", 12},
        { "Harriet", 14},
        { "Ileana", 16},
        { "Joseph", 18 },
        { "Kincaid", 20 },
        { "Larry", 22 },
    };

    private static readonly Dictionary<char, Plant> plantDict = Enum.GetValues<Plant>().ToDictionary(plant => plant.ToString()[0], plant => plant);

    private readonly string[] gardenRows = diagram.Split("\n");

    public IEnumerable<Plant> Plants(string student)
    {
        var plantPosition = studentPlantPositions[student];

        List<char> plants = [];

        gardenRows.ForEach(row => plants.AddRange(row.Skip(plantPosition).Take(2).Select(plant => plant)));

        return plants.Where(plantDict.ContainsKey).Select(x => plantDict[x]);
    }
}