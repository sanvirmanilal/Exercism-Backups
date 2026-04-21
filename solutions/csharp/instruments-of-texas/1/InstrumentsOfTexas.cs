using System.Xml.Serialization;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message, inner)
    {
        Operand1 = operand1;
        Operand2 = operand2;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return "Multiply succeeded";

    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException overflowException)
        {
            string message = string.Empty;

            if (x < 0 && y < 0)
            {
                message = "Multiply failed for negative operands. ";
            }
            else
            {
                message = "Multiply failed for mixed or positive operands. ";
            }

            throw new CalculationException(x, y, message + overflowException.Message, overflowException);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
