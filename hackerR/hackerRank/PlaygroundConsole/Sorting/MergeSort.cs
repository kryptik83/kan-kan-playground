using PlaygroundConsole.Sorting.Interface;

namespace PlaygroundConsole.Sorting;

/// <summary>
/// Merge Sort implementation
/// </summary>
/// <para>Complexity: Auxiliary complexity is O(n) for temp array; Time Complexity = O(n log(n)) <!--recursion--></para>
public class MergeSort: ISort
{
    public int[] Sort(int[] arr)
    {
        return MergeSortInternal(arr, 0, arr.Length - 1);
    }

    private int[] MergeSortInternal(int[] arr, int left, int right)
    {
        if (left < right)
        {
            var mid = left + (right - left) / 2;
            MergeSortInternal(arr, left, mid);
            MergeSortInternal(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }

        return arr;
    }

    private void Merge(int[] arr, int left, int mid, int right)
    {
        var i = left;
        var j = mid + 1;
        var k = 0;

        var temp = new int[right - left + 1];
        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j])
            {
                temp[k] = arr[i];
                i++;
            }
            else
            {
                temp[k] = arr[j];
                j++;
            }

            k++;
        }

        //ran out of one of the wo sub arrays - append the rest
        while (i <= mid)
        {
            temp[k] = arr[i];
            i++;
            k++;
        }
        
        while (j <= right)
        {
            temp[k] = arr[j];
            j++;
            k++;
        }
        
        for (var anotherIndex = left; anotherIndex <= right; anotherIndex++)
            arr[anotherIndex] = temp[anotherIndex - left];
    }
}