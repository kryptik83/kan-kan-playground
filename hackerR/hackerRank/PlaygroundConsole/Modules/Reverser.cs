using System.Text;

namespace PlaygroundConsole.Modules;

public class Reverser
{
    public static string Output(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;

        var arr = input.ToCharArray();
        for (int i = 0; i < arr.Length / 2; i++)
        {
            var temp = arr[i];
            arr[i] = arr[arr.Length - i - 1];
            arr[arr.Length - i - 1] = temp;
        }

        return string.Join("", arr);
    }

    public static string OnlyAlphabetical(string str)
    {
        var ch = str.ToCharArray();
        var sb = new StringBuilder();
        var lastIndex = ch.Length - 1;
        for (int i = 0; i <= ch.Length - 1; i++)
        {
            if (!char.IsLetter(ch[i])) sb.Append(ch[i]);
            else
            {
                while (!char.IsLetter(ch[lastIndex]) && lastIndex >= 0)
                    lastIndex--;

                sb.Append(ch[lastIndex]);
                lastIndex--;
            }
        }

        return sb.ToString();
    }

    public static string ReverseOnlyAlphabetical(string str)
    {
        // Convert to StringBuilder
        var length = str.Length;
        var sb = new StringBuilder(str);

        var start = 0;
        var end = length - 1;

        while (start < end)
        {
            // if both pointers are char, then swap
            if (char.IsLetter(sb[start]) && char.IsLetter(sb[end]))
            {
                (sb[start], sb[end]) = (sb[end], sb[start]);
                //|NOTE| the bottom lines are same as above one line, swap via deconstruction
                // var temp = sb[start];
                // sb[start] = sb[end];
                // sb[end] = temp;
                start++;
                end--;
            }
            else if (!char.IsLetter(sb[start])) start++;
            else if (!char.IsLetter(sb[end])) end--;
        }

        return sb.ToString();
    }
}