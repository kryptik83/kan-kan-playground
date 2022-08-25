namespace PlaygroundConsole.Practice.AlgoDaily;

public static class LinkedListIntersection<T> where T : notnull
{
    public static LinkedList<T> Get(LinkedList<T> list1, LinkedList<T> list2)
    {
        var result = new LinkedList<T>();
        if (list1.First == null || list2.First == null) return result;
        
        var list1Head = list1.First;
        while (list1Head != null)
        {
            if (IsPresent(list2.First, list1Head.Value))
                result.AddLast(new LinkedListNode<T>(list1Head.Value));
            
            list1Head = list1Head.Next;
        }

        return result;
    }

    private static bool IsPresent(LinkedListNode<T>? head, T val)
    {
        if (head == null) return false;
        while (head != null)
        {
            if (head.Value.Equals(val)) return true;
            head = head.Next;
        }

        return false;
    }
}