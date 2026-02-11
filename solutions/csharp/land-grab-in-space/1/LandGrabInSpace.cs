public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public readonly struct Plot(Coord one, Coord two, Coord three, Coord four) : IEquatable<Plot>
{
    public readonly Coord One = one;
    public readonly Coord Two = two;
    public readonly Coord Three = three;
    public readonly Coord Four = four;

    public bool Equals(Plot other)
    {
        return One.X == other.One.X
            && One.Y == other.One.Y
            && Two.X == other.Two.X
            && Two.Y == other.Two.Y
            && Three.X == other.Three.X
            && Three.Y == other.Three.Y
            && Four.X == other.Four.X
            && Four.Y == other.Four.Y;
    }
}


public class ClaimsHandler
{
    private List<Plot> _plots = [];
    public void StakeClaim(Plot plot)
    {
        _plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _plots.Any(p => p.Equals(plot));
    }

    public bool IsLastClaim(Plot plot)
    {
        return _plots.Last().Equals(plot); 
    }

    public Plot GetClaimWithLongestSide()
    {
        var longestPreviousPlotX = -1;
        var longestPreviousPlotY = -1;
        var longestCurrentX = -1;
        var longestCurrentY = -1;
        var longestPlot = new Plot();

        foreach (var p in _plots)
        {
            var diffX = Math.Abs(p.One.X - p.Two.X);
            longestCurrentX =  diffX > longestCurrentX ? diffX : longestCurrentX;

            var diffY = Math.Abs(p.One.Y - p.Two.Y);
            longestCurrentY =  diffY > longestCurrentY ? diffY : longestCurrentY;

            diffX = Math.Abs(p.Two.X - p.Three.X);
            longestCurrentX =  diffX > longestCurrentX ? diffX : longestCurrentX;

            diffY = Math.Abs(p.Two.Y - p.Three.Y);
            longestCurrentY =  diffY > longestCurrentY ? diffY : longestCurrentY;
            
            diffX = Math.Abs(p.Three.X - p.Four.X);
            longestCurrentX =  diffX > longestCurrentX ? diffX : longestCurrentX;

            diffY = Math.Abs(p.Three.Y - p.Four.Y);
            longestCurrentY =  diffY > longestCurrentY ? diffY : longestCurrentY;

            diffX = Math.Abs(p.Four.X - p.One.X);
            longestCurrentX =  diffX > longestCurrentX ? diffX : longestCurrentX;

            diffY = Math.Abs(p.Four.Y - p.One.Y);
            longestCurrentY =  diffY > longestCurrentY ? diffY : longestCurrentY;

            if (longestCurrentX > longestPreviousPlotX && longestCurrentX > longestCurrentY || longestCurrentY > longestPreviousPlotY && longestCurrentY > longestPreviousPlotX)
            {
                longestPreviousPlotX = longestCurrentX;
                longestPreviousPlotY = longestCurrentY;
                longestPlot = p;
            }
        }
        return longestPlot;
    }
}