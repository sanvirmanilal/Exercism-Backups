public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        if (strand.Length % 3 != 0)
        {
            throw new ArgumentException();
        }

        var stopCodons = new[] { "UAA", "UAG", "UGA" };

        int firstIndex = strand.Length;
        foreach (var stopCodon in stopCodons)
        {
            int stopCodonIndex = strand.IndexOf(stopCodon);
            firstIndex = stopCodonIndex != -1 && stopCodonIndex % 3 == 0 && stopCodonIndex < firstIndex ? stopCodonIndex : firstIndex;
        }

        strand = strand.Substring(0, firstIndex);

        List<string> codons = [];

        for (int i = 0; i < strand.Length; i += 3)
        {
            codons.Add(strand.Substring(i, 3) switch
            {
                "AUG" => "Methionine",
                "UUU" or "UUC" => "Phenylalanine",
                "UUA" or "UUG" => "Leucine",
                "UCU" or "UCC" or "UCA" or "UCG" => "Serine",
                "UAU" or "UAC" => "Tyrosine",
                "UGU" or "UGC" => "Cysteine",
                "UGG" => "Tryptophan",

            });
        }

        return [.. codons];
    }
}