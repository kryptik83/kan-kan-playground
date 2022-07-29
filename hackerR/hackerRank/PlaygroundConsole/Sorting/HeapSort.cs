using PlaygroundConsole.Sorting.Interface;

namespace PlaygroundConsole.Sorting;

public class HeapSort: ISort
{
    public int[] Sort(int[] arr)
    {
        var n = arr.Length;
        for (var i = n / 2 - 1; i >= 0; i--)
            heapify(arr, n, i);

        for (var j = n - 1; j > 0; j--)
        {
            //move root to end
            (arr[0], arr[j]) = (arr[j], arr[0]);
            heapify(arr, j, 0);
        }

        return arr;
    }

    /// <summary>
    /// Helper method to  heapify a subtree rooted with node i which is an index in arr[]. n is size of heap
    /// Heapify re-balances the tree if the node being assessed is not the largest
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n">size of array</param>
    /// <param name="i">index of node where we are heapify-ing</param>
    private void heapify(int[] arr, int n, int i)
    {
        var largest = i;
        var left = 2 * i + 1;
        var right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;
        
        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            //largest element goes to i
            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            heapify(arr, n, largest);
        }
    }
}