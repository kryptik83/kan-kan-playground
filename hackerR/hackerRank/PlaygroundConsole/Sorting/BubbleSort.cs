using PlaygroundConsole.Sorting.Interface;

namespace PlaygroundConsole.Sorting;

/// <summary>
/// Bubble Sort implementation
/// </summary>
/// <para>Complexity: In-Place so space/auxiliary complexity is O(1); Time Complexity = O(n^2)</para>
public class BubbleSort : ISort
{
    
    public int[] Sort(int[] arr)
    {
        for (var i = 0; i < arr.Length - 1; i++)
        {
            for (var j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    //(arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);

                    // ReSharper disable once SwapViaDeconstruction
                    var minTemp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = minTemp;
                }
            }
        }

        return arr;
    }
}