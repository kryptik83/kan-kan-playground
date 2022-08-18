namespace PlaygroundConsole.Practice.AlgoDaily;

//https://algodaily.com/challenge_slides/fast-minimum-in-rotated-array
public static class FastMinimumInRotatedArray
{
    public static int GetMinimum(int[] nums)
    {
        //use selection sort but for 1 iteration only
        var i = 0;
         var minIndex = i;
         // ReSharper disable once UselessBinaryOperation
         for (var j = i + 1; j < nums.Length; j++)
             if (nums[j] < nums[minIndex])
                 minIndex = j;

         return nums[minIndex];
    }
}