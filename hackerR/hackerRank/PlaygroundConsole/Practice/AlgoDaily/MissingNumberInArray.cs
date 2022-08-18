namespace PlaygroundConsole.Practice.AlgoDaily;

public static class MissingNumberInArray
{
    public static List<int> MissingNumbers(int[] numArr)
    {
        var missing = new List<int>();
        for (var i = 1; i < numArr.Length; i++)
        {
            if (numArr[i] - numArr[i - 1] > 1)
            {
                var lastKnownGoodElement = numArr[i-1];
                while (lastKnownGoodElement < numArr[i] - 1)
                    missing.Add(++lastKnownGoodElement);
            }
        }

        return missing;
    }
}