public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int hammingDistance = default;
        if ((firstStrand + secondStrand).Length == 0)
        {
            return hammingDistance;
        }

        if (firstStrand.Length != secondStrand.Length || string.IsNullOrEmpty(firstStrand) || string.IsNullOrEmpty(secondStrand))
        {
            throw new ArgumentException();
        }

        for (int i = 0; i < firstStrand.Length; i++)
        {
            hammingDistance += firstStrand[i] != secondStrand[i] ? 1 : 0;
        }

        return hammingDistance;
    }
}