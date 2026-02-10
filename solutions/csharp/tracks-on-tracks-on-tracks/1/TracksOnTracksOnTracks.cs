public static class Languages
{
    public static List<string> NewList() => [];

    public static List<string> GetExistingLanguages() => ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages, string language) => [..languages, language];

    public static int CountLanguages(List<string> languages) =>  languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Any(l => l == language);

    public static List<string> ReverseList(List<string> languages) 
    { 
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        var numberOfLanguages = CountLanguages(languages);
        
        return numberOfLanguages > 0 && (languages.First() == "C#" || (languages[1] == "C#" && (numberOfLanguages == 2 || numberOfLanguages == 3)));
    }

    public static List<string> RemoveLanguage(List<string> languages, string language) 
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages) => languages.Distinct().Count() == CountLanguages(languages);
}