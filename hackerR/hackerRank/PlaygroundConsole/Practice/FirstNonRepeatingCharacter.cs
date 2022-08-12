namespace PlaygroundConsole;

public static class FirstNonRepeatingCharacter
{
    public static char Solve(string input)
    {
        var map = new Dictionary<char, int>();
        foreach (var c in input)
            map[c] = map.ContainsKey(c) ? ++map[c] : 1;

        foreach (var key in map.Keys)
            if (map[key] == 1)
                return key;

        return default;
    }
}