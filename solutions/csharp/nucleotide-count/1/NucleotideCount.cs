public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> dnaSequence = new()
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0,
        };

        if (string.IsNullOrEmpty(sequence))
        {
            return dnaSequence;
        }


        for (int i = 0; i < sequence.Length; i++)
        {
            if (dnaSequence.ContainsKey(sequence[i]))
            {
                dnaSequence[sequence[i]]++;
            }
            else
            {
                throw new ArgumentException("error");
            }
        }

        return dnaSequence;
    }
}