
public class DndCharacter
{
    private static Random _random = Random.Shared;
    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Constitution { get; init; }
    public int Intelligence { get; init; }
    public int Wisdom { get; init; }
    public int Charisma { get; init; }
    public int Hitpoints { get; init; }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability() => Enumerable.Range(1, 4).Select(x => _random.Next(1, 7)).OrderDescending().Take(3).Sum();

    public static DndCharacter Generate()
    {
        var constitution = Ability();
        return new()
        {
            Strength = Ability(),
            Charisma = Ability(),
            Constitution = constitution,
            Dexterity = Ability(),
            Intelligence = Ability(),
            Wisdom = Ability(),
            Hitpoints = 10 + Modifier(constitution)
        };
    }

}
