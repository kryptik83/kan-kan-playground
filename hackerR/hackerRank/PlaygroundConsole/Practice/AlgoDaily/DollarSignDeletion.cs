namespace PlaygroundConsole.Practice.AlgoDaily;

public static class DollarSignDeletion
{
    public static bool IsDollarDeleteEqual(string[] arr)
    {
        if (arr.Length != 2) return false;
        return GetSanitizedString(arr[0]).SequenceEqual(GetSanitizedString(arr[1]));
    }

    private static string GetSanitizedString(string inputString)
    {
        var stack = new Stack<char>();
        foreach (var ch in inputString)
        {
            if (ch != '$')
                stack.Push(ch);
            else
            {
                if (stack.Count > 0)
                    stack.Pop();
            }
        }

        var computedFinalString = string.Empty;
        while (stack.Count > 0)
            computedFinalString = stack.Pop() + computedFinalString;

        return computedFinalString;
    }
}