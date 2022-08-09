using System.Collections;

// ReSharper disable once CheckNamespace
namespace PlaygroundConsole.Practice.Codility;

public static class BinaryGap
{
    public static (string BinaryRepresentation, int BiggestGap) FindBiggest(int number)
    {
        var bin = GetBinaryRepresentation(number);

        var gap = 0;
        var foundFirstOne = false;
        var count = 0;
        for (var i = 0; i < bin.Length; i++)
        {
            while (bin[i] != '1' && !foundFirstOne)
                i++;

            if (bin[i] == '1')
            {
                foundFirstOne = true;
                count = 0;
                //don't set foundFirstOne to false it's a 1 start of next sequence : foundFirstOne = false;
            }
            else
            {
                while (bin[i] != '1' && i < bin.Length - 1)
                {
                    count++;
                    i++;
                }

                if (bin[i] == '1')
                {
                    gap = Math.Max(gap, count);
                    count = 0; 
                }
            }
        }

        return (bin, gap);
    }

    private static string GetBinaryRepresentation(int number)
    {
        var binaryRepresentation = new ArrayList();
        while (number > 0)
        {
            binaryRepresentation.Add(number % 2);
            number /= 2;
        }

        var arr = (int[]) binaryRepresentation.ToArray(typeof(int));
        var binStr = string.Join("", arr.Reverse());

        return binStr;
    }
}