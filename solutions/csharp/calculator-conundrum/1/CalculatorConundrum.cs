public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            return operation switch
            {
                "+" => $"{operand1} + {operand2} = {operand1 + operand2}",
                "*" => $"{operand1} * {operand2} = {operand1 * operand2}",
                "/" => $"{operand1} / {operand2} = {operand1 / operand2}",
                var x when x == string.Empty => throw new ArgumentException(),
                var x when x == null => throw new ArgumentNullException(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }
    }
}
