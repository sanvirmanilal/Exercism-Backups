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
        int sqrt = (int)Math.Sqrt(number);

        for (int i = 1; i <= sqrt; i++)
        {
            if (number % i == 0)
            {
                int divisor = number / i;
                if (divisor != number)
                    total += divisor;
                if (i != divisor && i != number)
                    total += i;
            }
        }

        return total switch
        {
            int x when x > number => Classification.Abundant,
            int x when x < number => Classification.Deficient,
            _ => Classification.Perfect,
        };
    }
}
