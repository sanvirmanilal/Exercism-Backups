public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<int> series = [];
        foreach (var multiple in multiples)
        {
            if (multiple > 0)
            {
                int totalDivisors = max / multiple;
                series.AddRange(Enumerable.Range(1, max % multiple == 0 ? totalDivisors - 1 : totalDivisors).Select(x => x * multiple));
            }
        }

        return series.Distinct().Sum();
    }
}