namespace PlaygroundConsole.Practice.AlgoDaily;

/// <summary>
/// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
/// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
/// You must write an algorithm that runs in O(n) time and without using the division operation.
/// </summary>
/// https://leetcode.com/problems/product-of-array-except-self
public static class ProductExceptSelf
{
    public static int[] Solve(int[] nums)
    {
        var len = nums.Length;
        var res = new int[len];

        var left = 1;
        for (var i = 0; i < len; i++)
        {
            res[i] = left;
            left *= nums[i];
        }

        var right = 1;
        for (var i = len - 1; i >= 0; i--)
        {
            res[i] *= right;
            right *= nums[i];
        }

        return res;
    }
}