public static class ScrabbleScore
{
    public static int Score(string input) => input.ToUpper().Sum(GetScore);

    public static int GetScore(char c) => c switch
    {
        char x when "AEIOULNRST".Contains(x) => 1,
        char x when "DG".Contains(x) => 2,
        char x when "BCMP".Contains(x) => 3,
        char x when "FHVWY".Contains(x) => 4,
        char x when "K".Contains(x) => 5,
        char x when "JX".Contains(x) => 8,
        char x when "QZ".Contains(x) => 10,
        _ => 0,
    };
}