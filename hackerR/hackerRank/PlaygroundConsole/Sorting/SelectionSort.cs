using PlaygroundConsole.Sorting.Interface;

namespace PlaygroundConsole.Sorting;

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