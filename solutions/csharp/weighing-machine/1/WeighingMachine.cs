class WeighingMachine(int precision)
{
    public int Precision { get; } = precision;

    private double _weight;
    public double Weight
    {
        get { return _weight; }
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5;

    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";
}
