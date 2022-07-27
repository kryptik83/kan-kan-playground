using PlaygroundConsole.Sorting.Interface;

namespace PlaygroundConsole.Sorting;

/// <summary>
/// Insertion Sort implementation
/// </summary>
/// <para>Complexity: In-Place so space/auxiliary complexity is O(1); Time Complexity = O(n^2)</para>
public class InsertionSort: ISort
{
    public int[] Sort(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            var element = arr[i];
            
            var j = 0;
            while (arr[j] < element && j <= i)
                j++;

            if (j == i) continue;
            
            for (var k = i; k >= j + 1; k--)
                arr[k] = arr[k - 1];

            arr[j] = element;
        }

        return arr;
    }
}