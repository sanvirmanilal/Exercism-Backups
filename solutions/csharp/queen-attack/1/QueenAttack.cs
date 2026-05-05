public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        if (black.Row == white.Row || black.Column == white.Column)
        {
            return true;
        }

        var x = Math.Abs(black.Row - white.Row);
        var y = Math.Abs(black.Column - white.Column);
        var h = Math.Sqrt(x * x + y * y);
        return Math.Ceiling(Math.Asin(y / h) * (180 / Math.PI)) % 45 == 0;
    }

    public static Queen Create(int row, int column) => row >= 0 && row < 8 && column >= 0 && column < 8 ? new(row, column) : throw new ArgumentOutOfRangeException();
}