public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
        {
            return [];
        }

        var numbersToCheck = Enumerable.Range(2, limit - 1).ToList();
        int? startingNumber = numbersToCheck[0];
        while (startingNumber != null)
        {
            var totalNumbersToCheck = numbersToCheck.Count - 1;
            var workingSetOfNumbers = new int[numbersToCheck.Count];

            numbersToCheck.CopyTo(workingSetOfNumbers);

            for (int i = Array.IndexOf(workingSetOfNumbers, startingNumber); i <= totalNumbersToCheck; i++)
            {
                if (workingSetOfNumbers[i] != startingNumber && workingSetOfNumbers[i] % startingNumber == 0)
                {
                    numbersToCheck.Remove(workingSetOfNumbers[i]);
                }
            }

            var nextStartingNumber = numbersToCheck.FirstOrDefault(x => x > startingNumber);
            startingNumber = nextStartingNumber > 0 ? nextStartingNumber : null;
        }

        return numbersToCheck.ToArray();
    }
}