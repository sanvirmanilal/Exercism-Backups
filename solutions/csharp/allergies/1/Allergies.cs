[Flags]
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies(int mask)
{
    private int _mask = mask;

    public bool IsAllergicTo(Allergen allergen)
    {
        return Enum.TryParse(_mask.ToString(), out Allergen allergies) && (allergies & allergen) == allergen;
    }

    public Allergen[] List()
    {
        return Enum.GetValues<Allergen>()
            .Where(allergen => (_mask & (int)allergen) == (int)allergen)
            .ToArray();
    }
}