public class SpaceAge
{
    double _totalEarthYears = default;
    public SpaceAge(int seconds)
    {
        _totalEarthYears = seconds / 31_557_600;
    }

    public double OnEarth()
    {
        return _totalEarthYears;
    }

    public double OnMercury()
    {
        return _totalEarthYears / 0.2408467;
    }

    public double OnVenus()
    {
        return _totalEarthYears / 0.61519726;
    }

    public double OnMars()
    {
        return _totalEarthYears / 1.8808158;
    }

    public double OnJupiter()
    {
        return _totalEarthYears / 11.862615;
    }

    public double OnSaturn()
    {
        return _totalEarthYears / 29.447498;
    }

    public double OnUranus()
    {
        return _totalEarthYears / 84.016846;
    }

    public double OnNeptune()
    {
        return _totalEarthYears / 164.79132;
    }
}