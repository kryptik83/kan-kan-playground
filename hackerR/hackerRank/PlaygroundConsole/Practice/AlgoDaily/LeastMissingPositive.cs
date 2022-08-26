namespace PlaygroundConsole.Practice.AlgoDaily;

/// <summary>
/// A method that takes such an array of integers and returns the first missing positive integer
/// </summary>
/// <!-- Constraints
/// Length of the array <= 100000
/// The array can be empty
/// The array will contain values between -100000 and 100000
/// The final answer will always fit in the integer range
/// Expected time complexity : O(n)
/// Expected space complexity : O(1)
/// -->
public static class LeastMissingPositive
{
    
    //O(n) solution Time complexity but also O(n) for space
    public static int Find(int[] nums)
    {
        var hashSet = nums.ToHashSet();
        
        var smallestPossibleMissing = 1;
        while (true)
        {
            if (!hashSet.Contains(smallestPossibleMissing))
                return smallestPossibleMissing;

            smallestPossibleMissing++;
        }
    }
}