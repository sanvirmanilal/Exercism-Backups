using Xunit.Internal;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var text = number.ToString();
        int sum = text.Sum(x => (int)Math.Pow(x - '0', text.Length));
        return sum == number;
    }
}