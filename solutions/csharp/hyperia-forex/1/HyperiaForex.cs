public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount left, CurrencyAmount right) => left.currency == right.currency ? left.amount == right.amount : throw new ArgumentException();

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right) => left.currency == right.currency ? left.amount != right.amount : throw new ArgumentException();

    // TODO: implement comparison operators
    public static bool operator >(CurrencyAmount left, CurrencyAmount right) => left.currency == right.currency ? left.amount > right.amount : throw new ArgumentException();
    public static bool operator <(CurrencyAmount left, CurrencyAmount right) => left.currency == right.currency ? left.amount < right.amount : throw new ArgumentException();

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right) => left.currency == right.currency ? new(left.amount + right.amount, left.currency) : throw new ArgumentException();
    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right) => left.currency == right.currency ? new(left.amount - right.amount, left.currency) : throw new ArgumentException();
    public static decimal operator *(CurrencyAmount left, decimal number) => left.amount * number;
    public static decimal operator /(CurrencyAmount left, decimal number) => left.amount / number;
    public static decimal operator *(decimal number, CurrencyAmount left) => left.amount * number;
    public static decimal operator /(decimal number, CurrencyAmount left) => left.amount / number;

    // TODO: implement type conversion operators
    public static explicit operator double(CurrencyAmount currencyAmount) => (double)currencyAmount.amount;
    public static implicit operator decimal(CurrencyAmount currencyAmount) => currencyAmount.amount;
}


