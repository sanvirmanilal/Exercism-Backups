public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException();
        }

        var combined = firstStrand.Zip(secondStrand);
        return combined.Count(x => x.First != x.Second);
    }
}