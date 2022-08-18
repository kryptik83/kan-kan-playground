namespace PlaygroundConsole.Practice.AlgoDaily;

public static class LoneRanger
{
    public static int Get(int[] numbers)
    {
        var dict = new Dictionary<int, int>();
        //Note: we incremented first before assigning
        foreach (var number in numbers) 
            dict[number] = dict.ContainsKey(number) ? ++dict[number] : 1;

        return dict.Keys.FirstOrDefault(key => dict[key] == 1);
    }
}