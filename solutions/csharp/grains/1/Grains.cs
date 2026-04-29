using System.Numerics;

namespace Exercism;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        else if (n > 64)
        {
            throw new ArgumentOutOfRangeException();
        }
        else ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);


        return (ulong)Math.Pow(2, n - 1);
    }

    public static ulong Total() => (ulong) Math.Pow(2, 64);
}