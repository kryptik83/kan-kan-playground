namespace PlaygroundConsole.Search;

public static class Traversal
{
    public static List<int> InorderTraversal(Node? root)
    {
        var abc = new List<int>();
        if (root == null) return abc;

        var leftRange = InorderTraversal(root.Left);
        if (leftRange.Any())
            abc.AddRange(leftRange);

        abc.Add(root.Val);

        var rightRange = InorderTraversal(root.Right);
        if (rightRange.Any())
            abc.AddRange(rightRange);

        return abc;
    }
}

// available data structures

public class Node
{
    public readonly int Val;
    public Node? Left;
    public Node? Right;

    public Node(int val)
    {
        Val = val;
    }
}