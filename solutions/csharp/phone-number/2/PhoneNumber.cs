public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var onlyDigits = string.Concat(phoneNumber.Where(char.IsDigit));

        if (onlyDigits.Length == 11)
        {
            onlyDigits = onlyDigits[0] == '1' ? onlyDigits.Remove(0, 1) : throw new ArgumentException();
        }

        if (onlyDigits.Length == 10)
        {
            return int.Parse(onlyDigits[0].ToString()) <= 1 || int.Parse(onlyDigits[3].ToString()) <= 1
                ? throw new ArgumentException()
                : onlyDigits;
        }
        else
        {
            throw new ArgumentException();
        }

    }
}