class BirdCount
{
    private int[] _birdsPerDay;
    private static int[] _lastWeeksCount = [0, 2, 5, 3, 7, 8 ,4];

    public BirdCount(int[] birdsPerDay)
    {
        _birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => _lastWeeksCount;
    
    public int Today() => _birdsPerDay[_birdsPerDay.Length-1];

    public void IncrementTodaysCount() => _birdsPerDay[_birdsPerDay.Length - 1]++;

    public bool HasDayWithoutBirds()
    {
        for (int day = 0; day < 7; day++)
        {
            if (_birdsPerDay[day] == 0)
            {
                return true;
            }
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int totalBirds = 0;
        for (int day = 0; day < numberOfDays; day++)
        {
            totalBirds += _birdsPerDay[day];
        }
        return totalBirds;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        for (int day = 0; day < 7; day++)
        {
            if (_birdsPerDay[day] >= 5)
            {
                busyDays++;
            };
        }

        return busyDays;
    }
}
