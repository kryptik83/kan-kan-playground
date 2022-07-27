using PlaygroundConsole.Sorting.Interface;

namespace PlaygroundConsole.Sorting;

/// <summary>
/// The selection sort algorithm sorts an array by repeatedly finding the minimum element (considering ascending order) from unsorted part and putting it at the beginning.
/// The algorithm maintains two sub-arrays in a given array.
/// 1. The sub-array which is already sorted.
/// 2. Remaining sub-array which is unsorted.
/// </summary>
/// <para>Time Complexity: The time complexity of Selection Sort is O(N2) as there are two nested loops:
/// One loop to select an element of Array one by one = O(N)
/// Another loop to compare that element with every other Array element = O(N)
/// Therefore overall complexity = O(N)*O(N) = O(N*N) = O(N2)
/// Auxiliary Space: O(1) as the only extra memory used is for temporary variable while swapping two values in Array. The good thing about selection sort is it never makes more than O(n) swaps and can be useful when memory write is a costly operation.
/// </para>
public class SelectionSort: ISort
{
    public int[] Sort(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] <= arr[minIndex])
                    minIndex = j;
            }

            // ReSharper disable once SwapViaDeconstruction
            var temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }

        return arr;
    }
}