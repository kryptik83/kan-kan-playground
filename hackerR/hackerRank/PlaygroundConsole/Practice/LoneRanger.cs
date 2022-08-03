// ReSharper disable once CheckNamespace
namespace PlaygroundConsole.Practice.AlgoDaily;

public class LoneRanger
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