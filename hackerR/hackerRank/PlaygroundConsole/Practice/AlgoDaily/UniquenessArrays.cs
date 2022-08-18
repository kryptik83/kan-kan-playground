namespace PlaygroundConsole.Practice.AlgoDaily;

//https://algodaily.com/challenge_slides/uniqueness-of-arrays
public static class UniquenessArrays
{
    public static List<int> Uniques(int[] array)
    {
        var hashMap = new HashSet<int>();
        foreach (var element in array)
            hashMap.Add(element);

        return hashMap.ToList();
    }
}