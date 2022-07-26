namespace PlaygroundConsole.Modules;

public class Reverser
{
    public static string Output(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        
        var arr = input.ToCharArray();
        for (int i = 0; i < arr.Length/2; i++)
        {
            // ReSharper disable once SwapViaDeconstruction
            var temp = arr[i];
            arr[i] = arr[arr.Length - i - 1];
            arr[arr.Length - i - 1] = temp;
        }
        return string.Join("", arr);
    }
}