public static class SecretHandshake
{

    private static readonly Dictionary<int, Func<IEnumerable<string>, IEnumerable<string>>> secretCodeCommands = new()
    {
        {0, (commands) => commands.Append("wink")},
        {1, (commands) => commands.Append("double blink")},
        {2, (commands) => commands.Append("close your eyes") },
        {3, (commands) => commands.Append("jump") },
        {4, (commands) => commands.Reverse() },
    };

    public static string[] Commands(int commandValue)
    {
        List<string> commands = [];
        for (int i = 0; i < secretCodeCommands.Count; i++)
        {
            if ((commandValue & (1 << i)) != 0)
            {
                commands = [.. secretCodeCommands[i](commands)];
            }

        }
        return [.. commands];
    }
}
