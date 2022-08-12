using PlaygroundConsole.Sorting;

namespace PlaygroundConsole;

public static class MaxOfMinPairs
{
    public static int Compute(int[] nums)
    {
        if (nums.Length % 2 != 0 || nums.Length == 0) return 0;

        var sorted = new QuickSort().Sort(nums);

        var minSum = 0;
        for (var i = 0; i < sorted.Length; i += 2) minSum += sorted[i];
        return minSum;
    }
}