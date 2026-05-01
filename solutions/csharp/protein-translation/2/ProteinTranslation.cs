public static class ProteinTranslation
{
    public static string[] Proteins(string strand) => [.. strand.Chunk(3).Select(c => ToProtein(string.Concat(c))).TakeWhile(protein => protein != "STOP")];

    private static string ToProtein(string strand) => strand switch
    {
        "AUG" => "Methionine",
        "UUU" or "UUC" => "Phenylalanine",
        "UUA" or "UUG" => "Leucine",
        "UCU" or "UCC" or "UCA" or "UCG" => "Serine",
        "UAU" or "UAC" => "Tyrosine",
        "UGU" or "UGC" => "Cysteine",
        "UGG" => "Tryptophan",
        "UAA" or "UAG" or "UGA" => "STOP",
        _ => throw new NotImplementedException(),
    };

}