namespace PlaygroundConsole.Practice.AlgoDaily;

//https://algodaily.com/challenge_slides/contiguous-subarray-sum/info-screen-yFD1zl1fpcg
//Video explanation: https://youtu.be/yLQqXb3tcIo
public static class ContiguousSubarraySum
{
    public static bool SubarraySum(int[] nums, int n)
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
        var sumsSet = new HashSet<int>(); //Note: sumsSet stores RunningSum upto the currently looked at number in the array
        sumsSet.Add(0);
        
        var sum = 0;
        foreach (var element in nums)
        {
            sum += element; // increment current sum
            
            //since we are doing the calculation based on current sum, if the sum of current element
            
            //∑ nums(1..elementIdx-1) + element = ∑ nums(1..elementIdx)
            //<-- this will go in sumsSet, if this subtracted n is in the sumsSet before addition then we return trues 
            if (sumsSet.Contains(sum - n))
                return true;
            
            // store sum so far in hash with truthy value
            sumsSet.Add(sum);
        }
        return false;
    }

}