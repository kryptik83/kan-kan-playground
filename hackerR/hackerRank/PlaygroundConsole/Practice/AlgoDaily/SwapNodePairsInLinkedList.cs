namespace PlaygroundConsole.Practice.AlgoDaily;

/// <summary>
/// Write a recursive algorithm that swaps every two nodes in a linked list. This is often called a pairwise swap. For example:
/// original list: 1 -> 2 -> 3 -> 4
/// after swapping every 2 nodes: 2 -> 1 -> 4 -> 3
/// </summary>
/// <typeparam name="T"></typeparam>
public static class SwapNodePairsInLinkedList<T> where T: notnull
{
    public static LinkedList<T>? Get(LinkedList<T> list)
    {
        if (list.First == null) return list;

        var head = list.First;
        var next = head.Next;

        while (next != null && head != null)
        {
            (head.Value, next.Value) = (next.Value, head.Value);

            //swap is complete; now move each node forward by two nodes
            head = next.Next; //can also be written for readability as head.Next?.Next;
            next = next.Next?.Next;
        }

        return list;
    }
}