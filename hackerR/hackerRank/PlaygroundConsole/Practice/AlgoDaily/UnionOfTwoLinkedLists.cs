namespace PlaygroundConsole.Practice.AlgoDaily;

public static class UnionOfTwoLinkedLists<T> where T : notnull
{
    public static LinkedList<T> GetUnion(LinkedList<T> list1, LinkedList<T> list2)
    {
        var hashSet = new HashSet<T>();
        var result = new LinkedList<T>();
        
        var head = list1.First;
        while (head != null)
        {
            hashSet.Add(head.Value);
            head = head.Next;
        }
        
        head = list2.First;
        while (head != null)
        {
            hashSet.Add(head.Value);
            head = head.Next;
        }

        foreach (var item in hashSet)
            result.AddLast(new LinkedListNode<T>(item));

        return result;
    }
}