namespace PlaygroundConsole.Practice.AlgoDaily;

public static class GrabRandomNode
{
    private static readonly Random RandomGenerator = new();

    public static int Get(LinkedList<int> linkedList)
    {
        var len = linkedList.Count;
        if (len == 0) return default;

        var head = linkedList.First;

        var rand = RandomGenerator.Next(1, len);
        var offset = 1;

        while (offset < rand && head != null)
        {
            head = head.Next;
            offset++;
        }

        return head?.Value ?? default;
    }
}