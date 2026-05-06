using System.Runtime.InteropServices;

public static class SecretHandshake
{

    private static readonly Dictionary<int, Func<IEnumerable<string>, IEnumerable<string>>> secretCodeCommands = new()
    {
        {0, (commands) => commands.Prepend("wink")},
        {1, (commands) => commands.Prepend("double blink")},
        {2, (commands) => commands.Prepend("close your eyes") },
        {3, (commands) => commands.Prepend("jump") }
    };

    public static string[] Commands(int commandValue)
    {
        List<string> commands = [];
        int count = 4;
        int powerOfTwo = (int)Math.Pow(2, count);

        bool reverse = false;

        if (commandValue >= powerOfTwo)
        {
            commandValue -= powerOfTwo;
            reverse = true;
        }

        count--;

        while (count >= 0)
        {
            powerOfTwo = (int)Math.Pow(2, count);
            if (commandValue >= powerOfTwo)
            {
                commandValue -= powerOfTwo;
                commands = [.. secretCodeCommands[count](commands)];
            }

            count--;
        }

        if (reverse)
        {
            commands.Reverse();
        }

        return [.. commands];
    }
}
