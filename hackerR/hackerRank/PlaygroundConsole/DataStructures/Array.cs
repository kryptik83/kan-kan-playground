namespace PlaygroundConsole.DataStructures;

public static class ArrayExtensions
{
    /// <summary>
    /// Right Rotate an array in circular fashion
    /// </summary>
    /// <param name="arr">The integer array</param>
    /// <param name="places">Number of places to rotate</param>
    public static void RightRotate(this int[] arr, int places)
    {
        var len = arr.Length;
        var placesToRotate = places % arr.Length;

        var temp = new int[placesToRotate];

        //len=5; idx on next-line; 2 places rotated in this example
        //0-1-2-3-4
        //1-2-3-4-5

        var k = 0;
        for (var i = len - placesToRotate; i < len; i++)
        {
            temp[k] = arr[i];
            k++;
        }

        for (var i = len - places - 1; i >= 0; i--)
            arr[i + placesToRotate] = arr[i];

        for (var i = 0; i < placesToRotate; i++)
            arr[i] = temp[i];
    }
}