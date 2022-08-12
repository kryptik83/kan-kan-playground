using PlaygroundConsole.Sorting.Interface;

namespace PlaygroundConsole.Sorting;

public class QuickSort : ISort
{
    public int[] Sort(int[] arr)
    {
        return QuickSortInternal(arr, 0, arr.Length - 1);
    }

    private static int[] QuickSortInternal(int[] arr, int left, int right)
    {
        var pivotIndex = GetPivotIndex(arr, left, right);
        if (pivotIndex > 1)
            QuickSortInternal(arr, left, pivotIndex - 1);
        
        if (pivotIndex < right - 1)
            QuickSortInternal(arr, pivotIndex + 1, right);

        return arr;
    }

    private static int GetPivotIndex(int[] arr, int left, int right)
    {
        var pivot = arr[left];
        while (true)
        {
            while (arr[left] < pivot)
                left++;
            while (arr[right] > pivot)
                right--;
            if (left < right)
                (arr[left], arr[right]) = (arr[right], arr[left]);
            else
                return right;
        }
    }
    
}