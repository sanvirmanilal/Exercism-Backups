using System.Diagnostics.CodeAnalysis;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        int total = 0;
        for (int i = 1; i < number; i++)
        {
            total += number % i == 0 ? i : 0;
        }

        return total switch
        {
            int x when x == number => Classification.Perfect,
            int x when x > number => Classification.Abundant,
            int x when x < number => Classification.Deficient
        };
    }
}
